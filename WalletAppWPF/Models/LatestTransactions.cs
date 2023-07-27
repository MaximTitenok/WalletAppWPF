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
        private long Id { get; set; }
        private decimal Sum { get; set; }
        private string Name { get; set; }
        private string Description{ get; set; }
        // TODO: Дата – за останній тиждень має виводитись назва дня для всього іншого дата.
        private DateTime? Date { get; set; }
        // TODO: транзакція може бути в статусі pending – тоді в неє це виводиться перед description
        private bool Pending { get; set; }
        private User User { get; set; }
        private BitmapImage Image { get; set; }
        
        enum Types
        {
            Payment,
            Credit
        }
    }
}
