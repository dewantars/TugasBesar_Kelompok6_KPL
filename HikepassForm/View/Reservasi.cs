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

namespace HikepassForm.View
{
    public partial class Reservasi : UserControl
    {
        private static readonly HttpClient client = new HttpClient();
        private Dictionary<string, string> daftarPendakiTambahan = new Dictionary<string, string>();

        public Reservasi()
        {
            InitializeComponent();
            buttonTambahPendaki.Click += buttonTambahPendaki_Click_1;
            buttonSubmit.Click += ButtonSubmit_Click;
        }

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
                string nama = textBoxNama.Text.Trim();
                string nik = textBoxNIK.Text.Trim();
                string kontak = textBoxKontak.Text.Trim();
                string usiaText = textBoxUsia.Text.Trim();
                string keterangan = textBoxKeterangan.Text.Trim();
                DateTime tanggal = dateTimePickerTanggal.Value;

                if (!int.TryParse(labelJumlah.Text, out int jumlahPendaki) || jumlahPendaki < 1)
                {
                    MessageBox.Show("Jumlah pendaki tidak valid.");
                    return;
                }

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

                Tiket.JalurPendakian jalur = radioButton1.Checked
                    ? Tiket.JalurPendakian.Cinyiruan
                    : Tiket.JalurPendakian.Panorama;

                var daftarPendaki = new Dictionary<string, string>
                {
                    { nik, $"{nama} - Usia {usia}, Kontak: {kontak}" }
                };

                for (int i = 2; i <= jumlahPendaki; i++)
                {
                    string inputNama = Microsoft.VisualBasic.Interaction.InputBox($"Masukkan nama pendaki ke-{i}", "Input Nama");
                    if (string.IsNullOrWhiteSpace(inputNama))
                    {
                        MessageBox.Show($"Nama pendaki ke-{i} tidak boleh kosong.");
                        return;
                    }

                    string inputNIK = Microsoft.VisualBasic.Interaction.InputBox($"Masukkan NIK pendaki ke-{i}", "Input NIK");
                    if (string.IsNullOrWhiteSpace(inputNIK))
                    {
                        MessageBox.Show($"NIK pendaki ke-{i} tidak boleh kosong.");
                        return;
                    }

                    string inputKontak = Microsoft.VisualBasic.Interaction.InputBox($"Masukkan kontak pendaki ke-{i}", "Input Kontak");
                    string inputUsiaText = Microsoft.VisualBasic.Interaction.InputBox($"Masukkan usia pendaki ke-{i}", "Input Usia");

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
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Reservasi berhasil disimpan!\n\nDaftar Pendaki:");
                    foreach (var pendaki in daftarPendaki)
                    {
                        sb.AppendLine($"- {pendaki.Value}");
                    }

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
                        // LOGIKA DISINI JANNNNNNNNNNNNNNNNNNNNNNNNNNNNN
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
        }

        private void buttonTambahPendaki_Click_1(object sender, EventArgs e)
        {
            daftarPendakiTambahan.Clear();
            int jumlahDibutuhkan = jumlahPendaki - 1; // karena pendaki utama sudah diisi
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

                if (daftarPendakiTambahan.ContainsKey(nik))
                {
                    MessageBox.Show("NIK tersebut sudah diinput. Gunakan NIK yang berbeda.");
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
            dashboard?.PindahKeDashboard();
        }
    }
}
