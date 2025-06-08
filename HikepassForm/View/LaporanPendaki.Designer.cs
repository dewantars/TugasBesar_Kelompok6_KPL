namespace HikepassForm.View
{
    partial class LaporanPendaki
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
            labelJudul = new Label();
            labelDeskripsi = new Label();
            textBoxDeskripsi = new TextBox();
            labelLokasi = new Label();
            textBoxLokasi = new TextBox();
            labelKeparahan = new Label();
            comboBoxKeparahan = new ComboBox();
            buttonKirim = new Button();
            buttonBack = new Button();
            SuspendLayout();
            // 
            // labelJudul
            // 
            labelJudul.AutoSize = true;
            labelJudul.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelJudul.Location = new Point(309, 14);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(257, 48);
            labelJudul.TabIndex = 0;
            labelJudul.Text = "Input Laporan";
            labelJudul.Click += labelJudul_Click;
            // 
            // labelDeskripsi
            // 
            labelDeskripsi.AutoSize = true;
            labelDeskripsi.Location = new Point(33, 124);
            labelDeskripsi.Name = "labelDeskripsi";
            labelDeskripsi.Size = new Size(153, 25);
            labelDeskripsi.TabIndex = 1;
            labelDeskripsi.Text = "Deskripsi Laporan";
            labelDeskripsi.Click += labelDeskripsi_Click;
            // 
            // textBoxDeskripsi
            // 
            textBoxDeskripsi.Location = new Point(203, 119);
            textBoxDeskripsi.Name = "textBoxDeskripsi";
            textBoxDeskripsi.Size = new Size(400, 31);
            textBoxDeskripsi.TabIndex = 2;
            textBoxDeskripsi.TextChanged += textBoxDeskripsi_TextChanged;
            // 
            // labelLokasi
            // 
            labelLokasi.AutoSize = true;
            labelLokasi.Location = new Point(33, 174);
            labelLokasi.Name = "labelLokasi";
            labelLokasi.Size = new Size(98, 25);
            labelLokasi.TabIndex = 3;
            labelLokasi.Text = "Titik Lokasi";
            labelLokasi.Click += labelLokasi_Click;
            // 
            // textBoxLokasi
            // 
            textBoxLokasi.Location = new Point(203, 169);
            textBoxLokasi.Name = "textBoxLokasi";
            textBoxLokasi.Size = new Size(400, 31);
            textBoxLokasi.TabIndex = 4;
            textBoxLokasi.TextChanged += textBoxLokasi_TextChanged;
            // 
            // labelKeparahan
            // 
            labelKeparahan.AutoSize = true;
            labelKeparahan.Location = new Point(33, 224);
            labelKeparahan.Name = "labelKeparahan";
            labelKeparahan.Size = new Size(158, 25);
            labelKeparahan.TabIndex = 5;
            labelKeparahan.Text = "Tingkat Keparahan";
            labelKeparahan.Click += labelKeparahan_Click;
            // 
            // comboBoxKeparahan
            // 
            comboBoxKeparahan.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxKeparahan.Items.AddRange(new object[] { "Ringan", "Sedang", "Berat" });
            comboBoxKeparahan.Location = new Point(203, 219);
            comboBoxKeparahan.Name = "comboBoxKeparahan";
            comboBoxKeparahan.Size = new Size(200, 33);
            comboBoxKeparahan.TabIndex = 6;
            comboBoxKeparahan.SelectedIndexChanged += comboBoxKeparahan_SelectedIndexChanged;
            // 
            // buttonKirim
            // 
            buttonKirim.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            buttonKirim.Location = new Point(338, 300);
            buttonKirim.Name = "buttonKirim";
            buttonKirim.Size = new Size(150, 40);
            buttonKirim.TabIndex = 7;
            buttonKirim.Text = "Kirim Laporan";
            buttonKirim.Click += buttonKirim_Click;
            // 
            // buttonBack
            // 
            buttonBack.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            buttonBack.Location = new Point(33, 31);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(100, 30);
            buttonBack.TabIndex = 23;
            buttonBack.Text = "Kembali";
            buttonBack.Click += buttonBack_Click;
            // 
            // LaporanPendaki
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonBack);
            Controls.Add(labelJudul);
            Controls.Add(labelDeskripsi);
            Controls.Add(textBoxDeskripsi);
            Controls.Add(labelLokasi);
            Controls.Add(textBoxLokasi);
            Controls.Add(labelKeparahan);
            Controls.Add(comboBoxKeparahan);
            Controls.Add(buttonKirim);
            Name = "LaporanPendaki";
            Size = new Size(852, 494);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelJudul;
        private System.Windows.Forms.Label labelDeskripsi;
        private System.Windows.Forms.TextBox textBoxDeskripsi;
        private System.Windows.Forms.Label labelLokasi;
        private System.Windows.Forms.TextBox textBoxLokasi;
        private System.Windows.Forms.Label labelKeparahan;
        private System.Windows.Forms.ComboBox comboBoxKeparahan;
        private System.Windows.Forms.Button buttonKirim;
        private Button buttonBack;
    }
}
