using PrismApp.Entities;
using PrismApp.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PrismApp.ViewModels
{
    public class ProductListViewModel : BindableBase
    {
        private IProductsRepository _repository;

        private ObservableCollection<Product> _products = new ObservableCollection<Product>();

        public ProductListViewModel(IProductsRepository productsRepository)
        {
           _repository = productsRepository;
        }

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        public async Task LoadProducts()
        {
            var products = await _repository.GetProductsAsync();
            Products = new ObservableCollection<Product>(products);
        }
    }
}
