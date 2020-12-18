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
        public EditProfilPenyedia()
        {
            InitializeComponent();
        }
        async void MoveToProfilPenyedia(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilPenyedia());
        }
        async void UpdateProfilPenyedia(object sender, EventArgs e)
        {
            await DisplayAlert("Update", "Update Sukses", "Oke");
        }
    }
}