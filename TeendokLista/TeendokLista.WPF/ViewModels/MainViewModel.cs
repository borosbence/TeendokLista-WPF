using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeendokLista.Models;
using TeendokLista.Repositories;
using TeendokLista.Views;

namespace TeendokLista.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand SelectCommand { set; get; }
        public RelayCommand NewCommand { set; get; }
        public RelayCommand RemoveCommand { set; get; }

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
            NewCommand = new RelayCommand(e => AddItem());
            RemoveCommand = new RelayCommand(e=> RemoveItem(e));
        }

        public void ShowDetail(object parameter)
        {
            DetailViewModel detailViewModel = new DetailViewModel(parameter as Feladat);
            DetailView detail = new DetailView(detailViewModel);
            // Itt már érzékeli az ObservableCollection a változást
            detail.ShowDialog();
        }

        public void RemoveItem(object parameter)
        {
            // TODO: több elem kijelölésénél is
            Feladatok.Remove(SelectedFeladat);
            _repo.Delete(SelectedFeladat.Id);
        }

        public void AddItem()
        {
            var newItem = new Feladat();
            Feladatok.Add(newItem);
            ShowDetail(newItem);
        }
    }
}
