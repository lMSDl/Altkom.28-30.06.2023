using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.Models
{
    public class DiceItem : INotifyPropertyChanged
    {
        private int number;
        private bool isLocked;

        public int Number
        {
            get => number;
            set
            {
                number = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Number)));
            }
        }

        public bool IsLocked
        {
            get => isLocked;
            set
            {
                isLocked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLocked)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
