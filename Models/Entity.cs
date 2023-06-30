using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Entity : ICloneable, IDataErrorInfo, INotifyDataErrorInfo
    {
        #region IDataErrorInfo
        protected Dictionary<string, string> ErrorDictionary { get; } = new Dictionary<string, string>();
        public string this[string columnName] => ErrorDictionary.TryGetValue(columnName, out var error) ? error : string.Empty;
        public string Error => string.Join("\n", ErrorDictionary.Select(x => x.Value));
        #endregion

        #region INotifyDataErrorInfo        
        public bool HasErrors => ErrorDictionary.Any();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public void OnErrorChanged([CallerMemberName] string nameOfProperty = "")
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameOfProperty));
        }
        public IEnumerable GetErrors(string? propertyName)
        {
            return ErrorDictionary.Select(x => x.Value);
        }
        #endregion

        public int Id { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }

    }
}
