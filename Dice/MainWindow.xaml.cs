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
        public int NumberOfDices
        {
            get => Dices.Count;
            set
            {
                ChangeNumberOfDices(value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumberOfDices)));
            }
        }

        private void ChangeNumberOfDices(int input)
        {
            for (int i = 0, limit = input - NumberOfDices; i < limit; i++)
            {
                Dices.Add(new DiceItem());
            }

                for (int i = 0, limit = NumberOfDices - input; i < limit; i++)
                {
                    Dices.Remove(Dices.LastOrDefault());
                }
        }

        public MainWindow()
        {
            InitializeComponent();
            Dices = new ObservableCollection<DiceItem>();
            NumberOfDices = 6;

            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            NumberOfDices++;
        }
        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            NumberOfDices--;
        }

        private void Button_Roll(object sender, RoutedEventArgs e)
        {
            var random = new Random((int)DateTime.Now.Ticks);
            foreach (DiceItem item in Dices.Where(x => !x.IsLocked))
            {
                item.Number = random.Next(1, 7);
            }
        }

        private void Button_Lock(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                if(button.DataContext is DiceItem item)
                {
                    item.IsLocked = !item.IsLocked;
                }
            }
        }
    }
}
