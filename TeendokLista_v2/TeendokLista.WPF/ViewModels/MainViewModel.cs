using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeendokLista.Data.Repositories;
using TeendokLista.Models;
using TeendokLista.WPF.Views;

namespace TeendokLista.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand SelectCommand { set; get; }

        private ObservableCollection<Feladat> _feladatok;
        public ObservableCollection<Feladat> Feladatok
        {
            get { return _feladatok; }
            set { SetProperty(ref _feladatok, value); }
        }
        private Feladat _selectedFeladat;

        public Feladat SelectedFeladat
        {
            get { return _selectedFeladat; }
            set { SetProperty(ref _selectedFeladat, value); }
        }

        private FeladatRepository _repo;

        /// <summary>
        /// Design nézethez
        /// </summary>
        public MainViewModel()
        {

        }
        public MainViewModel(FeladatRepository repo)
        {
            _repo = repo;
            Feladatok = new ObservableCollection<Feladat>(_repo.GetAll());
            SelectCommand = new RelayCommand(e => ShowDetail(e));
        }

        public void ShowDetail(object feladat)
        {
            DetailViewModel detailViewModel = new DetailViewModel(feladat as Feladat);
            DetailView detail = new DetailView(detailViewModel);
            // Itt már érzékeli az ObservableCollection a változást
            detail.ShowDialog();
        }
    }
}
