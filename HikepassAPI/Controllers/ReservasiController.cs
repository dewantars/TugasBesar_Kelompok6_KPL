using Microsoft.AspNetCore.Mvc; 
using System;
using System.Collections.Generic;
using System.Linq;
using HikepassLibrary.Model;
using static HikepassLibrary.Model.Tiket;
using HikepassLibrary.Controller;
using System.Diagnostics;

namespace HikepassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // Clean code: nama class menggunakan PascalCase, sesuai standar konvensi C#
    public class ReservasiController : ControllerBase
    {
        // Clean code: nama method menggunakan PascalCase, sesuai standar konvensi C#
        // Secure coding: pengecekan null dan kondisi kosong 

        // GET: api/reservasi
        [HttpGet]
        public IActionResult GetAllReservasi()
        {
            // Design by Contract - Precondition
            Debug.Assert(ControllerReservasi.reservasiList != null, "List reservasi tidak boleh null sebelum diproses.");

            // Defensive
            if (ControllerReservasi.reservasiList == null)
                return StatusCode(500, "Data reservasi tidak tersedia.");

            if (!ControllerReservasi.reservasiList.Any())
                return NotFound("Tidak ada data reservasi.");

            // Design by Contract - Postcondition
            Debug.Assert(ControllerReservasi.reservasiList.Count > 0, "List reservasi seharusnya tidak kosong.");

            return Ok(ControllerReservasi.reservasiList);
        }

        // Clean code: white space antar logika validasi ditambahkan untuk keterbacaan
        // GET: api/reservasi/{id}
        [HttpGet("{id}")]
        public IActionResult GetReservasiById(int id) // Clean code: semua nama parameter dan variable menggunakan camelCase
        {
            // Design by Contract - Precondition
            Debug.Assert(id > 0, "ID harus lebih besar dari 0.");

            // Defensive
            if (id <= 0)
                return BadRequest("ID tidak valid.");

            // Secure coding: mencegah NullReferenceException dengan pengecekan null
            var reservasi = ControllerReservasi.reservasiList.FirstOrDefault(r => r.Id == id);
            if (reservasi == null)
                return NotFound("Reservasi tidak ditemukan.");

            // Design by Contract - Postcondition
            Debug.Assert(reservasi.Id == id, "ID reservasi harus sesuai dengan yang diminta.");

            return Ok(reservasi);
        }

        // POST: api/reservasi
        [HttpPost]
        public IActionResult CreateReservasi([FromBody] Tiket newReservasi)
        {
            // Design by Contract - Precondition
            Debug.Assert(newReservasi != null, "Data reservasi harus disediakan.");
            Debug.Assert(newReservasi.Tanggal != default, "Tanggal tidak boleh default.");
            Debug.Assert(newReservasi.JumlahPendaki > 0, "Jumlah pendaki harus lebih dari 0.");
            Debug.Assert(Enum.IsDefined(typeof(JalurPendakian), newReservasi.Jalur), "Jalur pendakian harus valid.");

            // Defensive
            if (newReservasi == null)
                return BadRequest("Data reservasi tidak boleh kosong.");

            // Secure coding: pengecekan daftar pendaki tidak null dan tidak kosong
            if (newReservasi.DaftarPendaki == null || !newReservasi.DaftarPendaki.Any())
                return BadRequest("Daftar pendaki tidak boleh kosong.");

            // Secure coding: validasi enum mencegah manipulasi data
            if (!Enum.IsDefined(typeof(JalurPendakian), newReservasi.Jalur))
                return BadRequest("Jalur pendakian tidak valid.");

            if (newReservasi.Tanggal == default)
                return BadRequest("Tanggal pendakian harus diisi.");

            if (newReservasi.JumlahPendaki <= 0)
                return BadRequest("Jumlah pendaki harus lebih dari 0.");

            // Clean code: ID ditentukan otomatis berdasarkan jumlah data, readable dan jelas
            newReservasi.Id = ControllerReservasi.reservasiList.Count == 0
                ? 1
                : ControllerReservasi.reservasiList.Max(r => r.Id) + 1;

            newReservasi.Status = StatusTiket.BelumDibayar;

            ControllerReservasi.reservasiList.Add(newReservasi);

            // Design by Contract - Postcondition
            Debug.Assert(newReservasi.Id > 0, "ID reservasi harus terbentuk.");
            Debug.Assert(newReservasi.Status == StatusTiket.BelumDibayar, "Status awal harus BelumDibayar.");

            return CreatedAtAction(nameof(GetReservasiById), new { id = newReservasi.Id }, newReservasi);
        }

        // PUT: api/reservasi/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateReservasi(int id, [FromBody] Tiket updatedReservasi)
        {
            // Design by Contract - Precondition
            Debug.Assert(id > 0, "ID harus valid.");
            Debug.Assert(updatedReservasi != null, "Data input tidak boleh null.");
            Debug.Assert(updatedReservasi.DaftarPendaki != null && updatedReservasi.DaftarPendaki.Any(), "Daftar pendaki harus ada.");
            Debug.Assert(Enum.IsDefined(typeof(JalurPendakian), updatedReservasi.Jalur), "Jalur pendakian tidak valid.");
            Debug.Assert(updatedReservasi.Tanggal != default, "Tanggal tidak valid.");
            Debug.Assert(updatedReservasi.JumlahPendaki > 0, "Jumlah pendaki harus lebih dari 0.");

            // Defensive
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

            reservasi.DaftarPendaki = updatedReservasi.DaftarPendaki; // Clean code: variable declaration jelas dan deskriptif
            reservasi.Jalur = updatedReservasi.Jalur;
            reservasi.Tanggal = updatedReservasi.Tanggal;
            reservasi.StatusPembayaran = updatedReservasi.StatusPembayaran;
            reservasi.Keterangan = updatedReservasi.Keterangan;
            reservasi.JumlahPendaki = updatedReservasi.JumlahPendaki;
            reservasi.IsCheckedIn = updatedReservasi.IsCheckedIn;
            reservasi.BarangBawaanSaatCheckin = updatedReservasi.BarangBawaanSaatCheckin;
            reservasi.BarangBawaanSaatCheckout = updatedReservasi.BarangBawaanSaatCheckout;
            reservasi.Status = updatedReservasi.Status;

            // Design by Contract - Postcondition
            Debug.Assert(reservasi.Id == id, "ID tidak boleh berubah setelah update.");
            Debug.Assert(reservasi.DaftarPendaki.Count == updatedReservasi.DaftarPendaki.Count, "Jumlah pendaki harus terupdate.");

            return Ok(reservasi);
        }

        // DELETE: api/reservasi/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteReservasi(int id)
        {
            // Design by Contract - Precondition
            Debug.Assert(id > 0, "ID harus lebih besar dari 0.");

            // Defensive
            if (id <= 0)
                return BadRequest("ID tidak valid.");

            var reservasi = ControllerReservasi.reservasiList.FirstOrDefault(r => r.Id == id);
            if (reservasi == null)
                return NotFound("Reservasi tidak ditemukan.");

            ControllerReservasi.reservasiList.Remove(reservasi);

            // Design by Contract - Postcondition
            Debug.Assert(!ControllerReservasi.reservasiList.Any(r => r.Id == id), "Reservasi masih ada setelah dihapus.");

            return NoContent();
        }
    }
}
