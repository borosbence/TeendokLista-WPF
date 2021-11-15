using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeendokLista.Models;
using TeendokLista.Repositories;

namespace TeendokLista.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        /// <summary>
        /// Design nézethez
        /// </summary>
        public DetailViewModel()
        {

        }
        public DetailViewModel(Feladat feladat, FeladatRepository feladatRepository)
        {
            _feladat = feladat;
            _repo = feladatRepository;
            SaveCommand = new RelayCommand(e => Save());
        }

        private FeladatRepository _repo;

        private Feladat _feladat;
        public Feladat Feladat
        {
            get { return _feladat; }
            set { SetProperty(ref _feladat, value); }
        }

        public RelayCommand SaveCommand { get; set; }

        private void Save()
        {
            _repo.Save(_feladat);
        }
    }
}
