using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WalletAppWPF.Controller;

namespace WalletAppWPF.Models
{
    public class TransactionsListInfo : INotifyPropertyChanged
    {
        CardBalance card = new();
        

        public TransactionsListInfo()
        {
            SetPointsPropertyAndTransactionsList();
        }
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
        GetDailyPointsFromApi getDailyPoints = new();
        public string PointsField { get; set; }
        private async void SetPointsPropertyAndTransactionsList()
        {
            PointsField = await getDailyPoints.GetDailyPointsField();
            OnPropertyChanged("PointsField");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
