using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public class Pendaki : User
    {
        public int Id { get; set; }         
        public string Nama { get; set; }       
        public string Kontak { get; set; }     
        public string Alamat { get; set; }     
        public string Nik { get; set; }        
        public int Usia { get; set; }          
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

