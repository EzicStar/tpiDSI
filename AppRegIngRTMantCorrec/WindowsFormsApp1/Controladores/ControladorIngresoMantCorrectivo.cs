using AplicacionPPAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionPPAI.Models
{
    public class ControladorIngresoMantCorrectivo
    {
        PantIngMantCorrec interfaz;
        List<RecursoTecnologico> rtsASeleccionar;
        RecursoTecnologico rtSeleccionado;
        List<Turno> turnosResOPendRes;
        string razonMantenimiento;
        DateTime fechaFinPrevista;
        string tipoNotif;
        Estado[] estados;
        Estado cancelado;
        Estado conIngEnMantCorrec;
        List<string> mailsCientificos;

        // registrar ingreso de rt en mantenimiento correctivo
        public void RegIngRTMantCorrec(PantIngMantCorrec interfaz)
        {
            // el objeto asignacion responsable tecnico del correspondiente usuario
            var miAsigRespTec = ObtenerRespTecnico();
            // lista de los recursos tecnologicos disponibles del resp tecnico
            rtsASeleccionar =  miAsigRespTec.MisRTDisponibles();
            List<RecursoTecnologico> rtsOrdenados = OrdenarRTsPorTipo(rtsASeleccionar);
            List<string[]> infoRts = new List<string[]>();
            foreach (RecursoTecnologico rt in rtsOrdenados)
            {
                infoRts.Add(rt.MostrarRT());
            }
            this.interfaz = interfaz;

            interfaz.MostrarRTASeleccionar(infoRts);
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
            foreach (Turno turno in turnosOrdenados)
            {
                string[] infoTurno = turno.MostrarTurno();
                infoTurnos.Add(infoTurno);
                //mailsCientificos.Add(infoTurno[6]);
            }

            interfaz.MostrarTurnosResAfect(infoTurnos); // tmb solicita confirmacion y tipo de notificacion
        }
        
        public void ConfirmacionIngresada(bool mail, bool wpp)
        {
            //aca empieza la creacion del mantenimiento
            estados = FakeData.Listaestados;
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

                rtSeleccionado.EnMantenimientoCorrectivo(cancelado, conIngEnMantCorrec, DateTime.Now, fechaFinPrevista, razonMantenimiento);

                InterfazCorreoElectronico gestorCorreo = new InterfazCorreoElectronico();
                string mensajeMail = "Su turno ha sido cancelado por mantenimiento correctivo, disculpe las molestias";
                gestorCorreo.GenerarMailPorMantenimientoCorrectivo(mailsCientificos, mensajeMail);
            }
        }

        public AsignacionResponsableTecnicoRT ObtenerRespTecnico()
        {
            PersonalCientifico personalCientif = FakeData.SesionActual.GetPersonalCientif();

            int lenAsig = FakeData.ListaAsignaciones.Count;
            for (int i = 0; i < lenAsig; i++)
            {
                if (FakeData.ListaAsignaciones[i].EsUsuarioLogueadoYVigente(personalCientif) == true)
                {
                    return FakeData.ListaAsignaciones[i];
                }
            }
            return null;
        }

        //funcion que 
        public List<RecursoTecnologico> OrdenarRTsPorTipo(List<RecursoTecnologico> listaAOrdenar)
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
        public List<Turno> OrdenarTurnosXCientifico(List<Turno> listaAOrdenar)
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
