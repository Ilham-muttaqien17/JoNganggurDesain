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
    public partial class RiwayatPage : ContentPage
    {
        public RiwayatPage()
        {
            InitializeComponent();
            CheckConnectivity();
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

        void Test(object sender, EventArgs e)
        {
            DisplayAlert("asd", "zxc", "qwe");
        }

        async void MoveToDashboard(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Dashboard(Username));
        }

        async void MoveToProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }
    }
}