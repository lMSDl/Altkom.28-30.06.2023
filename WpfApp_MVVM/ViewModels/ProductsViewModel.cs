using Models;
using Services.Bogus;
using Services.Bogus.Fakers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp_MVVM.Commands;

namespace WpfApp_MVVM.ViewModels
{
    public class ProductsViewModel : NotifyPropertyChanged
    {
        private IService<Product> _service = new Service<Product>(new ProductFaker());
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public Product? SelectedProduct { get; set; }

        public ICommand LoadedCommand => new RelayCommand(x => Products = new ObservableCollection<Product>(_service.Read()));
        public ICommand DeleteCommand => new RelayCommand(x => {
                                                                    _service.Delete(SelectedProduct!);
                                                                    Products.Remove(SelectedProduct!);
                                                               },
                                                          x => SelectedProduct is not null );
    }
}
