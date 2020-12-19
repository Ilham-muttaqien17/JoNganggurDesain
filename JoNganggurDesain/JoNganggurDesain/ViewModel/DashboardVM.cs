using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using JoNganggurDesain.Models;
using System.ComponentModel;

using JoNganggurDesain.Views;

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
        /*       public Command UpdateCommand
               {
                   get { return new Command(Update); }
               }

               public Command DeleteCommand
               {
                   get { return new Command(Delete); }
               }*/
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
