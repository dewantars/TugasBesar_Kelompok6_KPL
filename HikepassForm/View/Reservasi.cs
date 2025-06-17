using System;
using HikepassForm;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HikepassLibrary.Model;
using HikepassLibrary.Controller;
using Microsoft.AspNetCore.DataProtection;

namespace HikepassForm.View
{
    // Clean code: nama class menggunakan PascalCase
    public partial class Reservasi : UserControl
    {
        private static readonly HttpClient client = new HttpClient();
        private Dictionary<string, string> daftarPendakiTambahan = new Dictionary<string, string>();

        // Clean code: constructor menggunakan PascalCase
        public Reservasi()
        {
            InitializeComponent();
            buttonTambahPendaki.Click += buttonTambahPendaki_Click_1;
            buttonSubmit.Click += ButtonSubmit_Click;

        }

        // Clean code: method menggunakan PascalCase
        public void LoadPage(UserControl page)
        {
            this.Controls.Clear();
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }

        // Event handler disiapkan jika ingin menambahkan interaksi saat item dipilih
        private void labelJudul_Click(object sender, EventArgs e) { }
        private void labelNama_Click_1(object sender, EventArgs e) { }
        private void textBoxNama_TextChanged_1(object sender, EventArgs e) { }
        private void labelNIK_Click_1(object sender, EventArgs e) { }
        private void textBoxNIK_TextChanged_1(object sender, EventArgs e) { }
        private void labelKontak_Click_1(object sender, EventArgs e) { }
        private void textBoxKontak_TextChanged_1(object sender, EventArgs e) { }
        private void labelUsia_Click_1(object sender, EventArgs e) { }
        private void textBoxUsia_TextChanged_1(object sender, EventArgs e) { }
        private void labelJumlahPendaki_Click_1(object sender, EventArgs e) { }
        private void labelJumlah_Click(object sender, EventArgs e) { }
        private void buttonTambahPendaki_Click(object sender, EventArgs e) { }
        private void labelTanggal_Click_1(object sender, EventArgs e) { }
        private void dateTimePickerTanggal_ValueChanged_1(object sender, EventArgs e) { }
        private void labelKeterangan_Click_1(object sender, EventArgs e) { }
        private void textBoxKeterangan_TextChanged_1(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e) { }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { }
        private void buttonSubmit_Click_2(object sender, EventArgs e) { }
        private void Reservasi_Load(object sender, EventArgs e) { }

        // Clean code: white space antar logika disusun jelas dan indentasi konsisten 4 spasi
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (jumlahPendaki > 1)
            {
                jumlahPendaki--;
                labelJumlah.Text = jumlahPendaki.ToString();
                if (jumlahPendaki <= 1)
                {
                    buttonTambahPendaki.Visible = false;
                }
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            jumlahPendaki++;
            labelJumlah.Text = jumlahPendaki.ToString();
            if (jumlahPendaki > 1)
            {
                buttonTambahPendaki.Visible = true;
            }
        }

