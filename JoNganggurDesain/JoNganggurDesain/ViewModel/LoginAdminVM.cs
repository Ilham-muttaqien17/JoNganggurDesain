﻿using JoNganggurDesain.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace JoNganggurDesain.ViewModel
{
    public class LoginAdminVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginAdminVM()
        {

        }
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }

        public async void Login()
        {
            //null or empty field validation, check weather email and password is null or empty

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Data kosong", "Silahkan isi Username & Password!", "OK");
            else
            {
                //call GetUser function which we define in Firebase helper class
                var user = await FirebaseHelperAdmin.GetPerusahaan(Username);
                //firebase return null valuse if user data not found in database
                if (user != null)
                    if (Username == user.Username && Password == user.Password)
                    {
                        await App.Current.MainPage.DisplayAlert("Login Sukses", "", "Ok");
                        //Navigate to Wellcom page after successfuly login
                        //pass user email to welcom page
                        await App.Current.MainPage.Navigation.PushAsync(new AdminP(Username));
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Login Gagal", "Silahkan isi Username/password dengan benar!", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Login Gagal", "Username/password tidak ditemukan!", "OK");
            }
        }
    }
}
