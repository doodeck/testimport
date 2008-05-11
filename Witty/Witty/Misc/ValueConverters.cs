using System;
using System.Windows.Data;
using log4net;
using TwitterLib;

namespace Witty
{
    public class CharRemainingValueConverter : IValueConverter
    {
        private static readonly ILog logger = LogManager.GetLogger("Witty.Logging");

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return TwitterNet.CharacterLimit - (int)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            logger.Error("Error converting value (CharRemainingValueConverter.ConvertBack is not implemented).");
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        #endregion
    }


}

