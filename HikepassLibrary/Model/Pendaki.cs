using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public class Pendaki
    {
        public int Id { get; set; }         // ID Pendaki
        public string Nama { get; set; }       // Nama Pendaki
        public string Kontak { get; set; }     // Kontak Pendaki
        public string Alamat { get; set; }     // Alamat Pendaki
        public string Nik { get; set; }        // NIK Pendaki
        public int Usia { get; set; }          // Usia Pendaki
        public Pendaki() { }

        // Constructor untuk mempermudah pembuatan objek Pendaki
        public Pendaki(int id, string nama, string kontak, string alamat, string nik, int usia)
        {
            Id = id;
            Nama = nama;
            Kontak = kontak;
            Alamat = alamat;
            Nik = nik;
            Usia = usia;
        }
    }
}

