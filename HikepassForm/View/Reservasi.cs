using System;
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

namespace HikepassForm.View
{
    public partial class Reservasi : UserControl
    {
        private static readonly HttpClient client = new HttpClient();

        public Reservasi()
        {
            InitializeComponent();
        }

        private void Reservasi_Load(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void textBoxNama_TextChanged(object sender, EventArgs e) { }

        private void labelNama_Click(object sender, EventArgs e) { }

        private void labelNIK_Click(object sender, EventArgs e) { }

        private void textBoxNIK_TextChanged(object sender, EventArgs e) { }

        private void labelKontak_Click(object sender, EventArgs e) { }

        private void textBoxKontak_TextChanged(object sender, EventArgs e) { }

        private void labelUsia_Click(object sender, EventArgs e) { }

        private void textBoxUsia_TextChanged(object sender, EventArgs e) { }

        private void labelJumlahPendaki_Click(object sender, EventArgs e) { }

        private void textBoxJumlahPendaki_TextChanged(object sender, EventArgs e) { }

        private void labelTanggal_Click(object sender, EventArgs e) { }

        private void dateTimePickerTanggal_ValueChanged(object sender, EventArgs e) { }

        private void labelKeterangan_Click(object sender, EventArgs e) { }

        private void textBoxKeterangan_TextChanged(object sender, EventArgs e) { }

        private void label1_Click_1(object sender, EventArgs e) { }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e) { }

        private async void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string nama = textBoxNama.Text.Trim();
                string nik = textBoxNIK.Text.Trim();
                string kontak = textBoxKontak.Text.Trim();
                string usiaText = textBoxUsia.Text.Trim();
                string jumlahPendakiText = textBoxJumlahPendaki.Text.Trim();
                DateTime tanggal = dateTimePickerTanggal.Value;
                string keterangan = textBoxKeterangan.Text.Trim();

                // Validasi awal
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

                if (!int.TryParse(jumlahPendakiText, out int jumlahPendaki) || jumlahPendaki <= 0)
                {
                    MessageBox.Show("Jumlah pendaki harus berupa angka dan minimal 1.");
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

                Tiket.JalurPendakian jalur = radioButton1.Checked
                    ? Tiket.JalurPendakian.Cinyiruan
                    : Tiket.JalurPendakian.Panorama;

                var daftarPendaki = new Dictionary<string, string>
        {
            { nik, $"{nama} - Usia {usia}, Kontak: {kontak}" }
        };

                // Jika jumlah pendaki lebih dari 1, minta input tambahan
                for (int i = 2; i <= jumlahPendaki; i++)
                {
                    string inputNama = Microsoft.VisualBasic.Interaction.InputBox("Masukkan nama pendaki ke-" + i, "Input Nama");
                    if (string.IsNullOrWhiteSpace(inputNama))
                    {
                        MessageBox.Show($"Nama pendaki ke-{i} tidak boleh kosong.");
                        return;
                    }

                    string inputNIK = Microsoft.VisualBasic.Interaction.InputBox("Masukkan NIK pendaki ke-" + i, "Input NIK");
                    if (string.IsNullOrWhiteSpace(inputNIK))
                    {
                        MessageBox.Show($"NIK pendaki ke-{i} tidak boleh kosong.");
                        return;
                    }

                    string inputKontak = Microsoft.VisualBasic.Interaction.InputBox("Masukkan kontak pendaki ke-" + i, "Input Kontak");
                    string inputUsiaText = Microsoft.VisualBasic.Interaction.InputBox("Masukkan usia pendaki ke-" + i, "Input Usia");

                    if (!int.TryParse(inputUsiaText, out int inputUsia))
                    {
                        MessageBox.Show($"Usia pendaki ke-{i} harus berupa angka.");
                        return;
                    }

                    daftarPendaki.Add(inputNIK, $"{inputNama} - Usia {inputUsia}, Kontak: {inputKontak}");
                }

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

                var response = await client.PostAsJsonAsync("http://localhost:5226/api/reservasi", tiket);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Reservasi berhasil disimpan!");
                    ClearForm();
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
            textBoxNama.Text = "";
            textBoxNIK.Text = "";
            textBoxKontak.Text = "";
            textBoxUsia.Text = "";
            textBoxJumlahPendaki.Text = "";
            textBoxKeterangan.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePickerTanggal.Value = DateTime.Now;
        }
    }
}
