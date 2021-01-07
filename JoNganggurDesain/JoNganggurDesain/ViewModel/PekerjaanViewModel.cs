using JoNganggurDesain.Models;
using JoNganggurDesain.Services;
using JoNganggurDesain.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JoNganggurDesain.ViewModel
{
    public class PekerjaanViewModel : BaseViewModel
    {
        public string Nama { get; set; }
        public string Gaji { get; set; }
        public string Syarat { get; set; }
        public string Deskripsi { get; set; }
        public string id_Pelamar { get; set; }
        public string id_Penyedia { get; set; }
        public string namaPerusahaan { get; set; }
        public string namaPelamar { get; set; }

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
            AddPekerjaanCommand = new Command(async () => await addPekerjaanAsync(Nama, Gaji, Syarat, Deskripsi, id_Penyedia, namaPerusahaan));
        }
        public async Task addPekerjaanAsync(string Nama, string Gaji, string Syarat, string Deskripsi, string id_penyedia, string namaPerusahaan)
        {
            await services.AddPekerjaan(Nama, Gaji, Syarat, Deskripsi, id_penyedia, namaPerusahaan);
        }
    }
}
