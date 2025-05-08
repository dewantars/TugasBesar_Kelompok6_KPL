using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public class User
    {
        
        public string Id { get; set; }        // ID unik user
        public string Name { get; set; }      // Nama pendaki
        public string Status { get; set; }    // Status pendakian: "paid", "checked_in", "checked_out"

        public User(string id, string name)
        {
            Id = id;
            Name = name;
            Status = "paid"; // Default setelah pembayaran
        }
    }
}
