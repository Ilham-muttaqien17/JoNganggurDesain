using Firebase.Database;
using Firebase.Database.Query;
using JoNganggurDesain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace JoNganggurDesain.Services
{
    public class DBFirebase
    {
        FirebaseClient client;
        public DBFirebase()
        {
            client = new FirebaseClient("https://jonganggur-b20fe-default-rtdb.firebaseio.com/");
        }
        public ObservableCollection<Pelamar> getPelamar()
        {
            var pelamarData = client
                .Child("Pelamar")
                .AsObservable<Pelamar>()
                .AsObservableCollection();

            return pelamarData;
        }

        public ObservableCollection<Pekerjaan> getPekerjaan()
        {
            var pekerjaanData = client
                .Child("Pekerjaan")
                .AsObservable<Pekerjaan>()
                .AsObservableCollection();

            return pekerjaanData;
        }

        public async Task AddPelamar(string nama, string username, string password, DateTime tgl_lahir, string email, string kontak, string deskripsi)
        {
            Pelamar p = new Pelamar()
            {
                Nama = nama,
                Username = username,
                Password = password,
                Tgl_lahir = tgl_lahir,
                Email = email,
                Kontak = kontak,
                Deskripsi = deskripsi
            };
            await client
                .Child("Pelamar")
                .PostAsync(p);
        }

        public async Task AddPekerjaan(string nama, string gaji, string syarat, string deskripsi, string id_penyedia, string namaPerusahaan)
        {
            Pekerjaan p = new Pekerjaan()
            {
                Nama = nama,
                Gaji = gaji,
                Syarat = syarat,
                Deskripsi = deskripsi,
                id_Penyedia = id_penyedia,
                namaPerusahaan = namaPerusahaan
            };
            await client
                .Child("Pekerjaan")
                .PostAsync(p);
        }
    }
}
