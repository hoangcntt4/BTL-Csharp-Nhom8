
namespace BTL_Csharp_Nhom8
{
    partial class frmPrint
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
            this.components = new System.ComponentModel.Container();
            this.reportPanel1 = new Microsoft.Reporting.WinForms.ReportPanel();
            this.reportToolBar1 = new Microsoft.Reporting.WinForms.ReportToolBar();
            this.dgv_SPChay = new System.Windows.Forms.DataGridView();
            this.masp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tensp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluonbanra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SPChay)).BeginInit();
            this.SuspendLayout();
            // 
            // reportPanel1
            // 
            this.reportPanel1.AutoScroll = true;
            this.reportPanel1.Controls.Add(this.dgv_SPChay);
            this.reportPanel1.Controls.Add(this.reportToolBar1);
            this.reportPanel1.CurrentPage = null;
            this.reportPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportPanel1.Location = new System.Drawing.Point(0, 0);
            this.reportPanel1.Name = "reportPanel1";
            this.reportPanel1.ShowContextMenu = true;
            this.reportPanel1.Size = new System.Drawing.Size(1199, 450);
            this.reportPanel1.TabIndex = 0;
            this.reportPanel1.ViewerControl = null;
            // 
            // reportToolBar1
            // 
            this.reportToolBar1.BackColor = System.Drawing.SystemColors.Control;
            this.reportToolBar1.Location = new System.Drawing.Point(0, 0);
            this.reportToolBar1.MaximumSize = new System.Drawing.Size(1199, 25);
            this.reportToolBar1.MinimumSize = new System.Drawing.Size(1199, 25);
            this.reportToolBar1.Name = "reportToolBar1";
            this.reportToolBar1.Size = new System.Drawing.Size(1199, 25);
            this.reportToolBar1.TabIndex = 1;
            // 
            // dgv_SPChay
            // 
            this.dgv_SPChay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SPChay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.masp,
            this.tensp,
            this.soluonbanra});
            this.dgv_SPChay.Location = new System.Drawing.Point(291, 132);
            this.dgv_SPChay.Name = "dgv_SPChay";
            this.dgv_SPChay.RowTemplate.Height = 25;
            this.dgv_SPChay.Size = new System.Drawing.Size(569, 150);
            this.dgv_SPChay.TabIndex = 2;
            // 
            // masp
            // 
            this.masp.HeaderText = "Mã sản phẩm";
            this.masp.Name = "masp";
            this.masp.Width = 175;
            // 
            // tensp
            // 
            this.tensp.HeaderText = "Tên sản phẩm";
            this.tensp.Name = "tensp";
            this.tensp.Width = 175;
            // 
            // soluonbanra
            // 
            this.soluonbanra.HeaderText = "Số lượng bán ra";
            this.soluonbanra.Name = "soluonbanra";
            this.soluonbanra.Width = 175;
            // 
            // frmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 450);
            this.Controls.Add(this.reportPanel1);
            this.Name = "frmPrint";
            this.Text = "frmPrint";
            this.Load += new System.EventHandler(this.frmPrint_Load);
            this.reportPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SPChay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_SPChay;
        private System.Windows.Forms.DataGridViewTextBoxColumn masp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tensp;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluonbanra;
        private ReportPanel reportPanel1;
        private ReportToolBar reportToolBar1;
    }
}