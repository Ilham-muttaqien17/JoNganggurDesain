using System;
using System.Collections.Generic;
using System.Text;

namespace JoNganggurDesain.Models
{
    public class Pekerjaan
    {
        public string Nama { get; set; }
        public string Gaji { get; set; }
        public string Syarat { get; set; }
        public string Deskripsi { get; set; }
        public string id_Pelamar { get; set; }
        public string id_Penyedia { get; set; }
    }
}
