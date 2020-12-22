using JoNganggurDesain.Models;
using JoNganggurDesain.Services;
using JoNganggurDesain.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JoNganggurDesain.ViewModel
{
    public class PekerjaanViewModel : BaseViewModel
    {
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;

            }
        }

        private string nama;
        public string Nama
        {
            get { return nama; }
            set
            {
                nama = value;
            
            }
        }
        private string gaji;
        public string Gaji
        {
            get { return gaji; }
            set
            {
                gaji = value;
                
            }
        }
        private string deskripsi;

        public string Deskripsi
        {
            get { return deskripsi; }
            set
            {
                deskripsi = value;
                
            }
        }
        private string syarat;

        public string Syarat
        {
            get { return syarat; }
            set
            {
                syarat = value;

            }
        }


        public Command AddPekerjaanCommand
        {
            get
            {
                return new Command(() =>
                {
                    PostingPekerjaan();
                });
            }
        }
       
        private async void PostingPekerjaan()
        {
            //null or empty field validation, check weather email and password is null or empty    

            if (string.IsNullOrEmpty(Nama) || string.IsNullOrEmpty(Gaji) ||
                string.IsNullOrEmpty(Deskripsi) || string.IsNullOrEmpty(Syarat))
                await App.Current.MainPage.DisplayAlert("Peringatan", "Harap isi semua data!", "OK");
            else
            {
                //call AddUser function which we define in Firebase helper class    
                var user = await FirebaseHelperPekerjaan.AddPekerjaan(Nama, Gaji, Deskripsi, Syarat);
                //AddUser return true if data insert successfuly     
                if (user)
                {
                    await App.Current.MainPage.DisplayAlert("Daftar Sukses", "", "Ok");
                    //Navigate to Wellcom page after successfuly SignUp    
                    //pass user email to welcom page    
                    await App.Current.MainPage.Navigation.PushAsync(new AdminP(Username));
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "Daftar Gagal", "OK");

            }
        }
    }
}
