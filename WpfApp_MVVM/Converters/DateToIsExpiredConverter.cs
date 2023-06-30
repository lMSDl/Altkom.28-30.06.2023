using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfApp_MVVM.Converters
{
    public class DateToIsExpiredConverter : BaseConverter /*MarkupExtension, IValueConverter*/
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;

            var isExpired = date < DateTime.Now;
        
            return isExpired ? Resources.Properties.Resources.Yes : Resources.Properties.Resources.No;
        }

        /*public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }*/
    }
}
