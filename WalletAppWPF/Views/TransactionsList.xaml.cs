using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WalletAppWPF.Models;

namespace WalletAppWPF
{
    /// <summary>
    /// Interaction logic for TransactionsList.xaml
    /// </summary>
    public partial class TransactionsList : Window
    {
        public TransactionsList()
        {
            
            InitializeComponent();
            
            this.ResizeMode = ResizeMode.NoResize;

            string currentMonth = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
            monthTextBlock.Text = $"{currentMonth} balance";

            Uri fileUri = new Uri("Assets/checkMark.png", UriKind.Relative);
            checkMark.Source = new BitmapImage(fileUri);
            /*Uri imageUri = new Uri("Assets/checkMark.png", UriKind.RelativeOrAbsolute);
            BitmapImage bitmap = new BitmapImage(imageUri);
            checkMark.Source = bitmap;*/

            TransactionsListInfo transactionsListInfo = new TransactionsListInfo();
            this.DataContext = transactionsListInfo;

        }
        private void TransactionsList_GotFocus(object sender, RoutedEventArgs e)
        {

        }

    }
}
