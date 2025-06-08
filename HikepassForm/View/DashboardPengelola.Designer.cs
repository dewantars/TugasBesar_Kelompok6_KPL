namespace HikepassForm.View
{
    partial class DashboardPengelola
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
            btnLogout = new Button();
            label1 = new Label();
            label3 = new Label();
            btnMonitoring = new Button();
            btnEditInform = new Button();
            btnLhtLaporan = new Button();
            btnLhtRiwayat = new Button();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(925, 35);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(118, 36);
            btnLogout.TabIndex = 17;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 134);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(228, 25);
            label1.TabIndex = 16;
            label1.Text = "Selamat Datang, Pengelola!";
            label1.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(49, 74);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(169, 40);
            label3.TabIndex = 15;
            label3.Text = "HikePass";
            // 
            // btnMonitoring
            // 
            btnMonitoring.Location = new Point(49, 212);
            btnMonitoring.Margin = new Padding(4);
            btnMonitoring.Name = "btnMonitoring";
            btnMonitoring.Size = new Size(214, 62);
            btnMonitoring.TabIndex = 18;
            btnMonitoring.Text = "Monitoring";
            btnMonitoring.UseVisualStyleBackColor = true;
            // 
            // btnEditInform
            // 
            btnEditInform.Location = new Point(294, 212);
            btnEditInform.Margin = new Padding(4);
            btnEditInform.Name = "btnEditInform";
            btnEditInform.Size = new Size(214, 62);
            btnEditInform.TabIndex = 19;
            btnEditInform.Text = "Edit Informasi";
            btnEditInform.UseVisualStyleBackColor = true;
            // 
            // btnLhtLaporan
            // 
            btnLhtLaporan.Location = new Point(49, 305);
            btnLhtLaporan.Margin = new Padding(4);
            btnLhtLaporan.Name = "btnLhtLaporan";
            btnLhtLaporan.Size = new Size(214, 62);
            btnLhtLaporan.TabIndex = 20;
            btnLhtLaporan.Text = "Lihat Laporan";
            btnLhtLaporan.UseVisualStyleBackColor = true;
            btnLhtLaporan.Click += btnLhtLaporan_Click;
            // 
            // btnLhtRiwayat
            // 
            btnLhtRiwayat.Location = new Point(294, 305);
            btnLhtRiwayat.Margin = new Padding(4);
            btnLhtRiwayat.Name = "btnLhtRiwayat";
            btnLhtRiwayat.Size = new Size(214, 62);
            btnLhtRiwayat.TabIndex = 21;
            btnLhtRiwayat.Text = "Lihat Riwayat";
            btnLhtRiwayat.UseVisualStyleBackColor = true;
            // 
            // DashboardPengelola
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLhtRiwayat);
            Controls.Add(btnLhtLaporan);
            Controls.Add(btnEditInform);
            Controls.Add(btnMonitoring);
            Controls.Add(btnLogout);
            Controls.Add(label1);
            Controls.Add(label3);
            Margin = new Padding(4);
            Name = "DashboardPengelola";
            Size = new Size(1065, 618);
            Load += DashboardPengelola_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogout;
        private Label label1;
        private Label label3;
        private Button btnMonitoring;
        private Button btnEditInform;
        private Button btnLhtLaporan;
        private Button btnLhtRiwayat;
    }
}
