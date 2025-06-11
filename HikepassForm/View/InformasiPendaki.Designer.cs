namespace HikepassForm.View
{
    partial class InformasiPendaki
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
            labelInformasiPendaki = new Label();
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
            labelTampilkanInformasi.Text = "Masukkan kategori (1 = Peraturan, 2 = Tips, 3 = Umum):";
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
            // labelInformasiPendaki
            // 
            labelInformasiPendaki.AutoSize = true;
            labelInformasiPendaki.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelInformasiPendaki.Location = new Point(30, 118);
            labelInformasiPendaki.Name = "labelInformasiPendaki";
            labelInformasiPendaki.Size = new Size(0, 25);
            labelInformasiPendaki.TabIndex = 4;
            labelInformasiPendaki.Click += labelInformasiPendaki_Click;
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
            // InformasiPendaki
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelInformasi);
            Controls.Add(labelTampilkanInformasi);
            Controls.Add(textBoxKategori);
            Controls.Add(buttonTampilkan);
            Controls.Add(labelInformasiPendaki);
            Controls.Add(buttonKembali);
            Name = "InformasiPendaki";
            Size = new Size(852, 494);
            Load += InformasiPendaki_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelInformasi;
        private Label labelTampilkanInformasi;
        private TextBox textBoxKategori;
        private Button buttonTampilkan;
        private Label labelInformasiPendaki;
        private Button buttonKembali;
    }
}