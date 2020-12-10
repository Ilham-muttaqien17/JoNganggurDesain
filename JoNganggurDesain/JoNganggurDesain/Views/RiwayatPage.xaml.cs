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
    public partial class RiwayatPage : ContentPage
    {
        public RiwayatPage()
        {
            InitializeComponent();
        }
        void Test(object sender, EventArgs e)
        {
            DisplayAlert("aaa", "sss", "OK");
        }
    }
}