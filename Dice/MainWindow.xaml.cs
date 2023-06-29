using Dice.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Dice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<DiceItem> Dices { get; set; }
        public int NumberOfDices => Dices.Count;

        public MainWindow()
        {
            InitializeComponent();
            Dices = new ObservableCollection<DiceItem>();
            for (int i = 0; i < 6; i++)
            {
                Dices.Add(new DiceItem() { Number = i + 1 });
            }

            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Dices.Add(new DiceItem());
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumberOfDices)));
        }
        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            Dices.Remove(Dices.Last());
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumberOfDices)));
        }

        private void Button_Roll(object sender, RoutedEventArgs e)
        {
            var random = new Random((int)DateTime.Now.Ticks);
            foreach (DiceItem item in Dices)
            {
                item.Number = random.Next(1, 7);
            }
        }
    }
}
