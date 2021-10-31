using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TeendokLista.ViewModels;

namespace TeendokLista.Views
{
    /// <summary>
    /// Interaction logic for DetailView.xaml
    /// </summary>
    public partial class DetailView : Window
    {
        private DetailViewModel _detailViewModel;
        public DetailView(DetailViewModel detailViewModel)
        {
            InitializeComponent();
            DataContext = detailViewModel;
            _detailViewModel = detailViewModel;
        }
    }
}
