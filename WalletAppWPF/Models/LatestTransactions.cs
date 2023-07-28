using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Xps;

namespace WalletAppWPF.Models
{
    public class LatestTransactions
    {
        public long Id { get; set; }
        public decimal Sum { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public DateTime? Date { get; set; }
        public bool Pending { get; set; }
        public UserModel User { get; set; }
        public UserModel AuthorizedUser { get; set; }
        /// <summary>
        /// if true it's plus(get money), false - it's to give money
        /// </summary>
        public bool Type { get; set; }   
    }
}
