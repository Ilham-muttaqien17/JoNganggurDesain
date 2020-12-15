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
    public partial class AdminP : ContentPage
    {
        public AdminP()
        {
            InitializeComponent();
        }
        async void MoveToPostingP(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PostingPekerjaan());
        }
        async void MoveToLamaranM(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LamaranMasuk());
        }
        async void MoveToProfil(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilPenyedia());
        }
        async void MoveToPekerjaanDiposting(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PekerjaanDiposting());
        }
        async void MoveToPekerjaAktif(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PekerjaAktif());
        }
    }
}