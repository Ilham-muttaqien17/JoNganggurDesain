using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JoNganggurDesain.ViewModel;
using System.ComponentModel;

namespace JoNganggurDesain.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage, INotifyPropertyChanged
    {
        DashboardVM dashboardVM;
        
        public Dashboard(string username)
        {
            Username = username;
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

        async void Rekomendasi1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailPage());
        }

        async void Rekomendasi2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailPage());
        }

        void MoveToLokasi(object sender, EventArgs e)
        {
            DisplayAlert("Message", "Comming Soon", "Oke");
        }

        async void MoveToLamaran(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LamaranPage());
        }

        async void MoveToNotifikasi(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotifikasiPage());
        }

        async void MoveToTerbaru(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TerbaruPage());
        }

        async void MoveToRiwayat(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RiwayatPage());
        }

        async void MoveToProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile(username));
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