        // Secure coding: semua input pengguna divalidasi sebelum diproses
        // Clean code: white space antar logika (validasi - pemrosesan - UI) jelas
        private async void ButtonSubmit_Click(object sender, EventArgs e) 
        {
            try
            {
                int id = ControllerReservasi.reservasiList.Count == 0 ? 1 : ControllerReservasi.reservasiList.Max(r => r.Id) + 1;
                // Mengambil data pendaki utama
                string nama = textBoxNama.Text.Trim(); // Clean code: variabel lokal menggunakan camelCase
                string nik = textBoxNIK.Text.Trim(); // Clean code: deklarasi variabel dilakukan dekat dengan penggunaan
                string kontak = textBoxKontak.Text.Trim();
                string usiaText = textBoxUsia.Text.Trim();
                string keterangan = textBoxKeterangan.Text.Trim();
                DateTime tanggal = dateTimePickerTanggal.Value;

                // Secure coding: validasi jumlah pendaki harus angka dan minimal 1
                if (!int.TryParse(labelJumlah.Text, out int parsedJumlah) || parsedJumlah < 1)
                {
                    MessageBox.Show("Jumlah pendaki tidak valid.");
                    return;
                }
                jumlahPendaki = parsedJumlah;

                // Secure coding: validasi input teks wajib
                if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(nik))
                {
                    MessageBox.Show("Nama dan NIK pendaki utama tidak boleh kosong.");
                    return;
                }

                if (!int.TryParse(usiaText, out int usia))
                {
                    MessageBox.Show("Usia pendaki utama harus berupa angka.");
                    return;
                }

                if (!radioButton1.Checked && !radioButton2.Checked)
                {
                    MessageBox.Show("Silakan pilih jalur pendakian terlebih dahulu!");
                    return;
                }

                if (tanggal.Date < DateTime.Today)
                {
                    MessageBox.Show("Tanggal pendakian tidak boleh di masa lalu.");
                    return;
                }

                // Menentukan jalur
                Tiket.JalurPendakian jalur = radioButton1.Checked
                    ? Tiket.JalurPendakian.Cinyiruan
                    : Tiket.JalurPendakian.Panorama;

                // Membuat daftar pendaki awal dari data utama
                var daftarPendaki = new Dictionary<string, string>
                {
                    { nik, $"{nama} - Usia {usia}, Kontak: {kontak}" }
                };

                // Menambahkan pendaki tambahan (jika ada) 
                foreach (var tambahan in daftarPendakiTambahan)
                {
                    if (!daftarPendaki.ContainsKey(tambahan.Key))
                    {
                        daftarPendaki.Add(tambahan.Key, tambahan.Value);
                    }
                }

                // Secure coding: validasi jumlah data pendaki sesuai input
                if (daftarPendaki.Count != jumlahPendaki)
                {
                    MessageBox.Show($"Jumlah pendaki belum lengkap. Diperlukan {jumlahPendaki}, baru terisi {daftarPendaki.Count}.");
                    return;
                }

                // Membuat objek tiket
                var tiket = new Tiket
                {
                    Id = id,
                    Tanggal = tanggal,
                    JumlahPendaki = jumlahPendaki,
                    Jalur = jalur,
                    DaftarPendaki = daftarPendaki,
                    Keterangan = keterangan,
                    StatusPembayaran = false,
                    Status = Tiket.StatusTiket.BelumDibayar,
                    Kontak = kontak
                };

                // Mengirim ke API
                var response = await client.PostAsJsonAsync("http://localhost:5226/api/reservasi", tiket);
                ControllerReservasi.reservasiList.Add(tiket);

                if (response.IsSuccessStatusCode)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Reservasi berhasil disimpan!\n\nDaftar Pendaki:");
                    foreach (var pendaki in daftarPendaki)
                    {
                        sb.AppendLine($"- {pendaki.Value}");
                    }

                    // Menampilkan konfirmasi
                    Form resultDialog = new Form()
                    {
                        Text = "Konfirmasi Reservasi",
                        Size = new Size(400, 300),
                        StartPosition = FormStartPosition.CenterParent,
                        FormBorderStyle = FormBorderStyle.FixedDialog
                    };

                    Label label = new Label()
                    {
                        Text = sb.ToString(),
                        AutoSize = false,
                        Size = new Size(360, 180),
                        Location = new Point(10, 10),
                        Font = new Font("Segoe UI", 10),
                    };

                    Button buttonBayar = new Button()
                    {
                        Text = "Bayar Sekarang",
                        DialogResult = DialogResult.Yes,
                        Location = new Point(80, 210),
                        Size = new Size(110, 30)
                    };

                    Button buttonOK = new Button()
                    {
                        Text = "OK",
                        DialogResult = DialogResult.No,
                        Location = new Point(200, 210),
                        Size = new Size(80, 30)
                    };

                    resultDialog.Controls.Add(label);
                    resultDialog.Controls.Add(buttonBayar);
                    resultDialog.Controls.Add(buttonOK);

                    DialogResult dialogResult = resultDialog.ShowDialog();

                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBox.Show("Mengalihkan ke halaman pembayaran...");
                        Pembayaran halamanPembayaran = new Pembayaran(ControllerReservasi.reservasiList);
                        LoadPage(halamanPembayaran);
                    }

                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan reservasi: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                // Secure coding: exception handling untuk menghindari crash
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            textBoxNama.Text = "";
            textBoxNIK.Text = "";
            textBoxKontak.Text = "";
            textBoxUsia.Text = "";
            textBoxKeterangan.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePickerTanggal.Value = DateTime.Today;
            jumlahPendaki = 1;
            labelJumlah.Text = "1";
            buttonTambahPendaki.Visible = false;
            daftarPendakiTambahan.Clear();
        }

        private void buttonTambahPendaki_Click_1(object sender, EventArgs e)
        {
            int jumlahDibutuhkan = jumlahPendaki - 1; // Pendaki utama sudah ada
            int pendakiKe = 2;

            while (daftarPendakiTambahan.Count < jumlahDibutuhkan)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Masukkan data pendaki ke-{pendakiKe}\n(Nama - NIK - Kontak - Usia):",
                    "Input Data Pendaki");

                if (string.IsNullOrWhiteSpace(input))
                {
                    var result = MessageBox.Show($"Data pendaki ke-{pendakiKe} kosong. Batalkan input data tambahan?",
                                                 "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes) return;
                    else continue;
                }

                var parts = input.Split('-');
                if (parts.Length != 4)
                {
                    MessageBox.Show("Format salah. Gunakan format: Nama - NIK - Kontak - Usia");
                    continue;
                }

                string nama = parts[0].Trim();
                string nik = parts[1].Trim();
                string kontak = parts[2].Trim();
                string usiaText = parts[3].Trim();

                if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(nik))
                {
                    MessageBox.Show("Nama dan NIK tidak boleh kosong.");
                    continue;
                }

                if (!int.TryParse(usiaText, out int usia) || usia <= 0)
                {
                    MessageBox.Show("Usia harus berupa angka yang valid.");
                    continue;
                }

                // Secure coding: memastikan NIK tidak ganda
                if (daftarPendakiTambahan.ContainsKey(nik) || nik == textBoxNIK.Text.Trim())
                {
                    MessageBox.Show("NIK tersebut sudah digunakan untuk pendaki utama atau pendaki lain. Gunakan NIK yang berbeda.");
                    continue;
                }

                daftarPendakiTambahan[nik] = $"{nama} - Usia {usia}, Kontak: {kontak}";
                pendakiKe++;
            }

            MessageBox.Show("Data pendaki tambahan berhasil dicatat.");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            var dashboard = this.Parent as DashboardPendaki;
            dashboard?.PindahKeDashboard(); // Secure coding: penggunaan null-conditional operator
        }
    }
}
