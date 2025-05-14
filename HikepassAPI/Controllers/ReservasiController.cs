using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using HikepassLibrary.Model;
using static HikepassLibrary.Model.Tiket;

namespace HikepassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasiController : ControllerBase
    {
        private static List<Tiket> reservasiList = new List<Tiket>();

        // GET: api/reservasi (Mendapatkan semua data reservasi)
        [HttpGet]
        public IActionResult GetAllReservasi()
        {
            if (reservasiList.Count == 0)
                return NotFound("Tidak ada data reservasi");

            return Ok(reservasiList); // Mengembalikan seluruh data reservasi
        }

        // GET: api/reservasi/{id} (Mendapatkan reservasi berdasarkan ID)
        [HttpGet("{id}")]
        public IActionResult GetReservasiById(int id)
        {
            var reservasi = reservasiList.FirstOrDefault(r => r.Id == id);
            if (reservasi == null)
                return NotFound("Reservasi tidak ditemukan");

            return Ok(reservasi); // Mengembalikan data reservasi berdasarkan ID
        }

        // POST: api/reservasi (Menambah data reservasi baru)
        [HttpPost]
        public IActionResult CreateReservasi([FromBody] Tiket newReservasi)
        {
            if (newReservasi == null)
                return BadRequest("Data reservasi tidak boleh kosong");

            // Pastikan data yang dikirimkan sudah valid
            if (newReservasi.DaftarPendaki == null || newReservasi.DaftarPendaki.Count == 0)
                return BadRequest("Daftar pendaki tidak boleh kosong");

            if (!Enum.IsDefined(typeof(Tiket.JalurPendakian), newReservasi.Jalur))
                return BadRequest("Jalur yang dipilih tidak valid");

            // Menambahkan ID baru secara otomatis (auto increment)
            newReservasi.Id = reservasiList.Count == 0 ? 1 : reservasiList.Max(r => r.Id) + 1;
            newReservasi.Status = Tiket.StatusTiket.BelumDibayar; // Status awal "Belum Dibayar"
            reservasiList.Add(newReservasi);  // Menambahkan reservasi ke list
            return CreatedAtAction(nameof(GetReservasiById), new { id = newReservasi.Id }, newReservasi);
        }

        // PUT: api/reservasi/{id} (Memperbarui data reservasi berdasarkan ID)
        [HttpPut("{id}")]
        public IActionResult UpdateReservasi(int id, [FromBody] Tiket updatedReservasi)
        {
            if (updatedReservasi == null || updatedReservasi.DaftarPendaki == null)
                return BadRequest("Data reservasi atau daftar pendaki tidak valid");

            var reservasi = reservasiList.FirstOrDefault(r => r.Id == id);
            if (reservasi == null)
                return NotFound("Reservasi tidak ditemukan");

            // Memperbarui data reservasi yang ada
            reservasi.DaftarPendaki = updatedReservasi.DaftarPendaki;
            reservasi.Jalur = updatedReservasi.Jalur;
            reservasi.Tanggal = updatedReservasi.Tanggal;
            reservasi.StatusPembayaran = updatedReservasi.StatusPembayaran;
            reservasi.Keterangan = updatedReservasi.Keterangan;
            reservasi.JumlahPendaki = updatedReservasi.JumlahPendaki;
            reservasi.IsCheckedIn = updatedReservasi.IsCheckedIn;
            reservasi.BarangBawaanSaatCheckin = updatedReservasi.BarangBawaanSaatCheckin;
            reservasi.BarangBawaanSaatCheckout = updatedReservasi.BarangBawaanSaatCheckout;
            reservasi.Status = updatedReservasi.Status;

            return Ok(reservasi);  // Mengembalikan data reservasi yang telah diperbarui
        }

        // DELETE: api/reservasi/{id} (Menghapus data reservasi berdasarkan ID)
        [HttpDelete("{id}")]
        public IActionResult DeleteReservasi(int id)
        {
            var reservasi = reservasiList.FirstOrDefault(r => r.Id == id);
            if (reservasi == null)
                return NotFound("Reservasi tidak ditemukan");
            reservasiList.Remove(reservasi);  // Menghapus reservasi dari list
            return NoContent();  // Mengembalikan status 204 (No Content)
        }
    }
}
