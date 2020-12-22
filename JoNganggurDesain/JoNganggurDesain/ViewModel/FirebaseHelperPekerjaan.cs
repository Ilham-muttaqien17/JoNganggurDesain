using Firebase.Database;
using Firebase.Database.Query;
using JoNganggurDesain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoNganggurDesain.ViewModel
{
    public class FirebaseHelperPekerjaan
    {
        public static FirebaseClient firebase = new FirebaseClient("https://jonganggur-b20fe-default-rtdb.firebaseio.com/");
        public static async Task<List<Pekerjaan>> GetAdminKey()
        {
            try
            {
                var adminKey = (await firebase
                    .Child("Perusahaan")
                    .Child(adminKey.Key));
                return adminKey;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }

        }
        //Read All Perusahaan
        public static async Task<List<Pekerjaan>> GetAllPekerjaan()
        {
            try
            {
                var pekerjaanlist = (await firebase
                .Child("Pekerjaan")
                .OnceAsync<Pekerjaan>()).Select(item =>
                new Pekerjaan
                {
                    Nama = item.Object.Nama,
                    Gaji = item.Object.Gaji,
                    Deskripsi = item.Object.Deskripsi,
                    Syarat = item.Object.Syarat,
                    id_Pelamar = item.Object.id_Pelamar,
                    id_Penyedia = item.Object.id_Penyedia,
                }).ToList();
                return pekerjaanlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Read     

        // Add Pekerjaan
        public static async Task<bool> AddPekerjaan(string nama, string gaji, string deskripsi, string syarat)
        {
            try
            {
                await firebase
                .Child("Pekerjaan")
                .PostAsync(new Pekerjaan() { Nama = nama, Gaji = gaji, Deskripsi = deskripsi, Syarat = syarat });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

     

    }
}
