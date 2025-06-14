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
            labelInformasi1Pengelola = new Label();
            labelEditInformasi = new Label();
            textBoxYorN = new TextBox();
            buttonEdit = new Button();
            labelInformasi2Pengelola = new Label();
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
            // labelInformasi1Pengelola
            // 
            labelInformasi1Pengelola.AutoSize = true;
            labelInformasi1Pengelola.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelInformasi1Pengelola.Location = new Point(30, 118);
            labelInformasi1Pengelola.Name = "labelInformasi1Pengelola";
            labelInformasi1Pengelola.Size = new Size(0, 25);
            labelInformasi1Pengelola.TabIndex = 4;
            labelInformasi1Pengelola.Click += labelInformasi1Pengelola_Click;
            // 
            // labelEditInformasi
            // 
            labelEditInformasi.AutoSize = true;
            labelEditInformasi.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEditInformasi.Location = new Point(30, 268);
            labelEditInformasi.Name = "labelEditInformasi";
            labelEditInformasi.Size = new Size(475, 25);
            labelEditInformasi.TabIndex = 5;
            labelEditInformasi.Text = "Apakah Anda ingin mengedit informasi kategori ini? (y/n):";
            labelEditInformasi.Click += labelEditInformasi_Click;
            // 
            // textBoxYorN
            // 
            textBoxYorN.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxYorN.Location = new Point(526, 268);
            textBoxYorN.Name = "textBoxYorN";
            textBoxYorN.Size = new Size(150, 31);
            textBoxYorN.TabIndex = 6;
            textBoxYorN.TextChanged += textBoxYorN_TextChanged;
            // 
            // buttonEdit
            // 
            buttonEdit.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonEdit.Location = new Point(697, 268);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(110, 34);
            buttonEdit.TabIndex = 7;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // labelInformasi2Pengelola
            // 
            labelInformasi2Pengelola.AutoSize = true;
            labelInformasi2Pengelola.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelInformasi2Pengelola.Location = new Point(30, 308);
            labelInformasi2Pengelola.Name = "labelInformasi2Pengelola";
            labelInformasi2Pengelola.Size = new Size(0, 25);
            labelInformasi2Pengelola.TabIndex = 8;
            labelInformasi2Pengelola.Click += labelInformasi2Pengelola_Click;
            // 
            // buttonKembali
            // 
            buttonKembali.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonKembali.Location = new Point(30, 30);
            buttonKembali.Name = "buttonKembali";
            buttonKembali.Size = new Size(110, 34);
            buttonKembali.TabIndex = 9;
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
            Controls.Add(labelInformasi1Pengelola);
            Controls.Add(labelEditInformasi);
            Controls.Add(textBoxYorN);
            Controls.Add(buttonEdit);
            Controls.Add(labelInformasi2Pengelola);
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
        private Label labelInformasi1Pengelola;
        private Label labelEditInformasi;
        private TextBox textBoxYorN;
        private Button buttonEdit;
        private Label labelInformasi2Pengelola;
        private Button buttonKembali;
    }
}