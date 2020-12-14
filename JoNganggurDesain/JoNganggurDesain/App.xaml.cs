using JoNganggurDesain.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JoNganggurDesain
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PekerjaAktif();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
