using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeendokLista.Models;
using TeendokLista.Repositories;
using TeendokLista.Views;

namespace TeendokLista.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private FeladatRepository _repo;

        public ObservableCollection<Feladat> Feladatok { get; set; }

        private Feladat _selectedFeladat;
        public Feladat SelectedFeladat
        {
            get { return _selectedFeladat; }
            set { SetProperty(ref _selectedFeladat, value); }
        }

        public RelayCommand<Feladat> SelectCommand { get; set; }
        public RelayCommand NewCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand<Window> LogoutCommand { get; set; }

        public MainViewModel()
        {
            _repo = new FeladatRepository();
            Feladatok = new ObservableCollection<Feladat>(_repo.GetAll());
            SelectCommand = new RelayCommand<Feladat>(feladat => ShowDetail(feladat));
            NewCommand = new RelayCommand(() => AddItem());
            RemoveCommand = new RelayCommand(() => RemoveItem());
            LogoutCommand = new RelayCommand<Window>(e => Close(e));

        }

        private void ShowDetail(Feladat feladat)
        {
            DetailViewModel detailViewModel = new DetailViewModel(feladat, _repo);
            DetailView detail = new DetailView(detailViewModel);
            // Itt már érzékeli az ObservableCollection a változást
            detail.ShowDialog();
        }

        private void AddItem()
        {
            var newItem = new Feladat();
            Feladatok.Insert(0, newItem);
        }

        private void RemoveItem()
        {
            // TODO: több elem kijelölésénél is
            _repo.Delete(SelectedFeladat.Id);
            Feladatok.Remove(SelectedFeladat);
        }

        private void Close(Window window)
        {
            var loginView = new LoginView();
            loginView.Show();
            window.Close();
        }
    }
}
