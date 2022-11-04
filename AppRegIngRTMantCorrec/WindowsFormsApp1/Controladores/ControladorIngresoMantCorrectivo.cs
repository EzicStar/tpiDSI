using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;
using WindowsFormsApp1.BBDD;
using WindowsFormsApp1.Controladores;

namespace AplicacionPPAI.Models
{
    public class ControladorIngresoMantCorrectivo : ISujeto
    {
        PantIngMantCorrec interfaz;
        List<RecursoTecnologico> rtsASeleccionar;
        RecursoTecnologico rtSeleccionado;
        List<Turno> turnosResOPendRes;
        string razonMantenimiento;
        DateTime fechaActual;
        DateTime fechaFinPrevista;
        string tipoNotif;
        List<Estado> estados;
        Estado cancelado;
        Estado conIngEnMantCorrec;
        List<string> mailsCientificos = new List<string>();
        List<int> telefonoCientificos = new List<int>();
        bool notifMail;
        bool notifWapp;
        List<IObservador> observadores = new List<IObservador>();

        // registrar ingreso de rt en mantenimiento correctivo
        public void RegIngRTMantCorrec(PantIngMantCorrec interfaz)
        {
            // el objeto asignacion responsable tecnico del correspondiente usuario
            AsignacionResponsableTecnicoRT miAsigRespTec = ObtenerRespTecnico(); //TODO: aca estaba como tipo var en vez de asig, revisar q ande
            // lista de los recursos tecnologicos disponibles del resp tecnico
            rtsASeleccionar = BDRecursoTecnologico.GetRecursosTecnologicosResp(miAsigRespTec.GetLegajo(), miAsigRespTec.GetFechaHoraDesde());
            //rtsASeleccionar = MostrarRTDisponibles(miAsigRespTec);
            List<RecursoTecnologico> rtsOrdenados = OrdenarRTsPorTipo(rtsASeleccionar);
            List<string[]> infoRts = new List<string[]>();
            foreach (RecursoTecnologico rt in rtsOrdenados)
            {
                infoRts.Add(rt.MostrarRT());
            }
            this.interfaz = interfaz;

            interfaz.MostrarRTASeleccionar(infoRts);
        }

        private List<RecursoTecnologico> MostrarRTDisponibles(AsignacionResponsableTecnicoRT asig)
        {
            return asig.MisRTDisponibles();
        }

        public void RTSeleccionado(string numeroRT)
        {
            // buscamos entre todos los numeros de los RT, el numero cuyo usuario seleccionó
            for (int i = 0; i < rtsASeleccionar.Count; i++)
            {
                if (rtsASeleccionar[i].EsMiNum(Int32.Parse(numeroRT)))
                {
                    rtSeleccionado = rtsASeleccionar[i];
                }
            }
            interfaz.SolicitarRazonYFechaFinPrevista();
        }

        public void RazonYFechaFinPrevistaIngresada(string razón, string fecha)
        {
            razonMantenimiento = razón;
            fechaFinPrevista = DateTime.Parse(fecha);
            turnosResOPendRes = rtSeleccionado.MostrarTurnosReservadosPorMC(fechaFinPrevista);
            List<Turno> turnosOrdenados = OrdenarTurnosXCientifico(turnosResOPendRes);
            List<string[]> infoTurnos = new List<string[]>();
            if (turnosResOPendRes.Count == 0)
            {
                interfaz.InformarFaltaDeTurno();
            }
            foreach (Turno turno in turnosOrdenados)
            {
                string[] infoTurno = turno.MostrarTurno();
                infoTurnos.Add(infoTurno);
                mailsCientificos.Add(infoTurno[6]);
                telefonoCientificos.Add(int.Parse(infoTurno[8])); //TODO: revisar que el indice sea el de telefono
            }

            interfaz.MostrarTurnosResAfect(infoTurnos); // tmb solicita confirmacion y tipo de notificacion
        }
        
        public void ConfirmacionIngresada(bool mail, bool wapp)
        {
            //se guardan las opciones de notificacion
            notifMail = mail;
            notifWapp = wapp;

            CrearMantenimiento();
            GenerarNotifCientifico();
        }

