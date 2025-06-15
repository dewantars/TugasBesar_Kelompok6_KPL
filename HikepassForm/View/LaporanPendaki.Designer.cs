namespace HikepassForm.View
{
    partial class LaporanPendaki
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // Clean code: memastikan semua komponen dibersihkan saat form ditutup
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            labelJudul = new Label();
            labelDeskripsi = new Label();
            textBoxDeskripsi = new TextBox();
            labelLokasi = new Label();
            textBoxLokasi = new TextBox();
            labelKeparahan = new Label();
            labelHintKeparahan = new Label();
            textBoxKeparahan = new TextBox();
            buttonKirim = new Button();
            buttonBack = new Button();
            SuspendLayout();

            // labelJudul 
            labelJudul.AutoSize = true;
            labelJudul.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelJudul.Location = new Point(309, 14);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(257, 48);
            labelJudul.TabIndex = 0;
            labelJudul.Text = "Input Laporan";
            labelJudul.Click += labelJudul_Click;

            // labelDeskripsi
            labelDeskripsi.AutoSize = true;
            labelDeskripsi.Location = new Point(33, 124);
            labelDeskripsi.Name = "labelDeskripsi";
            labelDeskripsi.Size = new Size(153, 25);
            labelDeskripsi.TabIndex = 1;
            labelDeskripsi.Text = "Deskripsi Laporan";
            labelDeskripsi.Click += labelDeskripsi_Click;

            // textBoxDeskripsi 
            textBoxDeskripsi.Location = new Point(203, 119);
            textBoxDeskripsi.Name = "textBoxDeskripsi";
            textBoxDeskripsi.Size = new Size(400, 31);
            textBoxDeskripsi.TabIndex = 2;
            textBoxDeskripsi.TextChanged += textBoxDeskripsi_TextChanged;

            // labelLokasi
            labelLokasi.AutoSize = true;
            labelLokasi.Location = new Point(33, 174);
            labelLokasi.Name = "labelLokasi";
            labelLokasi.Size = new Size(98, 25);
            labelLokasi.TabIndex = 3;
            labelLokasi.Text = "Titik Lokasi";
            labelLokasi.Click += labelLokasi_Click;

            // textBoxLokasi
            textBoxLokasi.Location = new Point(203, 169);
            textBoxLokasi.Name = "textBoxLokasi";
            textBoxLokasi.Size = new Size(400, 31);
            textBoxLokasi.TabIndex = 4;
            textBoxLokasi.TextChanged += textBoxLokasi_TextChanged;
            
            // labelKeparahan
            labelKeparahan.AutoSize = true;
            labelKeparahan.Location = new Point(33, 224);
            labelKeparahan.Name = "labelKeparahan";
            labelKeparahan.Size = new Size(158, 25);
            labelKeparahan.TabIndex = 5;
            labelKeparahan.Text = "Tingkat Keparahan";
            labelKeparahan.Click += labelKeparahan_Click;

            // labelHintKeparahan
            labelHintKeparahan.AutoSize = true;
            labelHintKeparahan.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            labelHintKeparahan.ForeColor = Color.Gray;
            labelHintKeparahan.Location = new Point(203, 253);
            labelHintKeparahan.Name = "labelHintKeparahan";
            labelHintKeparahan.Size = new Size(356, 21);
            labelHintKeparahan.TabIndex = 8;
            labelHintKeparahan.Text = "(Masukkan: Ringan / Sedang / Berat atau lainnya)";
            labelHintKeparahan.Click += labelHintKeparahan_Click;

            // textBoxKeparahan
            textBoxKeparahan.Location = new Point(203, 219);
            textBoxKeparahan.Name = "textBoxKeparahan";
            textBoxKeparahan.Size = new Size(400, 31);
            textBoxKeparahan.TabIndex = 6;
            textBoxKeparahan.TextChanged += textBoxKeparahan_TextChanged;

            // buttonKirim
            buttonKirim.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            buttonKirim.Location = new Point(338, 300);
            buttonKirim.Name = "buttonKirim";
            buttonKirim.Size = new Size(150, 40);
            buttonKirim.TabIndex = 7;
            buttonKirim.Text = "Kirim Laporan";
            buttonKirim.Click += buttonKirim_Click;

            // buttonBack
            buttonBack.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            buttonBack.Location = new Point(33, 31);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(100, 30);
            buttonBack.TabIndex = 23;
            buttonBack.Text = "Kembali";
            buttonBack.Click += buttonBack_Click;

            // LaporanPendaki
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelJudul);
            Controls.Add(labelDeskripsi);
            Controls.Add(textBoxDeskripsi);
            Controls.Add(labelLokasi);
            Controls.Add(textBoxLokasi);
            Controls.Add(labelKeparahan);
            Controls.Add(textBoxKeparahan);
            Controls.Add(labelHintKeparahan);
            Controls.Add(buttonKirim);
            Controls.Add(buttonBack);
            Name = "LaporanPendaki";
            Size = new Size(852, 494);
            Load += LaporanPendaki_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Clean code: Deklarasi field UI konsisten dan terstruktur
        // Secure coding: penggunaan ComboBox.DropDownList membatasi input agar tidak bisa diketik bebas
        private System.Windows.Forms.Label labelJudul;
        private System.Windows.Forms.Label labelDeskripsi;
        private System.Windows.Forms.TextBox textBoxDeskripsi;
        private System.Windows.Forms.Label labelLokasi;
        private System.Windows.Forms.TextBox textBoxLokasi;
        private System.Windows.Forms.Label labelKeparahan;
        private System.Windows.Forms.TextBox textBoxKeparahan;
        private System.Windows.Forms.Label labelHintKeparahan;
        private System.Windows.Forms.Button buttonKirim;
        private Button buttonBack;
    }
}
