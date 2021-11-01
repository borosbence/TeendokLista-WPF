using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeendokLista.Models;
using TeendokLista.Repositories;
using TeendokLista.Views;

namespace TeendokLista.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }
        private FelhasznaloRepository repo;
        public RelayCommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            repo = new FelhasznaloRepository();
            LoginCommand = new RelayCommand(e => Login());
        }

        public bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(_username);
        }
        public void Login()
        {
            ErrorMessage = repo.Authenticate(_username, _password);
            if (ErrorMessage == Application.Current.Resources["loginSuccess"].ToString())
            {
                var mw = new MainView();
                Application.Current.Windows[0].Close();
                mw.Show();
            }
        }
    }
}
