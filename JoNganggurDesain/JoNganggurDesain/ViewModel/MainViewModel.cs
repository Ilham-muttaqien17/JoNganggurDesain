using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace JoNganggurDesain.ViewModel
{
    internal class MainViewModel
    {
        
        public MainViewModel()
        {
            CheckConnectivityOnStart();
            CheckConnectivityContinuously();
        }

        public void CheckConnectivityOnStart()
        {
            var Conn = CrossConnectivity.Current.IsConnected ? "Tidak ada sambungan internet" : "Tersambung ke internet";
            
        }

        public void CheckConnectivityContinuously()
        {
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                var Conn = args.IsConnected ? "Tidak ada sambungan internet" : "Tersambung ke internet";
            };
        }

        
    }
}
