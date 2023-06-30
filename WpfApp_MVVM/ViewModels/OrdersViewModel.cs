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
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp_MVVM.Commands;

namespace WpfApp_MVVM.ViewModels
{
    public class OrdersViewModel : NotifyPropertyChanged
    {
        private IAsyncService<Order> _service = new AsyncService<Order>(new OrderFaker());
        private ObservableCollection<Order> orders;
        private bool isLoading;

        public ObservableCollection<Order> Orders
        {
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadedCommand => new RelayCommand(async x => Orders = await LoadData());

        private async Task<ObservableCollection<Order>> LoadData()
        {
                return new ObservableCollection<Order>(await _service.ReadAsync());
        }
    }
}
