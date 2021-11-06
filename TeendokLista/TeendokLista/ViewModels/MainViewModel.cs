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
        private FeladatRepository _repo;

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

        public RelayCommand SelectCommand { get; set; }
        public RelayCommand NewCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }

        public MainViewModel()
        {
            _repo = new FeladatRepository();
            Feladatok = new ObservableCollection<Feladat>(_repo.GetAll());
            SelectCommand = new RelayCommand(e => ShowDetail(e));
            NewCommand = new RelayCommand(e => AddItem());
            RemoveCommand = new RelayCommand(e => RemoveItem());
        }

        public void ShowDetail(object parameter)
        {
            DetailViewModel detailViewModel = new DetailViewModel(parameter as Feladat, _repo);
            DetailView detail = new DetailView(detailViewModel);
            // Itt már érzékeli az ObservableCollection a változást
            detail.ShowDialog();
        }

        public void RemoveItem()
        {
            // TODO: több elem kijelölésénél is
            _repo.Delete(SelectedFeladat.Id);
            Feladatok.Remove(SelectedFeladat);
        }

        public void AddItem()
        {
            var newItem = new Feladat();
            Feladatok.Insert(0, newItem);
        }
    }
}
