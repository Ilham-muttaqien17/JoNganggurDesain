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

namespace JoNganggurDesain.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public bool verif;
        LoginViewModel loginViewModel;
        public LoginPage()
        {
            loginViewModel = new LoginViewModel();
            InitializeComponent();
            BindingContext = loginViewModel;
            CheckConnectivity();
            //Init();
            
        }

        /*void Init()
        {
            ActivitySpinner.IsVisible = false;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }*/

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

       /* async void SignInProcedure(object sender, EventArgs e)
        {
            verif = Switch.IsToggled;
            if (verif == true )
            {
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

            } else
            {
                User user = new User(Entry_Username.Text, Entry_Password.Text);

                if (user.CheckInformation())
                {
                    await DisplayAlert("Login", "Login Sukses", "Oke");
                    await Navigation.PushAsync(new Dashboard(Entry_Username.Text));
                }
                else
                {
                    await DisplayAlert("Login", "Login Gagal", "Oke");
                }
            }
            
        }*/
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