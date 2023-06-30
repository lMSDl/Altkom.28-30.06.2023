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
        private IAsyncService<Product> _service = new AsyncService<Product>(new ProductFaker());
        private ObservableCollection<Product> products;
        private bool isLoading;

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
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadedCommand => new RelayCommand(async x => Products = await LoadData(), x => !IsLoading);

        private async Task<ObservableCollection<Product>> LoadData()
        {
            IsLoading = true;
            try
            {
                return new ObservableCollection<Product>(await _service.ReadAsync());
            }
            finally
            {
                IsLoading = false;
            }
        }

        public ICommand DeleteCommand => new RelayCommand(async x =>
        {
            await _service.DeleteAsync(SelectedProduct!.Id);
            Products.Remove(SelectedProduct!);
        },
                                                                      x => SelectedProduct is not null);
        public ICommand EditCommand => new DialogCommand<ProductViewModel>(GetProductViewModel,
                                                                          ProductEdited,
                                                                          x => SelectedProduct is not null);

        private async void ProductEdited(ProductViewModel x)
        {
            var item = x.Product;
            await _service.EditAsync(SelectedProduct!.Id, item);
            Products.Remove(SelectedProduct);
            Products.Add(item);
        }

        private ProductViewModel GetProductViewModel()
        {
            return new ProductViewModel((Product)SelectedProduct!.Clone());
        }
        //public ICommand EditCommand => new RelayCommand(x =>
        //                                                {
        //                                                    var item = (Product)SelectedProduct!.Clone();
        //                                                    Window window = (Window)Activator.CreateInstance((Type)x!)!;
        //                                                    window.DataContext = new ProductViewModel(item);
        //                                                    if(window.ShowDialog() == true)
        //                                                    {
        //                                                        _service.Edit(SelectedProduct!.Id, item);
        //                                                        Products.Remove(SelectedProduct);
        //                                                        Products.Add(item);
        //                                                    }
        //                                                },
        //                                                x => SelectedProduct is not null);
    }
}
