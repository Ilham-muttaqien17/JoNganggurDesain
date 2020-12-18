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
        public EditProfile()
        {
            InitializeComponent();
        }
        async void MoveToProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }
        async void UpdateProfileProcedure(object sender, EventArgs e)
        {
            await DisplayAlert("Update", "Update Sukses", "Oke");
        }
    }
}