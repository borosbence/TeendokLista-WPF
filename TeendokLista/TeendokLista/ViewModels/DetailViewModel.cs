using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeendokLista.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        public DetailViewModel(string title)
        {
            Title = title;
        }
        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

    }
}
