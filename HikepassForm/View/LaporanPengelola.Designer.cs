namespace HikepassForm.View
{
    partial class LaporanPengelola
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) 
        {
            if (disposing && (components != null)) 
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
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
            labelJudul.Click += labelJudul_Click;
  
            // listViewLaporan
            listViewLaporan.Columns.AddRange(new ColumnHeader[] { columnID, columnWaktu, columnDeskripsi, columnLokasi, columnKeparahan });
            listViewLaporan.FullRowSelect = true;
            listViewLaporan.GridLines = true;
            listViewLaporan.Location = new Point(56, 80);
            listViewLaporan.Name = "listViewLaporan";
            listViewLaporan.Size = new Size(914, 397);
            listViewLaporan.TabIndex = 1;
            listViewLaporan.UseCompatibleStateImageBehavior = false;
            listViewLaporan.View = System.Windows.Forms.View.Details;
            listViewLaporan.SelectedIndexChanged += listViewLaporan_SelectedIndexChanged;

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

            // LaporanPengelola
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonBack);
            Controls.Add(labelJudul);
            Controls.Add(listViewLaporan);
            Name = "LaporanPengelola";
            Size = new Size(1000, 544);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
