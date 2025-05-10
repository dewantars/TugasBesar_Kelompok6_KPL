using HikepassAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HikepassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasiController : ControllerBase
    {
        private static List<Reservasi> reservasiList = new List<Reservasi>();

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
        public IActionResult CreateReservasi([FromBody] Reservasi newReservasi)
        {
            if (newReservasi == null || newReservasi.DataPendaki == null)
                return BadRequest("Data reservasi atau kontak pendaki tidak valid");

            // Memvalidasi Jalur Pendakian
            if (!Enum.IsDefined(typeof(JalurPendakian), newReservasi.Jalur))
                return BadRequest("Jalur yang dipilih tidak valid");

            // Menambahkan ID baru secara otomatis (auto increment)
            newReservasi.Id = reservasiList.Count == 0 ? 1 : reservasiList.Max(r => r.Id) + 1;
            reservasiList.Add(newReservasi);  // Menambahkan reservasi ke list
            return CreatedAtAction(nameof(GetReservasiById), new { id = newReservasi.Id }, newReservasi);
        }

        // PUT: api/reservasi/{id} (Memperbarui data reservasi berdasarkan ID)
        [HttpPut("{id}")]
        public IActionResult UpdateReservasi(int id, [FromBody] Reservasi updatedReservasi)
        {
            if (updatedReservasi == null || updatedReservasi.DataPendaki == null)
                return BadRequest("Data reservasi atau kontak pendaki tidak valid");

            var reservasi = reservasiList.FirstOrDefault(r => r.Id == id);
            if (reservasi == null)
                return NotFound("Reservasi tidak ditemukan");

            // Memperbarui data reservasi yang ada
            reservasi.DataPendaki = updatedReservasi.DataPendaki;
            reservasi.Jalur = updatedReservasi.Jalur;
            reservasi.TanggalPendakian = updatedReservasi.TanggalPendakian;
            reservasi.StatusPembayaran = updatedReservasi.StatusPembayaran;
            reservasi.Keterangan = updatedReservasi.Keterangan;

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