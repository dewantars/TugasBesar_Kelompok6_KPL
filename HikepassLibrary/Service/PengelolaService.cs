using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Controller;
using HikepassLibrary.Model;
using static HikepassLibrary.Model.User;

namespace HikepassLibrary.Service
{
    public class PengelolaService
    {
        private readonly ListPengelola _listPengelola;
        public PengelolaService()
        {
            _listPengelola = new ListPengelola();
        }
        public void AddPengelola(Pengelola pengelola)
        {
            if (pengelola == null)
            {
                Console.WriteLine("Pengelola tidak valid.");
                return;
            }
            if (_listPengelola.GetPengelolaById(pengelola.Id) != null)
            {
                Console.WriteLine($"Pengelola dengan ID {pengelola.Id} sudah ada.");
                return;
            }
            _listPengelola.AddPengelola(pengelola);
            Console.WriteLine($"Pengelola {pengelola.FullName} berhasil ditambahkan.");
        }
        public void RemovePengelola(int id)
        {
            var pengelola = _listPengelola.GetPengelolaById(id);
            if (pengelola == null)
            {
                Console.WriteLine($"Pengelola dengan ID {id} tidak ditemukan.");
                return;
            }
            _listPengelola.RemovePengelola(pengelola);
            Console.WriteLine($"Pengelola {pengelola.FullName} berhasil dihapus.");
        }
        public Pengelola GetPengelolaById(int id)
        {
            var pengelola = _listPengelola.GetPengelolaById(id);
            if (pengelola == null)
            {
                Console.WriteLine($"Pengelola dengan ID {id} tidak ditemukan.");
                return null;
            }
            return pengelola;
        }
        public void GetAllPengelola()
        {
            var pengelolaList = _listPengelola.GetAllPengelola();
            if (pengelolaList.Count == 0)
            {
                Console.WriteLine("Tidak ada pengelola yang terdaftar.");
                return;
            }
            foreach (var peng in pengelolaList)
            {
                Console.WriteLine($"ID: {peng.Id}, Nama: {peng.FullName}, Email: {peng.Email}");
            }
        }
        public void ClearPengelolaList()
        {
            _listPengelola.ClearPengelolaList();
            Console.WriteLine("Daftar pengelola telah dikosongkan.");
        }
        public int CountPengelola()
        {
            return _listPengelola.CountPengelola();
        }
        public void UpdatePengelola(int id, Pengelola updatedPengelola)
        {
            var pengelola = _listPengelola.GetPengelolaById(id);
            if (pengelola == null)
            {
                Console.WriteLine($"Pengelola dengan ID {id} tidak ditemukan.");
                return;
            }
            pengelola = updatedPengelola;
            Console.WriteLine($"Data pengelola dengan ID {id} berhasil diperbarui.");
        }
        public bool ValidatePengelola(string username, string password)
        {
            var pengelola = _listPengelola.GetAllPengelola().FirstOrDefault(p => p.Username == username);
            if (pengelola == null)
            {
                Console.WriteLine("Pengelola tidak ditemukan.");
                return false;
            }
            if (pengelola.Password != password)
            {
                Console.WriteLine("Password salah.");
                return false;
            }
            else
            {
                Console.WriteLine($"Login berhasil untuk pengelola {pengelola.FullName}.");
                return true;
            }
            
        }
        public Pengelola GetPendakiByUsername(string username)
        {
            return _listPengelola.GetAllPengelola()
                .FirstOrDefault(p => p.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
