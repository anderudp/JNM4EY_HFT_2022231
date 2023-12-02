using JNM4EY_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JNM4EY_HFT_2022231.WpfClient
{
    class TodoToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Binding.DoNothing;
            Todo myItem = (Todo)value;
            if ((myItem.IsImportant == null || myItem.IsImportant == false) && myItem.IsUrgent == true) return "(Urgent, not important)";
            else if ((myItem.IsUrgent == null || myItem.IsUrgent == false) && myItem.IsImportant == true) return "(Important, not urgent)";
            else if (myItem.IsUrgent == true && myItem.IsImportant == true) return "(Important and Urgent)";
            else return "(Not important, not urgent)";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
