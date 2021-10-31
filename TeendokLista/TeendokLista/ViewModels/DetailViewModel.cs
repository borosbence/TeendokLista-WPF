using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeendokLista.Models;

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
        public DetailViewModel(Feladat feladat)
        {
            _feladat = feladat;
            SaveCommand = new RelayCommand(e => Save());
        }

        public RelayCommand SaveCommand { set; get; }

        private Feladat _feladat;
        public Feladat Feladat
        {
            get { return _feladat; }
            set { SetProperty(ref _feladat, value); }
        }

        public void Save()
        {

        }

        public void OnClose()
        {

        }
    }
}
