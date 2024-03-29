﻿using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HotelReservation.Convertors;
public class InverseBooleanToVisibilityConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is bool boolValue && boolValue)
    {
      return Visibility.Collapsed;
    }
    else
    {
      return Visibility.Visible;
    }
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
