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
            btnLogout = new Button();
            btnLaporan = new Button();
            btnCheckIndanCheckOut = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(36, 34);
            label3.Name = "label3";
            label3.Size = new Size(115, 29);
            label3.TabIndex = 8;
            label3.Text = "HikePass";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 70);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 9;
            label1.Text = "Selamat Datang, User!";
            // 
            // btnRsv
            // 
            btnRsv.Location = new Point(51, 198);
            btnRsv.Margin = new Padding(4);
            btnRsv.Name = "btnRsv";
            btnRsv.Size = new Size(150, 37);
            btnRsv.TabIndex = 10;
            btnRsv.Text = "Reservasi";
            btnRsv.UseVisualStyleBackColor = true;
            btnRsv.Click += btnRsv_Click;
            // 
            // btnTkt
            // 
            btnTkt.Location = new Point(51, 292);
            btnTkt.Margin = new Padding(4);
            btnTkt.Name = "btnTkt";
            btnTkt.Size = new Size(150, 37);
            btnTkt.TabIndex = 11;
            btnTkt.Text = "Tiket Saya";
            btnTkt.UseVisualStyleBackColor = true;
            btnTkt.Click += btnTkt_Click;
            // 
            // btnInf
            // 
            btnInf.Location = new Point(310, 198);
            btnInf.Margin = new Padding(4);
            btnInf.Name = "btnInf";
            btnInf.Size = new Size(150, 37);
            btnInf.TabIndex = 12;
            btnInf.Text = "Lihat Informasi";
            btnInf.UseVisualStyleBackColor = true;
            btnInf.Click += btnInf_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(928, 18);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(83, 22);
            btnLogout.TabIndex = 14;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnLaporan
            // 
            btnLaporan.Location = new Point(310, 292);
            btnLaporan.Margin = new Padding(4);
            btnLaporan.Name = "btnLaporan";
            btnLaporan.Size = new Size(150, 37);
            btnLaporan.TabIndex = 15;
            btnLaporan.Text = "Input Laporan";
            btnLaporan.UseVisualStyleBackColor = true;
            btnLaporan.Click += btnLaporan_Click;
            // 
            // btnCheckIndanCheckOut
            // 
            btnCheckIndanCheckOut.Location = new Point(0, 0);
            btnCheckIndanCheckOut.Name = "btnCheckIndanCheckOut";
            btnCheckIndanCheckOut.Size = new Size(75, 23);
            btnCheckIndanCheckOut.TabIndex = 0;
            // 
            // DashboardPendaki
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnCheckIndanCheckOut);
            Controls.Add(btnLaporan);
            Controls.Add(btnLogout);
            Controls.Add(btnInf);
            Controls.Add(btnTkt);
            Controls.Add(btnRsv);
            Controls.Add(label1);
            Controls.Add(label3);
            Margin = new Padding(4);
            Name = "DashboardPendaki";
            Size = new Size(1050, 625);
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
        private Button btnLogout;
        private Button btnLaporan;
        private Button btnCheckIndanCheckOut;
    }
}
