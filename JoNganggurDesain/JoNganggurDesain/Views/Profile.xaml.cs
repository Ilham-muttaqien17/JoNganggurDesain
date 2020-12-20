using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JoNganggurDesain.ViewModel;
using Firebase.Database;
using JoNganggurDesain.Models;

namespace JoNganggurDesain.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        FirebaseClient firebase = new FirebaseClient("https://jonganggur-b20fe-default-rtdb.firebaseio.com/");
        DashboardVM dashboardVM;
        public Profile(string username)
        {
            Username = username;
            Test();
            InitializeComponent();
            dashboardVM = new DashboardVM(username);
            BindingContext = dashboardVM;
            CheckConnectivity();

        }
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
            }
        }

        public async void Test()
        {
            var person = await FirebaseHelper.GetPelamar(Username);
            if (person != null)
            {
                if(person.Username == username)
                {
                    txtNama.Text = person.Nama;
                    txtUsername.Text = person.Username;
                    txtPassword.Text = person.Password;
                    dateTglLahir.Date = person.Tgl_lahir;
                    txtEmail.Text = person.Email;
                    txtDeskripsi.Text = person.Deskripsi;
                    txtKontak.Text = person.Kontak;
                    titleUsername.Text = txtUsername.Text;
                }
                

            }
            else
            {
                await DisplayAlert("Success", "No Person Available", "OK");
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
            if (Conn != true)
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

        async void MoveToDashboard(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Dashboard(Username));
        }

        async void MoveToRiwayat(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RiwayatPage());
        }
        async void MoveToEditProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfile());
        }

        async void SignOutProcedure(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}