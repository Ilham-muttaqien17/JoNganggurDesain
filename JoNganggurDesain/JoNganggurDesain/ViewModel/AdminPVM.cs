using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using JoNganggurDesain.Views;

namespace JoNganggurDesain.ViewModel
{
    public class AdminPVM : INotifyPropertyChanged
    {
        public AdminPVM(string username2)
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
        private string namap;

        public string NamaP
        {
            get { return namap; }
            set { namap = value; }
        }

        private string alamat;

        public string Alamat
        {
            get { return alamat; }
            set { alamat = value; }
        }

        private string tentang;

        public string Tentang
        {
            get { return tentang; }
            set { tentang = value; }
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
                    var isupdate = await FirebaseHelperAdmin.UpdatePerusahaan(NamaP, Username, Password, Alamat, Tentang);
                    if (isupdate)
                    {
                        await App.Current.MainPage.DisplayAlert("Update Success", "", "Ok");
                        await App.Current.MainPage.Navigation.PushAsync(new ProfilPenyedia(username));
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
            await App.Current.MainPage.Navigation.PushAsync(new ProfilPenyedia(Username));
        }
    }
}
