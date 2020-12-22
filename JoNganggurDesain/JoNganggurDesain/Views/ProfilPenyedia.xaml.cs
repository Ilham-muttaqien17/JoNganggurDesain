using Firebase.Database;
using JoNganggurDesain.ViewModel;
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
    public partial class ProfilPenyedia : ContentPage
    {
        FirebaseClient firebase = new FirebaseClient("https://jonganggur-b20fe-default-rtdb.firebaseio.com/");
        AdminPVM adminPVM;
        public ProfilPenyedia(string username)
        {
            Username = username;
            Read();
            InitializeComponent();
            adminPVM = new AdminPVM(username);
            BindingContext = adminPVM;
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

        public async void Read()
        {
            var person = await FirebaseHelperAdmin.GetPerusahaan(Username);
            if (person != null)
            {
                if (person.Username == username)
                {
                    txtNama.Text = person.NamaP;
                    txtUsername.Text = person.Username;
                    txtPassword.Text = person.Password;
                    txtAlamat.Text = person.Alamat;
                    txtTentang.Text = person.Tentang;
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
        async void SignOutProcedure(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        async void MoveToEditProfilPenyedia(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfilPenyedia(Username));
        }
    }
}