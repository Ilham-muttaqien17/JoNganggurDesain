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
    public class FirebaseHelperAdmin
    {
        public static FirebaseClient firebase = new FirebaseClient("https://jonganggur-b20fe-default-rtdb.firebaseio.com/");

        //Read All Perusahaan
        public static async Task<List<Perusahaan>> GetAllPerusahaan()
        {
            try
            {
                var perusahaanlist = (await firebase
                .Child("Perusahaan")
                .OnceAsync<Perusahaan>()).Select(item =>
                new Perusahaan
                {
                    NamaP = item.Object.NamaP,
                    Username = item.Object.Username,
                    Password = item.Object.Password,
                    Alamat = item.Object.Alamat,
                    Tentang = item.Object.Tentang,
                }).ToList();
                return perusahaanlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Read     
        public static async Task<Perusahaan> GetPerusahaan(string username)
        {
            try
            {
                var allPerusahaan = await GetAllPerusahaan();
                await firebase
                .Child("Perusahaan")
                .OnceAsync<Perusahaan>();
                return allPerusahaan.Where(a => a.Username == username).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        // Add Perusahaan
        public static async Task<bool> AddPerusahaan(string namap, string username, string password, string alamat, string tentang)
        {
            try
            {
                await firebase
                .Child("Perusahaan")
                .PostAsync(new Perusahaan() { NamaP = namap, Username = username, Password = password, Alamat = alamat, Tentang = tentang });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Update Perusahaan
        public static async Task<bool> UpdatePerusahaan(string namap, string username, string password, string alamat, string tentang)
        {
            try
            {


                var toUpdatePerusahaan = (await firebase
                .Child("Perusahaan")
                .OnceAsync<Perusahaan>()).Where(a => a.Object.Username == username).FirstOrDefault();
                await firebase
                .Child("Perusahaan")
                .Child(toUpdatePerusahaan.Key)
                .PutAsync(new Perusahaan() { NamaP = namap, Username = username, Password = password, Alamat = alamat, Tentang = tentang});
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
