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
    public partial class RegistrasiPage : ContentPage
    {
        public RegistrasiPage()
        {
            InitializeComponent();
        }

        async void SignUpProcedure(object sender, EventArgs e)
        {
            DisplayAlert("Register", "Registrasi Berhasil", "Oke");
            await Navigation.PushAsync(new LoginPage());
        }

        async void MoveToLogin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}