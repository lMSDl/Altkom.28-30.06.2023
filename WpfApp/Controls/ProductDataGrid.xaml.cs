using Models;
using System;
using System.Collections;
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

namespace WpfApp.Controls
{
    /// <summary>
    /// Interaction logic for ProductDataGrid.xaml
    /// </summary>
    public partial class ProductDataGrid : DataGrid
    {
        public ProductDataGrid()
        {
            InitializeComponent();
        }

        public static DependencyProperty ItemsSourceProperty = DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(ProductDataGrid));
        public static DependencyProperty SelectedItemProperty = DependencyProperty.Register(nameof(SelectedItem), typeof(IEnumerable), typeof(ProductDataGrid));

    }
}
