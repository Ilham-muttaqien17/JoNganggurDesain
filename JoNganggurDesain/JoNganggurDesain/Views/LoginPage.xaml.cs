using JoNganggurDesain.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JoNganggurDesain.ViewModel;
using System.ComponentModel;

namespace JoNganggurDesain.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage, INotifyPropertyChanged
    {
        public bool verif;
        LoginViewModel loginViewModel;
        LoginAdminVM loginAdminVM;

        public event PropertyChangedEventHandler PropertyChanged;

        public LoginPage()
        {
            loginAdminVM = new LoginAdminVM();
            loginViewModel = new LoginViewModel();
            InitializeComponent();
            BindingContext = loginAdminVM;
            BindingContext = loginViewModel;
            CheckConnectivity();
            //Init();
            
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

        void CheckConnectivity()
        {
            CheckConnectivityOnStart();
            CheckConnectivityContinuously();
        }

        public void CheckConnectivityOnStart()
        {
            var Conn = CrossConnectivity.Current.IsConnected;
            if(Conn != true)
            {
                DisplayAlert("Message", "Tidak ada sambungan internet", "Oke");
            }

        }

        public void CheckConnectivityContinuously()
        {
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                var Conn = args.IsConnected;
                if (Conn != true)
                {
                    DisplayAlert("Message", "Tidak ada sambungan internet", "Oke");
                }
            };
        }

        async void SignInProcedure(object sender, EventArgs e)
        {
            verif = Switch.IsToggled;
            if (verif != true )
            {
                loginViewModel.Login();

            } else
            {
                if (string.IsNullOrEmpty(Entry_Username.Text) || string.IsNullOrEmpty(Entry_Password.Text))
                    await App.Current.MainPage.DisplayAlert("Data kosong", "Silahkan isi Username & Password!", "OK");
                else
                {
                    //call GetUser function which we define in Firebase helper class
                    var user = await FirebaseHelperAdmin.GetPerusahaan(Entry_Username.Text);
                    //firebase return null valuse if user data not found in database
                    if (user != null)
                        if (Entry_Username.Text == user.Username && Entry_Password.Text == user.Password)
                        {
                            await App.Current.MainPage.DisplayAlert("Login Sukses", "", "Ok");
                            //Navigate to Wellcom page after successfuly login
                            //pass user email to welcom page
                            await App.Current.MainPage.Navigation.PushAsync(new AdminP(Entry_Username.Text));
                        }
                        else
                            await App.Current.MainPage.DisplayAlert("Login Gagal", "Silahkan isi Username/password dengan benar!", "OK");
                    else
                        await App.Current.MainPage.DisplayAlert("Login Gagal", "Username/password tidak ditemukan!", "OK");
                }
            }
            
        }
        /*private async void Login()
        {
            //null or empty field validation, check weather email and password is null or empty    

            if (string.IsNullOrEmpty(Entry_Username.Text) || string.IsNullOrEmpty(Entry_Password.Text))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call GetUser function which we define in Firebase helper class    
                var pelamar = await FirebaseHelper.GetPelamar(Entry_Username.Text);
                //firebase return null valuse if user data not found in database    
                if (pelamar != null)
                    if (Entry_Username.Text == pelamar.Email && Entry_Password.Text == pelamar.Password)
                    {
                        await App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                        //Navigate to Wellcom page after successfuly login    
                        //pass user email to welcom page    
                        await App.Current.MainPage.Navigation.PushAsync(new Dashboard(Entry_Username.Text));
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
            }
        }*/

        async void MoveToRegister(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrasiPage());
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Peringatan!", "Anda yakin akan keluar?", "Yes", "No");
                if (result) await this.Navigation.PopAsync();
            });

            return true;
        }

    }
}