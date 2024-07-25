using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace YugiohShop.Helpers
{
    public class ImageUrlToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string url)
            {
                return new BitmapImage(new Uri(url, UriKind.Absolute));
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
