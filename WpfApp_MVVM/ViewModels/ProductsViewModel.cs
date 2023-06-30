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
using System.Windows;
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
                                                                    _service.Delete(SelectedProduct!.Id);
                                                                    Products.Remove(SelectedProduct!);
                                                               },
                                                          x => SelectedProduct is not null );
        public ICommand EditCommand => new RelayCommand(x =>
                                                        {
                                                            var item = (Product)SelectedProduct!.Clone();
                                                            Window window = (Window)Activator.CreateInstance((Type)x!)!;
                                                            window.DataContext = new ProductViewModel(item);
                                                            if(window.ShowDialog() == true)
                                                            {
                                                                _service.Edit(SelectedProduct!.Id, item);
                                                                Products.Remove(SelectedProduct);
                                                                Products.Add(item);
                                                            }
                                                        },
                                                        x => SelectedProduct is not null);
    }
}
