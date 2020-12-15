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
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        async void Rekomendasi1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailPage());
        }

        async void Rekomendasi2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailPage());
        }

        void MoveToLokasi(object sender, EventArgs e)
        {
            DisplayAlert("Message", "Comming Soon", "Oke");
        }

        async void MoveToLamaran(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LamaranPage());
        }

        async void MoveToNotifikasi(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotifikasiPage());
        }

        async void MoveToTerbaru(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TerbaruPage());
        }

        async void MoveToRiwayat(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RiwayatPage());
        }

        async void MoveToProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }
    }
}