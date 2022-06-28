using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
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
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //invisibiliza todo
            this.groupBoxRTShow.Visible = false;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            this.groupBoxRTShow.Visible = false;
            this.groupBoxRTCargaMotivo.Visible = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //saber cuando cambie el valor, deba cargar la grilla con los turnos de esa fecha
        }
    }
}
