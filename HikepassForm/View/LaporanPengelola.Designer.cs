namespace HikepassForm.View
{
    partial class LaporanPengelola
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
            // Clean code: memastikan komponen dibersihkan saat form ditutup
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
            listViewLaporan = new ListView();
            columnID = new ColumnHeader();
            columnWaktu = new ColumnHeader();
            columnDeskripsi = new ColumnHeader();
            columnLokasi = new ColumnHeader();
            columnKeparahan = new ColumnHeader();
            buttonBack = new Button();
            SuspendLayout();

            // labelJudul
            labelJudul.AutoSize = true;
            labelJudul.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelJudul.Location = new Point(248, 12);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(395, 48);
            labelJudul.TabIndex = 0;
            labelJudul.Text = "Daftar Laporan Masuk";
            // Clean code: Penempatan label judul di atas UI, ukuran besar untuk hierarki visual

            // listViewLaporan
            listViewLaporan.Columns.AddRange(new ColumnHeader[]
            {
                columnID, columnWaktu, columnDeskripsi, columnLokasi, columnKeparahan
            });
            listViewLaporan.FullRowSelect = true;
            listViewLaporan.GridLines = true;
            listViewLaporan.Location = new Point(56, 80);
            listViewLaporan.Name = "listViewLaporan";
            listViewLaporan.Size = new Size(756, 380);
            listViewLaporan.TabIndex = 1;
            listViewLaporan.UseCompatibleStateImageBehavior = false;
            listViewLaporan.View = System.Windows.Forms.View.Details;
            listViewLaporan.SelectedIndexChanged += listViewLaporan_SelectedIndexChanged;
            // Clean code: Properti UI ditulis lengkap dan konsisten
            // Secure coding: FullRowSelect dan GridLines membantu keterbacaan dan pemilihan aman

            // columnID
            columnID.Text = "ID";
            columnID.Width = 150;

            // columnWaktu
            columnWaktu.Text = "Waktu";
            columnWaktu.Width = 160;

            // columnDeskripsi
            columnDeskripsi.Text = "Deskripsi";
            columnDeskripsi.Width = 200;

            // columnLokasi
            columnLokasi.Text = "Lokasi";
            columnLokasi.Width = 120;

            // columnKeparahan
            columnKeparahan.Text = "Keparahan";
            columnKeparahan.Width = 120;

            // buttonBack
            buttonBack.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            buttonBack.Location = new Point(56, 30);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(100, 30);
            buttonBack.TabIndex = 24;
            buttonBack.Text = "Kembali";
            buttonBack.Click += buttonBack_Click;
            // Clean code: tombol kembali mudah dijangkau di kiri atas

            // LaporanPengelola
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonBack);
            Controls.Add(labelJudul);
            Controls.Add(listViewLaporan);
            Name = "LaporanPengelola";
            Size = new Size(852, 494);
            ResumeLayout(false);
            PerformLayout();
            // Clean code: struktur UI jelas, komponen utama ditambahkan sebelum layout selesai
        }

        #endregion

        // Clean code: deklarasi komponen UI dilakukan konsisten setelah region
        private System.Windows.Forms.Label labelJudul;
        private System.Windows.Forms.ListView listViewLaporan;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnWaktu;
        private System.Windows.Forms.ColumnHeader columnDeskripsi;
        private System.Windows.Forms.ColumnHeader columnLokasi;
        private System.Windows.Forms.ColumnHeader columnKeparahan;
        private Button buttonBack;
    }
}
