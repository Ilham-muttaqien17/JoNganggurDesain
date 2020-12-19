using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using JoNganggurDesain.ViewModel;
using JoNganggurDesain.Views;

namespace JoNganggurDesain.ViewModel
{
    public class SignUpVM : INotifyPropertyChanged
    {
        private string nama;
        public string Nama
        {
            get { return nama; }
            set
            {
                nama = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Nama"));
            }
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

        private string confirmpassword;
        public string ConfirmPassword
        {
            get { return confirmpassword; }
            set
            {
                confirmpassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }
        public Command AddPelamarCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Password == ConfirmPassword)
                        SignUp();
                    else
                        App.Current.MainPage.DisplayAlert("", "Password must be same as above!", "OK");
                });
            }
        }
        private DateTime tgl_lahir;
        public DateTime Tgl_lahir
        {
            get { return tgl_lahir; }
            set
            {
                tgl_lahir = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Tgl_lahir"));
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private int kontak;
        public int Kontak
        {
            get { return kontak; }
            set
            {
                kontak = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Kontak"));
            }
        } 
        private string deskripsi;
        public string Deskripsi
        {
            get { return deskripsi; }
            set
            {
                deskripsi = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Deskripsi"));
            }
        }
        private async void SignUp()
        {
            //null or empty field validation, check weather email and password is null or empty    

            if  (string.IsNullOrEmpty(Nama) || string.IsNullOrEmpty(Username) ||
                string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Deskripsi))
                await App.Current.MainPage.DisplayAlert("Peringatan", "Harap isi semua data!", "OK");
            else
            {
                //call AddUser function which we define in Firebase helper class    
                var user = await FirebaseHelper.AddPelamar(Nama, Username, Password, Tgl_lahir, Email, Kontak, Deskripsi);
                //AddUser return true if data insert successfuly     
                if (user)
                {
                    await App.Current.MainPage.DisplayAlert("Daftar Sukses", "", "Ok");
                    //Navigate to Wellcom page after successfuly SignUp    
                    //pass user email to welcom page    
                    await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "Daftar Gagal", "OK");

            }
        }
    }
}
