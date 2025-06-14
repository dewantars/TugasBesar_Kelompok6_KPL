using System;
using System.Linq;
using HikepassLibrary.Model;

namespace HikepassLibrary.Service
{
    public sealed class PendakiService
    {
        // Field statis untuk menyimpan satu-satunya instance.
        private static PendakiService? _instance;

        // Lock untuk mendukung thread safety.
        private static readonly object _lock = new object();

        private readonly ListPendaki _listPendaki;

        // Konstruktor privat untuk mencegah instansiasi langsung.
        private PendakiService()
        {
            _listPendaki = new ListPendaki();
        }

        // Metode statis untuk mengakses instance tunggal.
        public static PendakiService GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new PendakiService();
                    }
                }
            }
            return _instance;
        }

        // Semua metode instance tetap sama seperti sebelumnya.
        public void AddPendaki(Pendaki pendaki)
        {
            if (pendaki == null || string.IsNullOrEmpty(pendaki.FullName) || string.IsNullOrEmpty(pendaki.Email))
            {
                throw new ArgumentException("Pendaki tidak valid. Pastikan data lengkap dan benar.");
            }

            if (_listPendaki.GetPendakiById(pendaki.Id) != null)
            {
                throw new ArgumentException($"Pendaki dengan ID {pendaki.Id} sudah ada.");
            }

            _listPendaki.AddPendaki(pendaki);
            Console.WriteLine($"Pendaki {pendaki.FullName} berhasil ditambahkan.");
        }

        public void RemovePendaki(int id)
        {
            var pendaki = _listPendaki.GetPendakiById(id);
            if (pendaki == null)
            {
                Console.WriteLine($"Pendaki dengan ID {id} tidak ditemukan.");
                return;
            }
            _listPendaki.RemovePendaki(pendaki);
            Console.WriteLine($"Pendaki {pendaki.FullName} berhasil dihapus.");
        }

        public Pendaki GetPendakiById(int id)
        {
            var pendaki = _listPendaki.GetPendakiById(id);
            if (pendaki == null)
            {
                Console.WriteLine($"Pendaki dengan ID {id} tidak ditemukan.");
                return null;
            }
            return pendaki;
        }

        public void GetAllPendaki()
        {
            var pendakiList = _listPendaki.GetAllPendaki();
            if (pendakiList.Count == 0)
            {
                Console.WriteLine("Tidak ada pendaki yang terdaftar.");
                return;
            }

            Console.WriteLine("Daftar Pendaki:");
            foreach (var pendaki in pendakiList)
            {
                Console.WriteLine($"ID: {pendaki.Id}, Nama: {pendaki.FullName}, Email: {pendaki.Email}");
            }
        }

        public void ClearPendakiList()
        {
            _listPendaki.ClearPendakiList();
            Console.WriteLine("Daftar pendaki berhasil dikosongkan.");
        }

        public int CountPendaki()
        {
            return _listPendaki.CountPendaki();
        }

        public void UpdatePendaki(int id, Pendaki updatedPendaki)
        {
            var pendaki = _listPendaki.GetPendakiById(id);
            if (pendaki == null)
            {
                Console.WriteLine($"Pendaki dengan ID {id} tidak ditemukan.");
                return;
            }
            if (!string.IsNullOrEmpty(updatedPendaki.FullName)) pendaki.FullName = updatedPendaki.FullName;
            if (!string.IsNullOrEmpty(updatedPendaki.Email)) pendaki.Email = updatedPendaki.Email;
            if (!string.IsNullOrEmpty(updatedPendaki.Username)) pendaki.Username = updatedPendaki.Username;
            if (!string.IsNullOrEmpty(updatedPendaki.Password)) pendaki.Password = updatedPendaki.Password;

            Console.WriteLine($"Pendaki dengan ID {id} berhasil diperbarui.");
        }

        public bool ValidasiPendaki(string username, string password)
        {
            var pendaki = _listPendaki.GetAllPendaki()
                .FirstOrDefault(p => p.Username == username);

            if (pendaki == null)
            {
                Console.WriteLine("Username tidak ditemukan.");
                return false;
            }

            if (pendaki.Password == password)
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

        public Pendaki GetPendakiByUsername(string username)
        {
            return _listPendaki.GetAllPendaki()
                .FirstOrDefault(p => p.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public Pendaki? Login(string username, string password)
        {
            return _listPendaki.GetAllPendaki()
                .FirstOrDefault(p => p.Username == username && p.Password == password);
        }
    }
}
