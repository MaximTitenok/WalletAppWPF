using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using WalletAppWPF.Controller;

namespace WalletAppWPF.Models
{
    public class TransactionsListInfo : INotifyPropertyChanged
    {
        CardBalance card = new();
        GetDailyPointsFromApi getDailyPoints = new();
        GetTransactionsFromApi getTransactions = new();

        public string BalanceField
        {
            get { return $"${card.GetBalance()}"; }
            set { }
        }
        public string AvaliableMoneyField 
        {
            get { return $"${card.GetAvailableMoney()} Available"; } 
            set { }
        }
        public string PointsField { get; set; }
        public IEnumerable<LatestTransactions> TransactionsList { get; set; }

        public TransactionsListInfo()
        {
            SetPointsPropertyAndTransactionsList();
        }

        private async void SetPointsPropertyAndTransactionsList()
        {
            PointsField = await getDailyPoints.GetDailyPointsField();
            OnPropertyChanged("PointsField");
            TransactionsList = await getTransactions.GetTransactions(31);
            OnPropertyChanged("TransactionsList");
        }

       

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
