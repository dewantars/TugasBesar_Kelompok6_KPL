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
            btnLogout.Location = new Point(740, 28);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 17;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 107);
            label1.Name = "label1";
            label1.Size = new Size(192, 20);
            label1.TabIndex = 16;
            label1.Text = "Selamat Datang, Pengelola!";
            label1.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("BD Cartoon Shout", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(39, 59);
            label3.Name = "label3";
            label3.Size = new Size(196, 33);
            label3.TabIndex = 15;
            label3.Text = "HikePass";
            // 
            // btnMonitoring
            // 
            btnMonitoring.Location = new Point(39, 170);
            btnMonitoring.Name = "btnMonitoring";
            btnMonitoring.Size = new Size(171, 50);
            btnMonitoring.TabIndex = 18;
            btnMonitoring.Text = "Monitoring";
            btnMonitoring.UseVisualStyleBackColor = true;
            // 
            // btnEditInform
            // 
            btnEditInform.Location = new Point(235, 170);
            btnEditInform.Name = "btnEditInform";
            btnEditInform.Size = new Size(171, 50);
            btnEditInform.TabIndex = 19;
            btnEditInform.Text = "Edit Informasi";
            btnEditInform.UseVisualStyleBackColor = true;
            // 
            // btnLhtLaporan
            // 
            btnLhtLaporan.Location = new Point(39, 244);
            btnLhtLaporan.Name = "btnLhtLaporan";
            btnLhtLaporan.Size = new Size(171, 50);
            btnLhtLaporan.TabIndex = 20;
            btnLhtLaporan.Text = "Lihat Laporan";
            btnLhtLaporan.UseVisualStyleBackColor = true;
            // 
            // btnLhtRiwayat
            // 
            btnLhtRiwayat.Location = new Point(235, 244);
            btnLhtRiwayat.Name = "btnLhtRiwayat";
            btnLhtRiwayat.Size = new Size(171, 50);
            btnLhtRiwayat.TabIndex = 21;
            btnLhtRiwayat.Text = "Lihat Riwayat";
            btnLhtRiwayat.UseVisualStyleBackColor = true;
            // 
            // DashboardPengelola
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLhtRiwayat);
            Controls.Add(btnLhtLaporan);
            Controls.Add(btnEditInform);
            Controls.Add(btnMonitoring);
            Controls.Add(btnLogout);
            Controls.Add(label1);
            Controls.Add(label3);
            Name = "DashboardPengelola";
            Size = new Size(852, 494);
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