        //Delega al rt la creacion del mantenimiento buscando previamente los estados para pasarselos por parametro
        private void CrearMantenimiento()
        {
            estados = BDEstado.GetEstados();
            foreach (Estado estado in estados)
            {
                if (estado.EsAmbitoTurno() && estado.EsCancelado())
                {
                    cancelado = estado;
                }

                else if (estado.EsAmbitoRT() && estado.EsConMantenimientoCorrectivo())
                {
                    conIngEnMantCorrec = estado;
                }
            }

            fechaActual = DateTime.Now; //guardamos la fecha actual

            rtSeleccionado.EnMantenimientoCorrectivo(cancelado, conIngEnMantCorrec, fechaActual, fechaFinPrevista, razonMantenimiento);
        }

        // LLama al generador de mail o whatsapp segun el tipo de notificacion seleccionada
        private void GenerarNotifCientifico()
        {
            List<IObservador> interfaces = new List<IObservador>(); 

            if(notifMail)
            {
                InterfazCorreoElectronico interfazCorreo = new InterfazCorreoElectronico();
                interfaces.Add(interfazCorreo);
            }
            if(notifWapp)
            {
                InterfazWhatsApp interfazWapp = new InterfazWhatsApp();
                interfaces.Add(interfazWapp);
            }
            
            foreach ( IObservador interfaz in interfaces)
            {
                Suscribir(interfaz);
            }

            Notificar();
            
        }

        public void Suscribir(IObservador observador)
        {
            observadores.Add(observador);
        }

        public void Quitar(IObservador observador)
        {
            observadores.Remove(observador);
        }

        public void Notificar()
        {
            //creamos el mensaje
            string mensaje = "Lamentamos informarle que su turno para utilizar el recurso tecnológico de" +
            $" tipo {rtSeleccionado.MostrarTipoRT()}, id número {rtSeleccionado.MostrarRT()[1]} ha sido cancelado por la siguiente razón: " +
            razonMantenimiento + ". Disculpe las molestias.";

            foreach(IObservador observador in observadores)
            {
                observador.Notificar(telefonoCientificos.ToArray(), mailsCientificos.ToArray(), "Cancelacion Turno", mensaje);
            }
        }

        public AsignacionResponsableTecnicoRT ObtenerRespTecnico()
        {
            Sesion sesionActual = new Sesion(DateTime.ParseExact("20211102", "yyyyMMdd", CultureInfo.InvariantCulture), null, BDUsuario.GetUsuario("Gandalf"));
            PersonalCientifico personalCientif = sesionActual.GetPersonalCientif();
            List<AsignacionResponsableTecnicoRT> respoList = BDAsignacionResponsableTecnicoRT.GetAsignacionesResponsableTecnicoRT();
            //List<AsignacionResponsableTecnicoRT> respoList = FakeData.ListaAsignaciones;
            int lenAsig = respoList.Count;
            for (int i = 0; i < lenAsig; i++)
            {
                if (respoList[i].EsUsuarioLogueadoYVigente(personalCientif) == true)
                {
                    return respoList[i];
                }
            }
            return null;
        }

        //funcion que 
        private List<RecursoTecnologico> OrdenarRTsPorTipo(List<RecursoTecnologico> listaAOrdenar)
        {
            for (int i = 0; i < (listaAOrdenar.Count - 1); i++)
            {
                for (int j = i + 1; j < listaAOrdenar.Count; j++)
                {
                    if (String.Compare(listaAOrdenar[i].MostrarTipoRT(), listaAOrdenar[j].MostrarTipoRT()) >= 1)
                    {
                        RecursoTecnologico temp = listaAOrdenar[i];
                        listaAOrdenar[i] = listaAOrdenar[j];
                        listaAOrdenar[j] = temp;
                    }

                }
            }
            return listaAOrdenar;
        }
        private List<Turno> OrdenarTurnosXCientifico(List<Turno> listaAOrdenar)
        {
            for (int i = 0; i < (listaAOrdenar.Count - 1); i++)
            {
                for (int j = i + 1; j < listaAOrdenar.Count; j++)
                {
                    if (Int64.Parse(listaAOrdenar[i].MostrarCientifico()[0]) <= Int64.Parse(listaAOrdenar[j].MostrarCientifico()[0])) // ordena por legajo los cientfiicos
                    {
                        Turno temp = listaAOrdenar[i];
                        listaAOrdenar[i] = listaAOrdenar[j];
                        listaAOrdenar[j] = temp;
                    }

                }
            }
            return listaAOrdenar;
        }

    }
}
