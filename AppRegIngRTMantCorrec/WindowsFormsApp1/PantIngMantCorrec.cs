using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionPPAI.Models
{
    public partial class PantIngMantCorrec : Form
    {
        ControladorIngresoMantCorrectivo controlador = new ControladorIngresoMantCorrectivo();
        public PantIngMantCorrec()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.lbl_Titulo.Text = "HOME";
            this.btnHome.BackColor = Color.FromArgb(0, 135, 137);
            this.btnMantCorrec.BackColor = Color.FromArgb(50, 52, 77);
            this.groupBoxRTCargaMotivo.Visible = false;
            this.groupBoxRTShow.Visible = false;
        }

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    AplicacionPPAI.Controladores.ControladorIngresoMantCorrectivo controlador = new AplicacionPPAI.Controladores.ControladorIngresoMantCorrectivo();
        //    controlador.RegIngRTMantCorrec();
        //}

        private void btnMantCorrec_Click(object sender, EventArgs e)
        {
            this.lbl_Titulo.Text = "Registrar Ingreso de Mantenimiento Correctivo";
            this.groupBoxRTShow.Visible = true;
            this.btnMantCorrec.BackColor = Color.FromArgb(0, 135, 137);
            this.btnHome.BackColor = Color.FromArgb(50, 52, 77);

            controlador.RegIngRTMantCorrec(this);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //invisibiliza todo
            this.groupBoxRTShow.Visible = false;
            //recarga grilla
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            //if (dgw_RTDisponibles.CurrentRow != null)
            //{
                string _numRT = seleccionarRT();
                controlador.RTSeleccionado(_numRT);
            //}
            //else
            //    MessageBox.Show("No se seleccionó NADA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string seleccionarRT()
        {

            string tipo = dgw_RTDisponibles.CurrentRow.Cells[0].Value.ToString().ToUpper();
            string num = dgw_RTDisponibles.CurrentRow.Cells[1].Value.ToString();
            string marca = dgw_RTDisponibles.CurrentRow.Cells[2].Value.ToString().ToUpper();
            string modelo = dgw_RTDisponibles.CurrentRow.Cells[3].Value.ToString().ToUpper();

            this.lbl_tipoRt.Text = tipo + "  " + num + "    " + marca + "-" + modelo;
            return num;
        }
        public void SolicitarRazonYFechaFinPrevista()
        {
            this.groupBoxRTShow.Visible = false;
            this.groupBoxRTCargaMotivo.Visible = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //saber cuando cambie el valor, deba
            //cargar la grilla con los turnos de esa fecha
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            if (this.txt_RazonIngreso.Text.Trim() != "")
            {
                if (dgw_Turnos.CurrentRow != null)
                    if (this.chk_email.Checked || this.chk_wpp.Checked)
                    {
                        string msg = "Se ha informado vía ";
                        if (chk_wpp.Checked)
                            msg += "WhatsApp ";
                        if (chk_email.Checked)
                            msg += "Email ";
                        MessageBox.Show(msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // 
                        controlador.RazonYFechaFinPrevistaIngresada(txt_RazonIngreso.Text, dtp_fechaFinPrevista.Value.ToString());
                        controlador.ConfirmacionIngresada(chk_email.Checked, chk_wpp.Checked);
                    }
                    else
                    {
                        MessageBox.Show("Seleccione el medio de informacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                else
                    MessageBox.Show("No se seleccionó NADA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No se cargó el Motivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public void MostrarRTASeleccionar(List<string[]> infoRts)
        {
            dgw_RTDisponibles.Columns.Clear();
            dgw_RTDisponibles.Rows.Clear();
            dgw_RTDisponibles.DataSource = null;
            dgw_RTDisponibles.Columns.Add("tipoRT", "Tipo RT");
            dgw_RTDisponibles.Columns.Add("numeroRT", "N° RT");
            dgw_RTDisponibles.Columns.Add("marcaRT", "Marca");
            dgw_RTDisponibles.Columns.Add("modeloRT", "Modelo");

            for (int fila = 0; fila < infoRts.Count; fila++)
            {
                dgw_RTDisponibles.Rows.Add(infoRts[fila]);
            }
            
        }
        public void MostrarTurnosResAfect(List<string[]> infoTurnos)
        {
            dgw_Turnos.Columns.Clear();
            dgw_Turnos.Rows.Clear();
            dgw_Turnos.DataSource = null; //legajo nombre, apellido, nroDocumento.ToString(), correoInsti, correoPersonal, telefono. fechaHoraInicio fechaHoraFin
            dgw_Turnos.Columns.Add("legajo", "N°Legajo");
            dgw_Turnos.Columns.Add("nombre", "Nombre");
            dgw_Turnos.Columns.Add("apellido", "Apellido");
            dgw_Turnos.Columns.Add("nroDocumento", "N°Doc.");
            dgw_Turnos.Columns.Add("correoInsti", "Mail Institucional");
            dgw_Turnos.Columns.Add("correoPersonal", "Mail Personal");
            dgw_Turnos.Columns.Add("telefono", "Telefono");
            dgw_Turnos.Columns.Add("fechaHoraInicio", "Hrs. Inicio Turno");
            dgw_Turnos.Columns.Add("fechaHoraFin", "Hrs. Fin Turno");

            for (int fila = 0; fila < infoTurnos.Count; fila++)
            {
                dgw_Turnos.Rows.Add(infoTurnos[fila]);
            }

        }

        private void dtp_fechaFinPrevista_ValueChanged(object sender, EventArgs e)
        {
            controlador.RazonYFechaFinPrevistaIngresada(txt_RazonIngreso.Text, dtp_fechaFinPrevista.Value.ToString());
        }
    }
}
