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
    public partial class AdminP : ContentPage
    {
        AdminPVM adminPVM;
        public AdminP(string username)
        {
            Username = username;
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
        async void MoveToPostingP(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PostingPekerjaan());
        }
        async void MoveToLamaranM(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LamaranMasuk());
        }
        async void MoveToProfil(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilPenyedia(username));
        }
        async void MoveToPekerjaanDiposting(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PekerjaanDiposting());
        }
        async void MoveToPekerjaAktif(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PekerjaAktif());
        }
    }
}