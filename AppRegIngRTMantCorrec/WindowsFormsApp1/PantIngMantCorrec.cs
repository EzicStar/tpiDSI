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

            ControladorIngresoMantCorrectivo controlador = new ControladorIngresoMantCorrectivo();
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
            if (dgw_Turnos.CurrentRow != null)
            {
                this.groupBoxRTShow.Visible = false;
                this.groupBoxRTCargaMotivo.Visible = true;
            }
            else
                MessageBox.Show("No se seleccionó NADA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //saber cuando cambie el valor, deba
            //cargar la grilla con los turnos de esa fecha
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            if (this.txt_RazonIngreso.Text.Trim() == "")
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

        private void groupBoxRTCargaMotivo_Enter(object sender, EventArgs e)
        {
            this.lbl_tipoRt.Text = dgw_RTDisponibles.Rows[0].Cells[1].ToString();
            this.lbl_numRt.Text = dgw_RTDisponibles.Rows[0].Cells[2].ToString();
            this.lbl_marcaRt.Text = dgw_RTDisponibles.Rows[0].Cells[3].ToString();
            this.lbl_modeloRt.Text = dgw_RTDisponibles.Rows[0].Cells[4].ToString();
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
    }
}
