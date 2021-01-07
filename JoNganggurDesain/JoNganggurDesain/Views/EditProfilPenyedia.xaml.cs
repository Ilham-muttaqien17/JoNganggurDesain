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
    public partial class EditProfilPenyedia : ContentPage
    {
        AdminPVM adminPVM;
        public EditProfilPenyedia(string username)
        {
            Username = username;
            Read();
            InitializeComponent();
            adminPVM = new AdminPVM(username);
            BindingContext = adminPVM;
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

        async void MoveToProfilPenyedia(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilPenyedia(Username));
        }
        async void UpdateProfilPenyedia(object sender, EventArgs e)
        {
            //await DisplayAlert("Update", "Update Sukses", "Oke");
        }
    }
}