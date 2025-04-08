using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using 设备管理系统.ViewModels;

namespace 设备管理系统.Converter
{
    public class AreaToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = Visibility.Visible;
            if (value == null) return result;
            SelectAreaViewModel selectAreaViewModel = new SelectAreaViewModel();
            foreach (var item in selectAreaViewModel.Areas)
            {
                string r = value.ToString();
                if (r == item.Name)
                {
                    result = Visibility.Hidden;
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
