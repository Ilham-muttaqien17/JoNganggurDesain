using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JoNganggurDesain.ViewModel;

namespace JoNganggurDesain.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        DashboardVM dashboardVM;
        public Profile(string username)
        {
            InitializeComponent();
            dashboardVM = new DashboardVM(username);
            BindingContext = dashboardVM;
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