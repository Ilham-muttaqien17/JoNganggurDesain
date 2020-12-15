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
    public partial class TerbaruPage : ContentPage
    {
        public TerbaruPage()
        {
            InitializeComponent();
        }
        async void MoveToDetail(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailPage());
        }
    }
}