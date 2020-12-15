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
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
        }

        async void MoveToDashboard(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Dashboard());
        }

        async void MoveToRiwayat(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RiwayatPage());
        }

        async void SignOutProcedure(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}