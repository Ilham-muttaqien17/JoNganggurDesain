using JoNganggurDesain.Models;
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
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            ActivitySpinner.IsVisible = false;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        async void SignInProcedure(object sender, EventArgs e)
        {
            if ( )
            {
                
            }
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            
            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login Sukses", "Oke");
                await Navigation.PushAsync(new Dashboard());
            } else
            {
                await DisplayAlert("Login", "Login Gagal", "Oke");
            }
        }

        async void MoveToRegister(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrasiPage());
        }
        
    }
}