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
using WalletAppWPF.Controller;
using WalletAppWPF.Models;
using WalletAppWPF.Views;

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

            TransactionsListInfo transactionsListInfo = new();
            this.DataContext = transactionsListInfo;

        }
        private void OnListBoxTransactionSelected(object sender, RoutedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            var selectedListBoxItem = listBox.SelectedItem;
            try
            {
                if (selectedListBoxItem == null)
                {
                    throw new Exception("Transaction list row is null");
                }

                if (selectedListBoxItem is not LatestTransactions selectedData)
                {
                    throw new Exception("Incorrect data in transaction list row");
                }
                long additionalData = selectedData.Id;

                var transactionDetailWindow = new TransactionDetail(selectedData.User.Id, selectedData.Id);
                transactionDetailWindow.Show();
            } 
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
