
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxRTCargaMotivo = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_fechaFinPrevista = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_RazonIngreso = new System.Windows.Forms.TextBox();
            this.dgw_RTDisponibles = new System.Windows.Forms.DataGridView();
            this.groupBoxRTCargaMotivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_RTDisponibles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxRTCargaMotivo
            // 
            this.groupBoxRTCargaMotivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRTCargaMotivo.Controls.Add(this.dgw_RTDisponibles);
            this.groupBoxRTCargaMotivo.Controls.Add(this.label7);
            this.groupBoxRTCargaMotivo.Controls.Add(this.label6);
            this.groupBoxRTCargaMotivo.Controls.Add(this.dtp_fechaFinPrevista);
            this.groupBoxRTCargaMotivo.Controls.Add(this.label5);
            this.groupBoxRTCargaMotivo.Controls.Add(this.label4);
            this.groupBoxRTCargaMotivo.Controls.Add(this.label3);
            this.groupBoxRTCargaMotivo.Controls.Add(this.label2);
            this.groupBoxRTCargaMotivo.Controls.Add(this.txt_RazonIngreso);
            this.groupBoxRTCargaMotivo.Location = new System.Drawing.Point(115, 4);
            this.groupBoxRTCargaMotivo.Name = "groupBoxRTCargaMotivo";
            this.groupBoxRTCargaMotivo.Size = new System.Drawing.Size(570, 443);
            this.groupBoxRTCargaMotivo.TabIndex = 7;
            this.groupBoxRTCargaMotivo.TabStop = false;
            this.groupBoxRTCargaMotivo.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Fecha Estimativa Fin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Motivo de Ingreso";
            // 
            // dtp_fechaFinPrevista
            // 
            this.dtp_fechaFinPrevista.CustomFormat = "dd MMMM yyyy";
            this.dtp_fechaFinPrevista.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_fechaFinPrevista.Location = new System.Drawing.Point(141, 125);
            this.dtp_fechaFinPrevista.Name = "dtp_fechaFinPrevista";
            this.dtp_fechaFinPrevista.Size = new System.Drawing.Size(156, 20);
            this.dtp_fechaFinPrevista.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Modelo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Numero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo RT";
            // 
            // txt_RazonIngreso
            // 
            this.txt_RazonIngreso.Location = new System.Drawing.Point(141, 94);
            this.txt_RazonIngreso.Name = "txt_RazonIngreso";
            this.txt_RazonIngreso.Size = new System.Drawing.Size(156, 20);
            this.txt_RazonIngreso.TabIndex = 0;
            // 
            // dgw_RTDisponibles
            // 
            this.dgw_RTDisponibles.AllowUserToAddRows = false;
            this.dgw_RTDisponibles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw_RTDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw_RTDisponibles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgw_RTDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_RTDisponibles.Location = new System.Drawing.Point(6, 176);
            this.dgw_RTDisponibles.Name = "dgw_RTDisponibles";
            this.dgw_RTDisponibles.RowHeadersVisible = false;
            this.dgw_RTDisponibles.Size = new System.Drawing.Size(558, 212);
            this.dgw_RTDisponibles.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxRTCargaMotivo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxRTCargaMotivo.ResumeLayout(false);
            this.groupBoxRTCargaMotivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_RTDisponibles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRTCargaMotivo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_fechaFinPrevista;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_RazonIngreso;
        private System.Windows.Forms.DataGridView dgw_RTDisponibles;
    }
}