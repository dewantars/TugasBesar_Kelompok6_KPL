using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HikepassLibrary.Controller; 
using HikepassLibrary.Model;      

namespace HikepassForm.View
{
    public partial class CheckinDanCheckout : UserControl
    {

        private readonly List<Tiket> daftarTiket;
        private List<string> daftarBarangBaru;
        

        public CheckinDanCheckout(List<Tiket> tiketList)
        {
            InitializeComponent();
            this.daftarTiket = tiketList;
            this.daftarBarangBaru = new List<string>();
            

            RefreshTampilan();
        }

        
        private void CheckinDanCheckout_Load(object sender, EventArgs e)
        {
            RefreshTampilan();
        }

        // Method utama untuk menyegarkan dan mereset tampilan
        private void RefreshTampilan()
        {
            // Filter untuk menampilkan tiket yang bisa di-check-in dan check-out .
            var tiketYangTampil = ControllerReservasi.reservasiList
                .Where(t => t.Status == Tiket.StatusTiket.Dibayar || t.Status == Tiket.StatusTiket.Checkin)
                .ToList();

            var bindingList = new BindingList<Tiket>(tiketYangTampil);

            // untuk "mereset" grid
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bindingList;


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.DataBoundItem is Tiket tiket)
                {

                    List<string> barangUntukDitampilkan = null;
                    if (tiket.Status == Tiket.StatusTiket.Checkin && tiket.BarangBawaanSaatCheckin.Any())
                    {
                        barangUntukDitampilkan = tiket.BarangBawaanSaatCheckin;
                    }
                    else if (tiket.Status == Tiket.StatusTiket.Checkout && tiket.BarangBawaanSaatCheckout.Any())
                    {
                        barangUntukDitampilkan = tiket.BarangBawaanSaatCheckout;
                    }


                    if (barangUntukDitampilkan != null)
                    {
                        
                        row.Cells["BarangBawaanColumn"].Value = string.Join(", ", barangUntukDitampilkan);
                    }
                    else
                    {
                        row.Cells["BarangBawaanColumn"].Value = "-"; 
                    }
                }
            }
            

            dataGridView1.Refresh();
            UpdateTombolState();
        }


      
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == dataGridView1.Columns["Pilih"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                bool currentValue = Convert.ToBoolean(row.Cells["Pilih"].Value);

                row.Cells["Pilih"].Value = !currentValue;

                dataGridView1.EndEdit();
                UpdateTombolState();
            }
        }

        
        private void UpdateTombolState()
        {
            var tiketTercentang = new List<Tiket>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Pilih"].Value) == true)
                {
                    tiketTercentang.Add(row.DataBoundItem as Tiket);
                }
            }

            if (!tiketTercentang.Any())
            {
                btnCheckIn.Enabled = false;
                btnCheckOut.Enabled = false;
                return;
            }

            // Aturan Tombol Check-in
            btnCheckIn.Enabled = tiketTercentang.All(t => t.Status == Tiket.StatusTiket.Dibayar);

            // Aturan Tombol Check-out
            btnCheckOut.Enabled = tiketTercentang.All(t => t.Status == Tiket.StatusTiket.Checkin);
        }


        private void btnTambahBarang_Click(object sender, EventArgs e)
        {
            string barang = txtBoxInputBarang.Text.Trim();
            if (!string.IsNullOrEmpty(barang))
            {
                listBoxBarang.Items.Add(barang);
                daftarBarangBaru.Add(barang);
                txtBoxInputBarang.Clear();
                txtBoxInputBarang.Focus();
            }
        }


        private async void btnCheckIn_Click(object sender, EventArgs e)
        {
            
            await ProsesAksi("Check-in");
        }

        private async void btnCheckOut_Click(object sender, EventArgs e)
        {
            
            await ProsesAksi("Check-out");
        }

    

        private async Task ProsesAksi(string namaAksi)
        {
           
            if (!daftarBarangBaru.Any())
            {
                MessageBox.Show("Harap masukkan minimal satu barang bawaan sebagai syarat.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Tiket.StatusTiket statusSumber;
            if (namaAksi == "Check-in")
            {
                statusSumber = Tiket.StatusTiket.Dibayar;
            }
            else if (namaAksi == "Check-out")
            {
                statusSumber = Tiket.StatusTiket.Checkin;
            }
            else
            {
                MessageBox.Show($"Aksi '{namaAksi}' tidak dikenal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var tiketUntukProses = new List<Tiket>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Pilih"].Value) == true && (row.DataBoundItem as Tiket)?.Status == statusSumber)
                {
                    tiketUntukProses.Add(row.DataBoundItem as Tiket);
                }
            }

            if (!tiketUntukProses.Any())
            {
                MessageBox.Show($"Tidak ada tiket dengan status '{statusSumber}' yang dipilih.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnCheckIn.Enabled = false;
            btnCheckOut.Enabled = false;



            var updateTasks = new List<Task>();
            foreach (var tiket in tiketUntukProses)
            {
                var tiketGlobal = ControllerReservasi.reservasiList.FirstOrDefault(t => t.Id == tiket.Id);
                if (tiketGlobal != null)
                {
                    //FORM HANYA MENGURUS BARANG BAWAAN
                    if (namaAksi == "Check-in")
                    {
                        tiketGlobal.BarangBawaanSaatCheckin.AddRange(daftarBarangBaru);
                    }
                    else // Check-out
                    {
                        tiketGlobal.BarangBawaanSaatCheckout.AddRange(daftarBarangBaru);
                    }

                    updateTasks.Add(ControllerReservasi.UpdatedCheckInCheckOut("http://localhost:5226/api/reservasi", tiketGlobal.Id));
                }
            }

            await Task.WhenAll(updateTasks);



            MessageBox.Show($"{tiketUntukProses.Count} tiket berhasil di-{namaAksi}.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listBoxBarang.Items.Clear();
            daftarBarangBaru.Clear();
            txtBoxInputBarang.Clear();

            RefreshTampilan();
        }


        private void btnKembali_Click(object sender, EventArgs e)
        {
            var tiketSaya = this.Parent as TiketSaya;
            tiketSaya?.PindahKeTiketSaya();
        }

        
        private void listBoxBarang_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtBoxInputBarang_TextChanged(object sender, EventArgs e) { }

        private void CheckinDanCheckout_Load_1(object sender, EventArgs e) { }
    }
}