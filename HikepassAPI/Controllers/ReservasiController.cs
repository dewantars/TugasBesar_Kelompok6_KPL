using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HikepassLibrary.Model;
using static HikepassLibrary.Model.Tiket;
using HikepassLibrary.Controller;

namespace HikepassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasiController : ControllerBase
    {
        // GET: api/reservasi
        [HttpGet]
        public IActionResult GetAllReservasi()
        {
            if (ControllerReservasi.reservasiList == null)
                return StatusCode(500, "Data reservasi tidak tersedia.");

            if (!ControllerReservasi.reservasiList.Any())
                return NotFound("Tidak ada data reservasi.");

            return Ok(ControllerReservasi.reservasiList);
        }

        // GET: api/reservasi/{id}
        [HttpGet("{id}")]
        public IActionResult GetReservasiById(int id)
        {
            if (id <= 0)
                return BadRequest("ID tidak valid.");

            var reservasi = ControllerReservasi.reservasiList.FirstOrDefault(r => r.Id == id);
            if (reservasi == null)
                return NotFound("Reservasi tidak ditemukan.");

            return Ok(reservasi);
        }

        // POST: api/reservasi
        [HttpPost]
        public IActionResult CreateReservasi([FromBody] Tiket newReservasi)
        {
            if (newReservasi == null)
                return BadRequest("Data reservasi tidak boleh kosong.");

            if (newReservasi.DaftarPendaki == null || !newReservasi.DaftarPendaki.Any())
                return BadRequest("Daftar pendaki tidak boleh kosong.");

            // Table-Driven Validation for JalurPendakian
            Dictionary<int, JalurPendakian> jalurTabel = new Dictionary<int, JalurPendakian>
            {
                { 0, JalurPendakian.Panorama },
                { 1, JalurPendakian.Cinyiruan }
            };

            if (!jalurTabel.ContainsKey((int)newReservasi.Jalur))
                return BadRequest("Jalur pendakian tidak valid.");

            // Convert the numeric Jalur to the enum value
            newReservasi.Jalur = jalurTabel[(int)newReservasi.Jalur];

            if (newReservasi.Tanggal == default)
                return BadRequest("Tanggal pendakian harus diisi.");

            if (newReservasi.JumlahPendaki <= 0)
                return BadRequest("Jumlah pendaki harus lebih dari 0.");

            newReservasi.Id = ControllerReservasi.reservasiList.Count == 0
                ? 1
                : ControllerReservasi.reservasiList.Max(r => r.Id) + 1;

            newReservasi.Status = StatusTiket.BelumDibayar;

            ControllerReservasi.reservasiList.Add(newReservasi);

            return CreatedAtAction(nameof(GetReservasiById), new { id = newReservasi.Id }, newReservasi);
        }

        // PUT: api/reservasi/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateReservasi(int id, [FromBody] Tiket updatedReservasi)
        {
            if (id <= 0)
                return BadRequest("ID tidak valid.");

            if (updatedReservasi == null)
                return BadRequest("Data reservasi tidak boleh kosong.");

            if (updatedReservasi.DaftarPendaki == null || !updatedReservasi.DaftarPendaki.Any())
                return BadRequest("Daftar pendaki tidak boleh kosong.");

            if (!Enum.IsDefined(typeof(JalurPendakian), updatedReservasi.Jalur))
                return BadRequest("Jalur pendakian tidak valid.");

            if (updatedReservasi.Tanggal == default)
                return BadRequest("Tanggal pendakian harus diisi.");

            if (updatedReservasi.JumlahPendaki <= 0)
                return BadRequest("Jumlah pendaki harus lebih dari 0.");

            var reservasi = ControllerReservasi.reservasiList.FirstOrDefault(r => r.Id == id);
            if (reservasi == null)
                return NotFound("Reservasi tidak ditemukan.");

            // Update properti
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

            return Ok(reservasi);
        }

        // DELETE: api/reservasi/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteReservasi(int id)
        {
            if (id <= 0)
                return BadRequest("ID tidak valid.");

            var reservasi = ControllerReservasi.reservasiList.FirstOrDefault(r => r.Id == id);
            if (reservasi == null)
                return NotFound("Reservasi tidak ditemukan.");

            ControllerReservasi.reservasiList.Remove(reservasi);

            return NoContent();
        }

        public async Task BayarTiket(Tiket tiket)
        {
            throw new NotImplementedException();
        }
    }
}
