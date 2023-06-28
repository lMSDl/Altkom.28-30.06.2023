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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ControlsWindow.xaml
    /// </summary>
    public partial class ControlsWindow : Window
    {
        public ControlsWindow()
        {
            InitializeComponent();

            MyTextBlock.Inlines.Add(new Run("bold") { FontWeight = FontWeights.Bold });

            MyTextBox.Focus();
            MyTextBox.CaretIndex = MyTextBox.Text.Length;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Shoud I disappear?", "ButtonClick", MessageBoxButton.YesNo, MessageBoxImage.Question);
        
            if(result == MessageBoxResult.Yes && sender is Button button)
            {
                button.Visibility = Visibility.Hidden;

                Task.Delay(5000).ContinueWith(x => Application.Current.Dispatcher.Invoke(() => button.Visibility = Visibility.Visible));
            }
        }

        private void CheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (CheckBox_V1.IsChecked == true && CheckBox_V2.IsChecked == true && CheckBox_V3.IsChecked == true)
                CheckBox_Main.IsChecked = true;
            else if (CheckBox_V1.IsChecked == false && CheckBox_V2.IsChecked == false && CheckBox_V3.IsChecked == false)
                CheckBox_Main.IsChecked = false;
            else
                CheckBox_Main.IsChecked = null;
        }

        private void CheckBox_Main_Click(object sender, RoutedEventArgs e)
        {
            CheckBox_V1.IsChecked = CheckBox_V2.IsChecked = CheckBox_V3.IsChecked = CheckBox_Main.IsChecked ?? false;
        }
    }
}
