using JoNganggurDesain.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JoNganggurDesain.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public bool verif;
        public LoginPage()
        {
            InitializeComponent();
            CheckConnectivity();
            Init();
            
        }

        void Init()
        {
            ActivitySpinner.IsVisible = false;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
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
            if (verif == true )
            {
                User user = new User(Entry_Username.Text, Entry_Password.Text);

                if (user.CheckInformation())
                {
                    await DisplayAlert("Login", "Login Sukses", "Oke");
                    await Navigation.PushAsync(new AdminP());
                }
                else
                {
                    await DisplayAlert("Login", "Login Gagal", "Oke");
                }

            } else
            {
                User user = new User(Entry_Username.Text, Entry_Password.Text);

                if (user.CheckInformation())
                {
                    await DisplayAlert("Login", "Login Sukses", "Oke");
                    await Navigation.PushAsync(new Dashboard());
                }
                else
                {
                    await DisplayAlert("Login", "Login Gagal", "Oke");
                }
            }
            
        }

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