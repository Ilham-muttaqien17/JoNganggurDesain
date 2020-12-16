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
    public partial class PostingPekerjaan : ContentPage
    {
        public PostingPekerjaan()
        {
            InitializeComponent();
            CheckConnectivity();
            BindingContext = new PekerjaanViewModel();
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

        public async void postingPekerjaan(object sender, EventArgs e)
        {
            var Conn = CrossConnectivity.Current.IsConnected;
            if(Conn == true)
            {
                await DisplayAlert("Pesan", "Berhasil memposting pekerjaan", "Oke");
                await Navigation.PushAsync(new AdminP());
            } else
            {
                await DisplayAlert("Peringatan", "Tidak ada sambungan internet", "Oke");
            }
        }
    }
}