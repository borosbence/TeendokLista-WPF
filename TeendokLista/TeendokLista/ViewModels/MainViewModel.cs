using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeendokLista.Views;

namespace TeendokLista.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand New { set; get; }

        public MainViewModel()
        {
            New = new RelayCommand(e => ShowDetail(e));
        }

        public void ShowDetail(object title)
        {
            DetailViewModel detailViewModel = new DetailViewModel(title.ToString());
            DetailView detail = new DetailView(detailViewModel);
            detail.Show();
        }
    }
}
