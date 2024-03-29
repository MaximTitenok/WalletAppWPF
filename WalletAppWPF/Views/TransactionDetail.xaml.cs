﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WalletAppWPF.Controller;
using WalletAppWPF.Models;

namespace WalletAppWPF.Views
{
    /// <summary>
    /// Interaction logic for TransactionDetail.xaml
    /// </summary>
    public partial class TransactionDetail : Window, INotifyPropertyChanged
    {
        public LatestTransactions transaction { get; set; }
        int _userId;
        long _id;
        public TransactionDetail(int userId, long id)
        {
            InitializeComponent();

            this.ResizeMode = ResizeMode.NoResize;

            _userId = userId;
            _id = id;

            FillWindowFields();
        }
        private async void FillWindowFields()
        {
            GetTransactionsFromApi getTransaction = new();
            transaction = (LatestTransactions)await getTransaction.GetTransaction(_userId, _id);

            DataContext = transaction ?? new LatestTransactions();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
