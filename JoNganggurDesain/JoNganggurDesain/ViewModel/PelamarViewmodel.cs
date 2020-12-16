using MvvmHelpers;
using JoNganggurDesain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JoNganggurDesain.Services;

namespace JoNganggurDesain.ViewModel
{
    public class PelamarViewmodel : BaseViewModel
    {
        public string Nama { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Tgl_lahir { get; set; }
        public string Email { get; set; }
        public int Kontak { get; set; }
        public string Deskripsi { get; set; }

        private DBFirebase services;

        public Command AddPelamarCommand { get; }

        private ObservableCollection<Pelamar> _pelamar = new ObservableCollection<Pelamar>();
        public ObservableCollection<Pelamar> Pelamar
        {
            get
            {
                return _pelamar;
            }
            set
            {
                _pelamar = value;
                OnPropertyChanged();
            }
        }
        public PelamarViewmodel()
        {
            services = new DBFirebase();
            Pelamar = services.getPelamar();
            AddPelamarCommand = new Command(async () => await addPelamarAsync(Nama, Username, Password, Tgl_lahir, Email, Kontak, Deskripsi));
        }

        public async Task addPelamarAsync(string Nama, string Username, string Password, DateTime Tgl_lahir, string Email, int Kontak, string Deskripsi)
        {
            await services.AddPelamar(Nama, Username, Password, Tgl_lahir, Email, Kontak, Deskripsi);
        }
    }
}
