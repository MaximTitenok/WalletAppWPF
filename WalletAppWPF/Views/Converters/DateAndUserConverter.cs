using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WalletAppWPF.Models;

namespace WalletAppWPF.Views.Converters
{
    public class DateAndUserConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)values[0];
            UserModel user = (UserModel)values[1];
            UserModel authorizedUser = (UserModel)values[2];
            string result = "";

            if (user.Name != authorizedUser.Name)
            {
                result += $"{authorizedUser.Name} - ";
            }

            if (DateTime.Now.Subtract(date).Days <= 7)
            {
                result += date.DayOfWeek;
            }
            else
            {
                result += date.ToString("dd/MM/yyyy");
            }
            
            return result; 
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
