using System;
using System.Collections.Generic;
using System.Linq;
using HikepassLibrary.Model;

namespace HikepassLibrary.Service
{
    public class PengelolaService
    {
        private readonly ListPengelola _listPengelola;

        // Instance statis untuk singleton
        private static PengelolaService? _instance;

        // Objek sinkronisasi untuk thread safety
        private static readonly object LockObject = new object();

        // Konstruktor privat untuk mencegah instansiasi langsung
        private PengelolaService()
        {
            _listPengelola = new ListPengelola();
        }

        // Properti untuk mengakses instance singleton
        public static PengelolaService GetInstance()
        {
            if (_instance == null)
            {
                lock (LockObject) // Memastikan thread safety
                {
                    if (_instance == null)
                    {
                        _instance = new PengelolaService();
                    }
                }
            }
            return _instance;
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
            return _listPengelola.GetPengelolaById(id);
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
            pengelola.FullName = updatedPengelola.FullName;
            pengelola.Username = updatedPengelola.Username;
            pengelola.Password = updatedPengelola.Password;
            pengelola.Email = updatedPengelola.Email;
            Console.WriteLine($"Data pengelola dengan ID {id} berhasil diperbarui.");
        }

        public Pengelola GetPengelolaByUsername(string username)
        {
            return _listPengelola.GetAllPengelola()
                .FirstOrDefault(p => p.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public bool ValidasiPengelola(string username, string password)
        {
            var pengelola = _listPengelola.GetAllPengelola()
                .FirstOrDefault(p => p.Username == username);

            if (pengelola == null)
            {
                Console.WriteLine("Username tidak ditemukan.");
                return false;
            }

            if (pengelola.Password == password)
            {
                Console.WriteLine("Validasi berhasil.");
                return true;
            }
            else
            {
                Console.WriteLine("Password tidak sesuai.");
                return false;
            }
        }

        public Pengelola? Login(string username, string password)
        {
            return _listPengelola.GetAllPengelola()
                .FirstOrDefault(p => p.Username == username && p.Password == password);
        }
    }
}
