using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace 设备管理系统.Converter
{
    public class IsLessThanConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length >= 2 && values[0] != null && values[1] != null)
            {
                int minnumber_result = System.Convert.ToInt32(values[0]);
                int sparenumber_result = System.Convert.ToInt32(values[1]);

                if ((sparenumber_result < minnumber_result) || sparenumber_result ==0)
                {
                    // 返回暗红色 (#8B0000)
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B1A6A9"));
                }
            }
            // 返回 DependencyProperty.UnsetValue 而不是 null，这样 WPF 会使用属性默认值
            return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
