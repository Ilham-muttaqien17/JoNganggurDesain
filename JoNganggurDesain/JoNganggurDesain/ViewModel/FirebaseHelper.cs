using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoNganggurDesain.Models;

namespace JoNganggurDesain.ViewModel {
        public class FirebaseHelper
        {
            //Connect app with firebase using API Url  
            public static FirebaseClient firebase = new FirebaseClient("https://jonganggur-b20fe-default-rtdb.firebaseio.com/");

            //Read All    
            public static async Task<List<Pelamar>> GetAllPelamar()
            {
                try
                {
                    var pelamarlist = (await firebase
                    .Child("Pelamar")
                    .OnceAsync<Pelamar>()).Select(item =>
                    new Pelamar
                    {
                        Nama = item.Object.Nama,
                        Username = item.Object.Username,
                        Password = item.Object.Password,
                        Tgl_lahir = item.Object.Tgl_lahir,
                        Email = item.Object.Email,
                        Kontak = item.Object.Kontak,
                        Deskripsi = item.Object.Deskripsi,
                    }).ToList();
                    return pelamarlist;
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error:{e}");
                    return null;
                }
            }

            //Read     
            public static async Task<Pelamar> GetPelamar(string username)
            {
                try
                {
                    var allPelamar = await GetAllPelamar();
                    await firebase
                    .Child("Pelamar")
                    .OnceAsync<Pelamar>();
                    return allPelamar.Where(a => a.Username == username).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error:{e}");
                    return null;
                }
            }

            //Inser a user    
          public static async Task<bool> AddPelamar(string nama, string username, string password, DateTime tgl_lahir, string email, int kontak, string deskripsi)
            {
                try
                {
                    await firebase
                    .Child("Pelamar")
                    .PostAsync(new Pelamar() { Nama = nama, Username = username, Password = password, Tgl_lahir = tgl_lahir, Email = email, Kontak = kontak, Deskripsi = deskripsi });
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error:{e}");
                    return false;
                }
            }

            //Update     
            public static async Task<bool> UpdatePelamar(string nama, string username, string password, DateTime tgl_lahir, string email, int kontak, string deskripsi)
            {
                try
                {


                    var toUpdatePelamar = (await firebase
                    .Child("Pelamar")
                    .OnceAsync<Pelamar>()).Where(a => a.Object.Username == username).FirstOrDefault();
                    await firebase
                    .Child("Pelamar")
                    .Child(toUpdatePelamar.Key)
                    .PutAsync(new Pelamar() { Nama = nama, Username = username, Password = password, Tgl_lahir = tgl_lahir, Email = email, Kontak = kontak, Deskripsi = deskripsi });
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error:{e}");
                    return false;
                }
            }

            //Delete User    
            public static async Task<bool> DeletePelamar(string username)
            {
                try
                {


                    var toDeletePelamar = (await firebase
                    .Child("Pelamar")
                    .OnceAsync<Pelamar>()).Where(a => a.Object.Username == username).FirstOrDefault();
                    await firebase.Child("Pelamar").Child(toDeletePelamar.Key).DeleteAsync();
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

