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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformasiPengelola));
            labelInformasi = new Label();
            labelTampilkanInformasi = new Label();
            textBoxKategori = new TextBox();
            buttonTampilkan = new Button();
            labelInformasi1Pengelola = new Label();
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
            resources.ApplyResources(labelInformasi, "labelInformasi");
            labelInformasi.Name = "labelInformasi";
            labelInformasi.Click += labelInformasi_Click;
            // 
            // labelTampilkanInformasi
            // 
            resources.ApplyResources(labelTampilkanInformasi, "labelTampilkanInformasi");
            labelTampilkanInformasi.Name = "labelTampilkanInformasi";
            labelTampilkanInformasi.Click += labelTampilkanInformasi_Click;
            // 
            // textBoxKategori
            // 
            resources.ApplyResources(textBoxKategori, "textBoxKategori");
            textBoxKategori.Name = "textBoxKategori";
            textBoxKategori.TextChanged += textBoxKategori_TextChanged;
            // 
            // buttonTampilkan
            // 
            resources.ApplyResources(buttonTampilkan, "buttonTampilkan");
            buttonTampilkan.Name = "buttonTampilkan";
            buttonTampilkan.UseVisualStyleBackColor = true;
            buttonTampilkan.Click += buttonTampilkan_Click;
            // 
            // labelInformasi1Pengelola
            // 
            resources.ApplyResources(labelInformasi1Pengelola, "labelInformasi1Pengelola");
            labelInformasi1Pengelola.Name = "labelInformasi1Pengelola";
            labelInformasi1Pengelola.Click += labelInformasi1Pengelola_Click;
            // 
            // labelEditInformasi
            // 
            resources.ApplyResources(labelEditInformasi, "labelEditInformasi");
            labelEditInformasi.Name = "labelEditInformasi";
            labelEditInformasi.Click += labelEditInformasi_Click;
            // 
            // textBoxYorN
            // 
            resources.ApplyResources(textBoxYorN, "textBoxYorN");
            textBoxYorN.Name = "textBoxYorN";
            textBoxYorN.TextChanged += textBoxYorN_TextChanged;
            // 
            // buttonEdit
            // 
            resources.ApplyResources(buttonEdit, "buttonEdit");
            buttonEdit.Name = "buttonEdit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // labelEditJudul
            // 
            resources.ApplyResources(labelEditJudul, "labelEditJudul");
            labelEditJudul.Name = "labelEditJudul";
            labelEditJudul.Click += labelEditJudul_Click;
            // 
            // textBoxJudul
            // 
            resources.ApplyResources(textBoxJudul, "textBoxJudul");
            textBoxJudul.Name = "textBoxJudul";
            textBoxJudul.TextChanged += textBoxJudul_TextChanged;
            // 
            // labelEditDeskripsi
            // 
            resources.ApplyResources(labelEditDeskripsi, "labelEditDeskripsi");
            labelEditDeskripsi.Name = "labelEditDeskripsi";
            labelEditDeskripsi.Click += labelEditDeskripsi_Click;
            // 
            // textBoxDeskripsi
            // 
            resources.ApplyResources(textBoxDeskripsi, "textBoxDeskripsi");
            textBoxDeskripsi.Name = "textBoxDeskripsi";
            textBoxDeskripsi.TextChanged += textBoxDeskripsi_TextChanged;
            // 
            // buttonSimpan
            // 
            resources.ApplyResources(buttonSimpan, "buttonSimpan");
            buttonSimpan.Name = "buttonSimpan";
            buttonSimpan.UseVisualStyleBackColor = true;
            buttonSimpan.Click += buttonSimpan_Click;
            // 
            // buttonKembali
            // 
            resources.ApplyResources(buttonKembali, "buttonKembali");
            buttonKembali.Name = "buttonKembali";
            buttonKembali.UseVisualStyleBackColor = true;
            buttonKembali.Click += buttonKembali_Click;
            // 
            // InformasiPengelola
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelInformasi);
            Controls.Add(labelTampilkanInformasi);
            Controls.Add(textBoxKategori);
            Controls.Add(buttonTampilkan);
            Controls.Add(labelInformasi1Pengelola);
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
        private Label labelEditJudul;
        private TextBox textBoxJudul;
        private Label labelEditDeskripsi;
        private TextBox textBoxDeskripsi;
        private Button buttonSimpan;
        private Button buttonKembali;
    }
}