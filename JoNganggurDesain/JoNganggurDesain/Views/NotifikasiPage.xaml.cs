﻿using Plugin.Connectivity;
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
    public partial class NotifikasiPage : ContentPage
    {
        public NotifikasiPage(string username)
        {
            Username = username;
            InitializeComponent();
            CheckConnectivity();
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

        void CheckConnectivity()
        {
            CheckConnectivityOnStart();
            CheckConnectivityContinuously();
        }

        public void CheckConnectivityOnStart()
        {
            var Conn = CrossConnectivity.Current.IsConnected;
            if (Conn != true)
            {
                DisplayAlert("Message", "Tidak ada sambungan internet", "Oke");
            }

        }

        public void CheckConnectivityContinuously()
        {
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                var Conn = args.IsConnected;
                if (Conn != true)
                {
                    DisplayAlert("Message", "Tidak ada sambungan internet", "Oke");
                }
            };
        }
    }
}