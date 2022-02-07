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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrismApp.ViewModels;
using Prism.Regions;

namespace PrismApp.Views
{
    /// <summary>
    /// Interaction logic for ProductListView.xaml
    /// </summary>
    public partial class ProductListView : UserControl
    {
        public ProductListView(IRegionManager regionManager)
        {
            InitializeComponent();

        }

        private async void ProductListViewLoaded(object sender, RoutedEventArgs e)
        { 
            await ((ProductListViewModel)DataContext).LoadProducts();
        }
    }
}
