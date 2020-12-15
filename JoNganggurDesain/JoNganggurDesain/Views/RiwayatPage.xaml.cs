﻿using System;
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
            DisplayAlert("asd", "zxc", "qwe");
        }

        async void MoveToDashboard(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Dashboard());
        }

        async void MoveToProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }
    }
}