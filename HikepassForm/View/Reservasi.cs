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

namespace HikepassForm.View
{
    public partial class Reservasi : UserControl
    {
        // Clean Code: Menggunakan HttpClient sebagai field statis, efisien untuk reuse
        private static readonly HttpClient client = new HttpClient();

        // Clean Code: Dictionary untuk menyimpan data pendaki tambahan
        private Dictionary<string, string> daftarPendakiTambahan = new Dictionary<string, string>();

        public Reservasi()
        {
            InitializeComponent();
            buttonTambahPendaki.Click += buttonTambahPendaki_Click_1;
            buttonSubmit.Click += ButtonSubmit_Click; // Clean Code: Penamaan method PascalCase sesuai standar
        }

        // Event handlers default - Clean Code: Dibiarkan kosong agar tidak error saat desain GUI
        private void labelJudul_Click(object sender, EventArgs e) { }
        private void Reservasi_Load(object sender, EventArgs e) { }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton2_CheckedChanged_1(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void labelNama_Click(object sender, EventArgs e) { }
        private void textBoxNama_TextChanged(object sender, EventArgs e) { }
        private void labelNIK_Click(object sender, EventArgs e) { }
        private void textBoxNIK_TextChanged(object sender, EventArgs e) { }
        private void labelKontak_Click(object sender, EventArgs e) { }
        private void textBoxKontak_TextChanged(object sender, EventArgs e) { }
        private void labelUsia_Click(object sender, EventArgs e) { }
        private void textBoxUsia_TextChanged(object sender, EventArgs e) { }
        private void labelJumlahPendaki_Click(object sender, EventArgs e) { }
        private void labelTanggal_Click(object sender, EventArgs e) { }
        private void dateTimePickerTanggal_ValueChanged(object sender, EventArgs e) { }
        private void labelKeterangan_Click(object sender, EventArgs e) { }
        private void textBoxKeterangan_TextChanged(object sender, EventArgs e) { }
        private void buttonSubmit_Click_1(object sender, EventArgs e) { }
        private void labelJumlah_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            // Clean Code: Kontrol jumlah minimum pendaki
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

        private async void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Ambil data pendaki utama
                string nama = textBoxNama.Text.Trim();
                string nik = textBoxNIK.Text.Trim();
                string kontak = textBoxKontak.Text.Trim();
                string usiaText = textBoxUsia.Text.Trim();
                string keterangan = textBoxKeterangan.Text.Trim();
                DateTime tanggal = dateTimePickerTanggal.Value;

                if (!int.TryParse(labelJumlah.Text, out int parsedJumlah) || parsedJumlah < 1)
                {
                    MessageBox.Show("Jumlah pendaki tidak valid.");
                    return;
                }
                jumlahPendaki = parsedJumlah;

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

                // Tentukan jalur
                Tiket.JalurPendakian jalur = radioButton1.Checked
                    ? Tiket.JalurPendakian.Cinyiruan
                    : Tiket.JalurPendakian.Panorama;

                // Buat daftar pendaki awal dari data utama
                var daftarPendaki = new Dictionary<string, string>
                {
                    { nik, $"{nama} - Usia {usia}, Kontak: {kontak}" }
                };

                // Tambahkan pendaki tambahan (jika ada)
                foreach (var tambahan in daftarPendakiTambahan)
                {
                    if (!daftarPendaki.ContainsKey(tambahan.Key))
                    {
                        daftarPendaki.Add(tambahan.Key, tambahan.Value);
                    }
                }

                // Validasi jumlah data pendaki harus sesuai dengan input jumlah
                if (daftarPendaki.Count != jumlahPendaki)
                {
                    MessageBox.Show($"Jumlah pendaki belum lengkap. Diperlukan {jumlahPendaki}, baru terisi {daftarPendaki.Count}.");
                    return;
                }

                // Buat objek tiket
                var tiket = new Tiket
                {
                    Tanggal = tanggal,
                    JumlahPendaki = jumlahPendaki,
                    Jalur = jalur,
                    DaftarPendaki = daftarPendaki,
                    Keterangan = keterangan,
                    StatusPembayaran = false,
                    Status = Tiket.StatusTiket.BelumDibayar,
                    Kontak = kontak
                };

                // Kirim ke API
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

                    // Tampilkan konfirmasi
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
                        // TODO: tambahkan logika ke halaman pembayaran
                    }

                    ClearForm(); // Reset semua input
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan reservasi: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            // Clean Code: Reset semua input ke default
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
            // Clean Code & Secure: Validasi input format data tambahan
            int jumlahDibutuhkan = jumlahPendaki - 1; // pendaki utama sudah ada
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
            dashboard?.PindahKeDashboard(); // Clean Code: Navigasi antar kontrol
        }
    }
}
