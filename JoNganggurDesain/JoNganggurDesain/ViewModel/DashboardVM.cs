using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using JoNganggurDesain.Models;
using System.ComponentModel;

using JoNganggurDesain.Views;
using System.Diagnostics;

namespace JoNganggurDesain.ViewModel
{
    public class DashboardVM : INotifyPropertyChanged
    {
        public DashboardVM(string username2)
        {
            Username = username2;
        }
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        private string nama;

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        private DateTime tgl_lahir;

        public DateTime Tgl_lahir
        {
            get { return tgl_lahir; }
            set { tgl_lahir = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string kontak;

        public string Kontak
        {
            get { return kontak; }
            set { kontak = value; }
        }

        private string deskripsi;

        public string Deskripsi
        {
            get { return deskripsi; }
            set { deskripsi = value; }
        }

        public Command UpdateCommand
        {
            get { return new Command(Update); }
        }

        private async void Update()
        {
            try
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    var isupdate = await FirebaseHelper.UpdatePelamar(Nama,  Username,  Password,  Tgl_lahir,  Email,  Kontak,  Deskripsi);
                    if (isupdate)
                    {
                        await App.Current.MainPage.DisplayAlert("Update Success", "", "Ok");
                        await App.Current.MainPage.Navigation.PushAsync(new Profile(username));
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Record not update", "Ok");
                    }
                        
                }
                else
                    await App.Current.MainPage.DisplayAlert("Password Require", "Please Enter your password", "Ok");
            }
            catch (Exception e)
            {

                Debug.WriteLine($"Error:{e}");
            }
        }

        //For Logout
        public Command LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PopAsync();
                });
            }
        }
        //Update user data

        //Delete user data
        public Command ProfilCommand
        {
            get
            {
                return new Command(ProfilShow);
            }
        }
        private async void ProfilShow()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Profile(Username));
        }
    }
}
