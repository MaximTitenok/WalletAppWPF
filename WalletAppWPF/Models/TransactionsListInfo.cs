using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WalletAppWPF.Models
{
    public class TransactionsListInfo
    {
        CardBalance card = new();
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

    }
}
