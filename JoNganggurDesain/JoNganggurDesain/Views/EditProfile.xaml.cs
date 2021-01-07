using JoNganggurDesain.ViewModel;
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
    public partial class EditProfile : ContentPage
    {
        DashboardVM dashboardVM;
        public EditProfile(string username)
        {
            Username = username;
            Test();
            InitializeComponent();
            dashboardVM = new DashboardVM(username);
            BindingContext = dashboardVM;
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
                if (person.Username == username)
                {
                    txtNama.Text = person.Nama;
                    txtPassword.Text = person.Password;
                    dateTglLahir.Date = person.Tgl_lahir;
                    txtEmail.Text = person.Email;
                    txtDeskripsi.Text = person.Deskripsi;
                    txtKontak.Text = person.Kontak;
                }


            }
            else
            {
                await DisplayAlert("Success", "No Person Available", "OK");
            }

        }

        async void MoveToProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile(username));
        }
        async void UpdateProfileProcedure(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Profile(username));
        }
    }
}