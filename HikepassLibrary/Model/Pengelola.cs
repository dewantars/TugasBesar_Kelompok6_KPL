using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

// Pengelola.cs
namespace HikepassLibrary.Model
{
    public class Pengelola
    {
        public int Id { get; set; }         // ID Pengelola
        public string Nama { get; set; }       // Nama Pengelola
        public string Kontak { get; set; }     // Kontak Pengelola

        // Constructor untuk mempermudah pembuatan objek Pengelola
        public Pengelola(int id, string nama, string kontak)
        {
            Id = id;
            Nama = nama;
            Kontak = kontak;
        }
    }
}

