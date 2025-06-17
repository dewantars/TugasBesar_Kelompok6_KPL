namespace HikepassForm.View
{
    partial class InformasiPengelola
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
            labelInformasi = new Label();
            labelTampilkanInformasi = new Label();
            textBoxKategori = new TextBox();
            buttonTampilkan = new Button();
            labelInformasiPengelola = new Label();
            labelEditInformasi = new Label();
            textBoxYorN = new TextBox();
            buttonEdit = new Button();
            labelEditJudul = new Label();
            textBoxJudul = new TextBox();
            labelEditDeskripsi = new Label();
            textBoxDeskripsi = new TextBox();
            buttonSimpan = new Button();
            buttonKembali = new Button();
            SuspendLayout();
            // 
            // labelInformasi
            // 
            labelInformasi.AutoSize = true;
            labelInformasi.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelInformasi.Location = new Point(334, 15);
            labelInformasi.Name = "labelInformasi";
            labelInformasi.Size = new Size(181, 48);
            labelInformasi.TabIndex = 0;
            labelInformasi.Text = "Informasi";
            labelInformasi.Click += labelInformasi_Click;
            // 
            // labelTampilkanInformasi
            // 
            labelTampilkanInformasi.AutoSize = true;
            labelTampilkanInformasi.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTampilkanInformasi.Location = new Point(30, 78);
            labelTampilkanInformasi.Name = "labelTampilkanInformasi";
            labelTampilkanInformasi.Size = new Size(475, 25);
            labelTampilkanInformasi.TabIndex = 1;
            labelTampilkanInformasi.Text = "Masukkan kategori (Peraturan / Tips / Umum):";
            labelTampilkanInformasi.Click += labelTampilkanInformasi_Click;
            // 
            // textBoxKategori
            // 
            textBoxKategori.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxKategori.Location = new Point(526, 78);
            textBoxKategori.Name = "textBoxKategori";
            textBoxKategori.Size = new Size(150, 31);
            textBoxKategori.TabIndex = 2;
            textBoxKategori.TextChanged += textBoxKategori_TextChanged;
            // 
            // buttonTampilkan
            // 
            buttonTampilkan.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonTampilkan.Location = new Point(697, 78);
            buttonTampilkan.Name = "buttonTampilkan";
            buttonTampilkan.Size = new Size(110, 34);
            buttonTampilkan.TabIndex = 3;
            buttonTampilkan.Text = "Tampilkan";
            buttonTampilkan.UseVisualStyleBackColor = true;
            buttonTampilkan.Click += buttonTampilkan_Click;
            // 
            // labelInformasiPengelola
            // 
            labelInformasiPengelola.AutoSize = true;
            labelInformasiPengelola.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelInformasiPengelola.Location = new Point(30, 118);
            labelInformasiPengelola.Name = "labelInformasiPengelola";
            labelInformasiPengelola.Size = new Size(0, 25);
            labelInformasiPengelola.TabIndex = 4;
            labelInformasiPengelola.Click += labelInformasiPengelola_Click;
            // 
            // labelEditInformasi
            // 
            labelEditInformasi.AutoSize = true;
            labelEditInformasi.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEditInformasi.Location = new Point(30, 268);
            labelEditInformasi.Name = "labelEditInformasi";
            labelEditInformasi.Size = new Size(475, 25);
            labelEditInformasi.TabIndex = 1;
            labelEditInformasi.Text = "Apakah Anda ingin mengedit informasi kategori ini? (y/n):";
            labelEditInformasi.Click += labelEditInformasi_Click;
            // 
            // textBoxYorN
            // 
            textBoxYorN.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxYorN.Location = new Point(526, 268);
            textBoxYorN.Name = "textBoxYorN";
            textBoxYorN.Size = new Size(150, 31);
            textBoxYorN.TabIndex = 2;
            textBoxYorN.TextChanged += textBoxYorN_TextChanged;
            // 
            // buttonEdit
            // 
            buttonEdit.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonEdit.Location = new Point(697, 268);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(110, 34);
            buttonEdit.TabIndex = 3;
            buttonEdit.Text = "Kirim";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // labelEditJudul
            // 
            labelEditJudul.AutoSize = true;
            labelEditJudul.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEditJudul.Location = new Point(30, 313);
            labelEditJudul.Name = "labelEditJudul";
            labelEditJudul.Size = new Size(275, 25);
            labelEditJudul.TabIndex = 1;
            labelEditJudul.Text = "Masukkan judul:";
            labelEditJudul.Click += labelEditJudul_Click;
            // 
            // textBoxJudul
            // 
            textBoxJudul.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxJudul.Location = new Point(225, 318);
            textBoxJudul.Name = "textBoxJudul";
            textBoxJudul.Size = new Size(193, 31);
            textBoxJudul.TabIndex = 2;
            textBoxJudul.TextChanged += textBoxJudul_TextChanged;
            // 
            // labelEditDeskripsi
            // 
            labelEditDeskripsi.AutoSize = true;
            labelEditDeskripsi.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEditDeskripsi.Location = new Point(30, 358);
            labelEditDeskripsi.Name = "labelEditDeskripsi";
            labelEditDeskripsi.Size = new Size(275, 25);
            labelEditDeskripsi.TabIndex = 1;
            labelEditDeskripsi.Text = "Masukkan deskripsi:";
            labelEditDeskripsi.Click += labelEditDeskripsi_Click;
            // 
            // textBoxDeskripsi
            // 
            textBoxDeskripsi.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxDeskripsi.Location = new Point(225, 358);
            textBoxDeskripsi.Name = "textBoxDeskripsi";
            textBoxDeskripsi.Size = new Size(580, 31);
            textBoxDeskripsi.TabIndex = 2;
            textBoxDeskripsi.TextChanged += textBoxDeskripsi_TextChanged;
            // 
            // buttonSimpan
            // 
            buttonSimpan.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSimpan.Location = new Point(371, 403);
            buttonSimpan.Name = "buttonSimpan";
            buttonSimpan.Size = new Size(110, 34);
            buttonSimpan.TabIndex = 3;
            buttonSimpan.Text = "Simpan";
            buttonSimpan.UseVisualStyleBackColor = true;
            buttonSimpan.Click += buttonSimpan_Click;
            // 
            // buttonKembali
            // 
            buttonKembali.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonKembali.Location = new Point(30, 30);
            buttonKembali.Name = "buttonKembali";
            buttonKembali.Size = new Size(110, 34);
            buttonKembali.TabIndex = 5;
            buttonKembali.Text = "Kembali";
            buttonKembali.UseVisualStyleBackColor = true;
            buttonKembali.Click += buttonKembali_Click;
            // 
            // InformasiPengelola
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelInformasi);
            Controls.Add(labelTampilkanInformasi);
            Controls.Add(textBoxKategori);
            Controls.Add(buttonTampilkan);
            Controls.Add(labelInformasiPengelola);
            Controls.Add(labelEditInformasi);
            Controls.Add(textBoxYorN);
            Controls.Add(buttonEdit);
            Controls.Add(labelEditJudul);
            Controls.Add(textBoxJudul);
            Controls.Add(labelEditDeskripsi);
            Controls.Add(textBoxDeskripsi);
            Controls.Add(buttonSimpan);
            Controls.Add(buttonKembali);
            Name = "InformasiPengelola";
            Size = new Size(852, 494);
            Load += InformasiPengelola_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelInformasi;
        private Label labelTampilkanInformasi;
        private TextBox textBoxKategori;
        private Button buttonTampilkan;
        private Label labelInformasiPengelola;
        private Label labelEditInformasi;
        private TextBox textBoxYorN;
        private Button buttonEdit;
        private Label labelEditJudul;
        private TextBox textBoxJudul;
        private Label labelEditDeskripsi;
        private TextBox textBoxDeskripsi;
        private Button buttonSimpan;
        private Button buttonKembali;
    }
}