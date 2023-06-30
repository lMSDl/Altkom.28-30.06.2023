using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp_MVVM.Commands;

namespace WpfApp_MVVM.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public ProductViewModel(Product product)
        {
            Product = product;
        }

        public ICommand OkCommand => new RelayCommand(x => ((Window)x).DialogResult = true, x => !Product.HasErrors );
    }
}
