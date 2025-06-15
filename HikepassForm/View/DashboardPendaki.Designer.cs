namespace HikepassForm
{
    partial class DashboardPendaki
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label3 = new Label();
            label1 = new Label();
            btnRsv = new Button();
            btnTkt = new Button();
            btnInf = new Button();
            btnLaporan = new Button();
            btnLO = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(41, 45);
            label3.Name = "label3";
            label3.Size = new Size(140, 36);
            label3.TabIndex = 8;
            label3.Text = "HikePass";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 93);
            label1.Name = "label1";
            label1.Size = new Size(156, 20);
            label1.TabIndex = 9;
            label1.Text = "Selamat Datang, User!";
            // 
            // btnRsv
            // 
            btnRsv.Location = new Point(58, 178);
            btnRsv.Margin = new Padding(5);
            btnRsv.Name = "btnRsv";
            btnRsv.Size = new Size(171, 49);
            btnRsv.TabIndex = 10;
            btnRsv.Text = "Reservasi";
            btnRsv.UseVisualStyleBackColor = true;
            btnRsv.Click += btnRsv_Click;
            // 
            // btnTkt
            // 
            btnTkt.Location = new Point(58, 264);
            btnTkt.Margin = new Padding(5);
            btnTkt.Name = "btnTkt";
            btnTkt.Size = new Size(171, 49);
            btnTkt.TabIndex = 11;
            btnTkt.Text = "Tiket Saya";
            btnTkt.UseVisualStyleBackColor = true;
            btnTkt.Click += btnTkt_Click;
            // 
            // btnInf
            // 
            btnInf.Location = new Point(354, 178);
            btnInf.Margin = new Padding(5);
            btnInf.Name = "btnInf";
            btnInf.Size = new Size(171, 49);
            btnInf.TabIndex = 12;
            btnInf.Text = "Lihat Informasi";
            btnInf.UseVisualStyleBackColor = true;
            btnInf.Click += btnInf_Click;
            // 
            // btnLaporan
            // 
            btnLaporan.Location = new Point(354, 264);
            btnLaporan.Margin = new Padding(5);
            btnLaporan.Name = "btnLaporan";
            btnLaporan.Size = new Size(171, 49);
            btnLaporan.TabIndex = 15;
            btnLaporan.Text = "Input Laporan";
            btnLaporan.UseVisualStyleBackColor = true;
            btnLaporan.Click += btnLaporan_Click;
            // 
            // btnLO
            // 
            btnLO.Location = new Point(725, 45);
            btnLO.Margin = new Padding(3, 4, 3, 4);
            btnLO.Name = "btnLO";
            btnLO.Size = new Size(103, 31);
            btnLO.TabIndex = 0;
            btnLO.Text = "LogOut";
            btnLO.Click += btnLO_Click;
            // 
            // DashboardPendaki
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLO);
            Controls.Add(btnLaporan);
            Controls.Add(btnInf);
            Controls.Add(btnTkt);
            Controls.Add(btnRsv);
            Controls.Add(label1);
            Controls.Add(label3);
            Margin = new Padding(5);
            Name = "DashboardPendaki";
            Size = new Size(852, 494);
            Load += DashboardPendaki_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label1;
        private Button btnRsv;
        private Button btnTkt;
        private Button btnInf;
        private Button btnLaporan;
        private Button btnLO;
    }
}
