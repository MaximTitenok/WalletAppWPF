using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletAppWPF.Models
{
    public class CardBalance
    {
        Random random = new();
        private readonly decimal limit;
        private readonly decimal balance;
        private readonly decimal availableMoney;
        public CardBalance()
        {
            limit = 1500.0M;
            balance = Math.Round(Convert.ToDecimal(random.NextDouble()*1500),2);
            availableMoney = limit - balance;
        }

        public decimal GetLimit() => limit;
        public decimal GetBalance() => balance;
        public decimal GetAvailableMoney() => availableMoney;



    }
}
