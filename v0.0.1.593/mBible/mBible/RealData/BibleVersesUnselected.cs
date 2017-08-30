using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace mBible.RealData
{
    public class BibleVersesUnselected : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return (SolidColorBrush)(Application.Current.Resources["PhoneAccentBrush"]);
            }
            else
            {
                return (SolidColorBrush)(Application.Current.Resources["PhoneSubtleBrush"]);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
