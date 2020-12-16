using JoNganggurDesain.Models;
using JoNganggurDesain.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JoNganggurDesain.ViewModel
{
    public class PekerjaanViewModel : BaseViewModel
    {
        public string Nama { get; set; }
        public int Gaji { get; set; }
        public string Syarat { get; set; }
        public string Deskripsi { get; set; }

        private DBFirebase services;

        public Command AddPekerjaanCommand { get; }
        private ObservableCollection<Pekerjaan> _pekerjaan = new ObservableCollection<Pekerjaan>();
        public ObservableCollection<Pekerjaan> Pekerjaan
        {
            get
            {
                return _pekerjaan;
            }
            set
            {
                _pekerjaan = value;
                OnPropertyChanged();
            }
        }
        public PekerjaanViewModel()
        {
            services = new DBFirebase();
            Pekerjaan = services.getPekerjaan();
            AddPekerjaanCommand = new Command(async () => await addPekerjaanAsync(Nama, Gaji, Syarat, Deskripsi));
        }
        public async Task addPekerjaanAsync(string Nama, int Gaji, string Syarat, string Deskripsi)
        {
            await services.AddPekerjaan(Nama, Gaji, Syarat, Deskripsi);
        }
    }
}
