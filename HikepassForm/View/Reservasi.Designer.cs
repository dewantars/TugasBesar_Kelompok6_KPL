using System.Windows.Forms;

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
            labelTanggal = new Label();
            dateTimePickerTanggal = new DateTimePicker();
            labelKeterangan = new Label();
            textBoxKeterangan = new TextBox();
            buttonSubmit = new Button();
            buttonMinus = new Button();
            labelJumlah = new Label();
            buttonPlus = new Button();
            buttonTambahPendaki = new Button();
            buttonBack = new Button();
            labelJudul = new Label();
            SuspendLayout();

            // radioButton1
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(19, 374);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(482, 29);
            radioButton1.TabIndex = 18;
            radioButton1.Text = "Puncak Besar Malabar Via Cinyiruan (Sedang) 50k/Orang";
            radioButton1.CheckedChanged += radioButton1_CheckedChanged_1;

            // radioButton2
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(19, 409);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(485, 29);
            radioButton2.TabIndex = 19;
            radioButton2.Text = "Puncak Besar Malabar Via Panorama (Pendek) 20k/Orang";
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;

            // label1 
            label1.AutoSize = true;
            label1.Location = new Point(19, 344);
            label1.Name = "label1";
            label1.Size = new Size(173, 25);
            label1.TabIndex = 17;
            label1.Text = "Pilih Jalur Pendakian:";
            label1.Click += label1_Click;

            // labelNama
            labelNama.Location = new Point(19, 73);
            labelNama.Name = "labelNama";
            labelNama.Size = new Size(100, 23);
            labelNama.TabIndex = 1;
            labelNama.Text = "Nama";
            labelNama.Click += labelNama_Click_1;

            // textBoxNama 
            textBoxNama.Location = new Point(182, 68);
            textBoxNama.Name = "textBoxNama";
            textBoxNama.Size = new Size(300, 31);
            textBoxNama.TabIndex = 2;
            textBoxNama.TextChanged += textBoxNama_TextChanged_1;

            // labelNIK
            labelNIK.Location = new Point(19, 108);
            labelNIK.Name = "labelNIK";
            labelNIK.Size = new Size(100, 23);
            labelNIK.TabIndex = 3;
            labelNIK.Text = "NIK";
            labelNIK.Click += labelNIK_Click_1;

            // textBoxNIK
            textBoxNIK.Location = new Point(182, 103);
            textBoxNIK.Name = "textBoxNIK";
            textBoxNIK.Size = new Size(300, 31);
            textBoxNIK.TabIndex = 4;
            textBoxNIK.TextChanged += textBoxNIK_TextChanged_1;
 
            // labelKontak
            labelKontak.Location = new Point(19, 143);
            labelKontak.Name = "labelKontak";
            labelKontak.Size = new Size(100, 23);
            labelKontak.TabIndex = 5;
            labelKontak.Text = "Kontak";
            labelKontak.Click += labelKontak_Click_1;
 
            // textBoxKontak
            textBoxKontak.Location = new Point(182, 138);
            textBoxKontak.Name = "textBoxKontak";
            textBoxKontak.Size = new Size(300, 31);
            textBoxKontak.TabIndex = 6;
            textBoxKontak.TextChanged += textBoxKontak_TextChanged_1;

            // labelUsia
            labelUsia.Location = new Point(19, 178);
            labelUsia.Name = "labelUsia";
            labelUsia.Size = new Size(100, 23);
            labelUsia.TabIndex = 7;
            labelUsia.Text = "Usia";
            labelUsia.Click += labelUsia_Click_1;

            // textBoxUsia
            textBoxUsia.Location = new Point(182, 173);
            textBoxUsia.Name = "textBoxUsia";
            textBoxUsia.Size = new Size(300, 31);
            textBoxUsia.TabIndex = 8;
            textBoxUsia.TextChanged += textBoxUsia_TextChanged_1;

            // labelJumlahPendaki
            labelJumlahPendaki.Location = new Point(19, 213);
            labelJumlahPendaki.Name = "labelJumlahPendaki";
            labelJumlahPendaki.Size = new Size(150, 23);
            labelJumlahPendaki.TabIndex = 9;
            labelJumlahPendaki.Text = "Jumlah Pendaki";
            labelJumlahPendaki.Click += labelJumlahPendaki_Click_1;

            // labelTanggal
            labelTanggal.Location = new Point(19, 259);
            labelTanggal.Name = "labelTanggal";
            labelTanggal.Size = new Size(135, 35);
            labelTanggal.TabIndex = 13;
            labelTanggal.Text = "Tanggal Pendakian";
            labelTanggal.Click += labelTanggal_Click_1;

            // dateTimePickerTanggal
            dateTimePickerTanggal.Location = new Point(182, 254);
            dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            dateTimePickerTanggal.Size = new Size(300, 31);
            dateTimePickerTanggal.TabIndex = 14;
            dateTimePickerTanggal.ValueChanged += dateTimePickerTanggal_ValueChanged_1;

            // labelKeterangan
            labelKeterangan.Location = new Point(19, 294);
            labelKeterangan.Name = "labelKeterangan";
            labelKeterangan.Size = new Size(124, 38);
            labelKeterangan.TabIndex = 15;
            labelKeterangan.Text = "Keterangan";
            labelKeterangan.Click += labelKeterangan_Click_1;

            // textBoxKeterangan
            textBoxKeterangan.Location = new Point(182, 289);
            textBoxKeterangan.Name = "textBoxKeterangan";
            textBoxKeterangan.Size = new Size(300, 31);
            textBoxKeterangan.TabIndex = 16;
            textBoxKeterangan.TextChanged += textBoxKeterangan_TextChanged_1;

            // buttonSubmit
            buttonSubmit.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            buttonSubmit.Location = new Point(333, 456);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(180, 46);
            buttonSubmit.TabIndex = 20;
            buttonSubmit.Text = "Simpan Reservasi";
            buttonSubmit.Click += buttonSubmit_Click_2;

            // buttonMinus
            buttonMinus.Font = new Font("Microsoft Sans Serif", 14F);
            buttonMinus.Location = new Point(182, 208);
            buttonMinus.Name = "buttonMinus";
            buttonMinus.Size = new Size(40, 40);
            buttonMinus.TabIndex = 10;
            buttonMinus.Text = "-";
            buttonMinus.Click += buttonMinus_Click;

            // labelJumlah
            labelJumlah.Font = new Font("Segoe UI", 9F);
            labelJumlah.Location = new Point(227, 212);
            labelJumlah.Name = "labelJumlah";
            labelJumlah.Size = new Size(31, 30);
            labelJumlah.TabIndex = 11;
            labelJumlah.Text = "1";
            labelJumlah.TextAlign = ContentAlignment.MiddleCenter;
            labelJumlah.Click += labelJumlah_Click;

            // buttonPlus
            buttonPlus.Font = new Font("Microsoft Sans Serif", 14F);
            buttonPlus.Location = new Point(264, 208);
            buttonPlus.Name = "buttonPlus";
            buttonPlus.Size = new Size(40, 40);
            buttonPlus.TabIndex = 12;
            buttonPlus.Text = "+";
            buttonPlus.Click += buttonPlus_Click;
 
            // buttonTambahPendaki
            buttonTambahPendaki.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            buttonTambahPendaki.Location = new Point(312, 213);
            buttonTambahPendaki.Name = "buttonTambahPendaki";
            buttonTambahPendaki.Size = new Size(170, 30);
            buttonTambahPendaki.TabIndex = 21;
            buttonTambahPendaki.Text = "Tambahkan Data Pendaki";
            buttonTambahPendaki.Visible = false;
            buttonTambahPendaki.Click += buttonTambahPendaki_Click;

            // buttonBack
            buttonBack.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            buttonBack.ForeColor = SystemColors.ActiveCaptionText;
            buttonBack.Location = new Point(18, 23);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(100, 30);
            buttonBack.TabIndex = 22;
            buttonBack.Text = "Kembali";
            buttonBack.Click += buttonBack_Click;
  
            // labelJudul 
            labelJudul.AutoSize = true;
            labelJudul.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelJudul.Location = new Point(356, 6);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(176, 48);
            labelJudul.TabIndex = 23;
            labelJudul.Text = "Reservasi";
            labelJudul.Click += labelJudul_Click;
 
            // Reservasi
            Controls.Add(labelJudul);
            Controls.Add(labelNama);
            Controls.Add(textBoxNama);
            Controls.Add(labelNIK);
            Controls.Add(textBoxNIK);
            Controls.Add(labelKontak);
            Controls.Add(textBoxKontak);
            Controls.Add(labelUsia);
            Controls.Add(textBoxUsia);
            Controls.Add(labelJumlahPendaki);
            Controls.Add(buttonMinus);
            Controls.Add(labelJumlah);
            Controls.Add(buttonPlus);
            Controls.Add(labelTanggal);
            Controls.Add(dateTimePickerTanggal);
            Controls.Add(labelKeterangan);
            Controls.Add(textBoxKeterangan);
            Controls.Add(label1);
            Controls.Add(radioButton1);
            Controls.Add(radioButton2);
            Controls.Add(buttonSubmit);
            Controls.Add(buttonTambahPendaki);
            Controls.Add(buttonBack);
            Margin = new Padding(4);
            Name = "Reservasi";
            Size = new Size(852, 520);
            Load += Reservasi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private int jumlahPendaki = 1;
        private Button buttonMinus;
        private Button buttonPlus;
        private Label labelJumlah;
        private Button buttonTambahPendaki;
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
        private Label labelTanggal;
        private DateTimePicker dateTimePickerTanggal;
        private Label labelKeterangan;
        private TextBox textBoxKeterangan;
        private Button buttonSubmit;
        private Button buttonBack;
        private Label labelJudul;
    }
}
