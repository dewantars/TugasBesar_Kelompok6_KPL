using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public class Pendaki : User
    {
        public int Id { get; set; }         // ID Pendaki
        public string Nama { get; set; }       // Nama Pendaki
        public string Kontak { get; set; }     // Kontak Pendaki
        public string Alamat { get; set; }     // Alamat Pendaki
        public string Nik { get; set; }        // NIK Pendaki
        public int Usia { get; set; }          // Usia Pendaki
        public Pendaki() { }
        public Pendaki(string username, string password, string fullName, string email)
        {
            this.Username = username;
            this.Password = password;
            this.FullName = fullName;
            this.Email = email;
        }
    }
}

