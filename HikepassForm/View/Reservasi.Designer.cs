namespace HikepassForm.View
{
    partial class Reservasi
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
            label3 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label1 = new Label();
            labelNama = new Label();
            textBoxNama = new TextBox();
            labelNIK = new Label();
            textBoxNIK = new TextBox();
            labelKontak = new Label();
            textBoxKontak = new TextBox();
            labelUsia = new Label();
            textBoxUsia = new TextBox();
            labelJumlahPendaki = new Label();
            textBoxJumlahPendaki = new TextBox();
            labelTanggal = new Label();
            dateTimePickerTanggal = new DateTimePicker();
            labelKeterangan = new Label();
            textBoxKeterangan = new TextBox();
            buttonSubmit = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 18F);
            label3.Location = new Point(333, 20);
            label3.Name = "label3";
            label3.Size = new Size(177, 40);
            label3.TabIndex = 0;
            label3.Text = "Reservasi";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(37, 370);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(482, 29);
            radioButton1.TabIndex = 11;
            radioButton1.TabStop = true;
            radioButton1.Text = "Puncak Besar Malabar Via Cinyiruan (Sedang) 50k/Orang";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(37, 405);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(485, 29);
            radioButton2.TabIndex = 12;
            radioButton2.TabStop = true;
            radioButton2.Text = "Puncak Besar Malabar Via Panorama (Pendek) 20k/Orang";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 340);
            label1.Name = "label1";
            label1.Size = new Size(173, 25);
            label1.TabIndex = 13;
            label1.Text = "Pilih Jalur Pendakian:";
            label1.Click += label1_Click_1;
            // 
            // labelNama
            // 
            labelNama.Location = new Point(37, 80);
            labelNama.Name = "labelNama";
            labelNama.Size = new Size(100, 23);
            labelNama.TabIndex = 1;
            labelNama.Text = "Nama";
            labelNama.Click += labelNama_Click;
            // 
            // textBoxNama
            // 
            textBoxNama.Location = new Point(200, 75);
            textBoxNama.Name = "textBoxNama";
            textBoxNama.Size = new Size(300, 31);
            textBoxNama.TabIndex = 2;
            textBoxNama.TextChanged += textBoxNama_TextChanged;
            // 
            // labelNIK
            // 
            labelNIK.Location = new Point(37, 115);
            labelNIK.Name = "labelNIK";
            labelNIK.Size = new Size(100, 23);
            labelNIK.TabIndex = 3;
            labelNIK.Text = "NIK";
            labelNIK.Click += labelNIK_Click;
            // 
            // textBoxNIK
            // 
            textBoxNIK.Location = new Point(200, 110);
            textBoxNIK.Name = "textBoxNIK";
            textBoxNIK.Size = new Size(300, 31);
            textBoxNIK.TabIndex = 4;
            textBoxNIK.TextChanged += textBoxNIK_TextChanged;
            // 
            // labelKontak
            // 
            labelKontak.Location = new Point(37, 150);
            labelKontak.Name = "labelKontak";
            labelKontak.Size = new Size(100, 23);
            labelKontak.TabIndex = 5;
            labelKontak.Text = "Kontak";
            labelKontak.Click += labelKontak_Click;
            // 
            // textBoxKontak
            // 
            textBoxKontak.Location = new Point(200, 145);
            textBoxKontak.Name = "textBoxKontak";
            textBoxKontak.Size = new Size(300, 31);
            textBoxKontak.TabIndex = 6;
            textBoxKontak.TextChanged += textBoxKontak_TextChanged;
            // 
            // labelUsia
            // 
            labelUsia.Location = new Point(37, 185);
            labelUsia.Name = "labelUsia";
            labelUsia.Size = new Size(100, 23);
            labelUsia.TabIndex = 7;
            labelUsia.Text = "Usia";
            labelUsia.Click += labelUsia_Click;
            // 
            // textBoxUsia
            // 
            textBoxUsia.Location = new Point(200, 180);
            textBoxUsia.Name = "textBoxUsia";
            textBoxUsia.Size = new Size(300, 31);
            textBoxUsia.TabIndex = 8;
            textBoxUsia.TextChanged += textBoxUsia_TextChanged;
            // 
            // labelJumlahPendaki
            // 
            labelJumlahPendaki.Location = new Point(37, 220);
            labelJumlahPendaki.Name = "labelJumlahPendaki";
            labelJumlahPendaki.Size = new Size(100, 23);
            labelJumlahPendaki.TabIndex = 9;
            labelJumlahPendaki.Text = "Jumlah Pendaki";
            labelJumlahPendaki.Click += labelJumlahPendaki_Click;
            // 
            // textBoxJumlahPendaki
            // 
            textBoxJumlahPendaki.Location = new Point(200, 215);
            textBoxJumlahPendaki.Name = "textBoxJumlahPendaki";
            textBoxJumlahPendaki.Size = new Size(300, 31);
            textBoxJumlahPendaki.TabIndex = 10;
            textBoxJumlahPendaki.TextChanged += textBoxJumlahPendaki_TextChanged;
            // 
            // labelTanggal
            // 
            labelTanggal.Location = new Point(37, 255);
            labelTanggal.Name = "labelTanggal";
            labelTanggal.Size = new Size(135, 35);
            labelTanggal.TabIndex = 11;
            labelTanggal.Text = "Tanggal Pendakian";
            labelTanggal.Click += labelTanggal_Click;
            // 
            // dateTimePickerTanggal
            // 
            dateTimePickerTanggal.Location = new Point(200, 250);
            dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            dateTimePickerTanggal.Size = new Size(300, 31);
            dateTimePickerTanggal.TabIndex = 12;
            dateTimePickerTanggal.ValueChanged += dateTimePickerTanggal_ValueChanged;
            // 
            // labelKeterangan
            // 
            labelKeterangan.Location = new Point(37, 290);
            labelKeterangan.Name = "labelKeterangan";
            labelKeterangan.Size = new Size(124, 38);
            labelKeterangan.TabIndex = 13;
            labelKeterangan.Text = "Keterangan";
            labelKeterangan.Click += labelKeterangan_Click;
            // 
            // textBoxKeterangan
            // 
            textBoxKeterangan.Location = new Point(200, 285);
            textBoxKeterangan.Name = "textBoxKeterangan";
            textBoxKeterangan.Size = new Size(300, 31);
            textBoxKeterangan.TabIndex = 14;
            textBoxKeterangan.TextChanged += textBoxKeterangan_TextChanged;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Location = new Point(320, 458);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(180, 46);
            buttonSubmit.TabIndex = 15;
            buttonSubmit.Text = "Simpan Reservasi";
            buttonSubmit.Click += ButtonSubmit_Click;
            // 
            // Reservasi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(labelNama);
            Controls.Add(textBoxNama);
            Controls.Add(labelNIK);
            Controls.Add(textBoxNIK);
            Controls.Add(labelKontak);
            Controls.Add(textBoxKontak);
            Controls.Add(labelUsia);
            Controls.Add(textBoxUsia);
            Controls.Add(labelJumlahPendaki);
            Controls.Add(textBoxJumlahPendaki);
            Controls.Add(labelTanggal);
            Controls.Add(dateTimePickerTanggal);
            Controls.Add(labelKeterangan);
            Controls.Add(textBoxKeterangan);
            Controls.Add(label1);
            Controls.Add(radioButton1);
            Controls.Add(radioButton2);
            Controls.Add(buttonSubmit);
            Margin = new Padding(4);
            Name = "Reservasi";
            Size = new Size(852, 520);
            Load += Reservasi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label1;
        private Label labelNama;
        private TextBox textBoxNama;
        private Label labelNIK;
        private TextBox textBoxNIK;
        private Label labelKontak;
        private TextBox textBoxKontak;
        private Label labelUsia;
        private TextBox textBoxUsia;
        private Label labelJumlahPendaki;
        private TextBox textBoxJumlahPendaki;
        private Label labelTanggal;
        private DateTimePicker dateTimePickerTanggal;
        private Label labelKeterangan;
        private TextBox textBoxKeterangan;
        private Button buttonSubmit;
    }
}
