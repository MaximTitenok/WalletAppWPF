using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Net.Http.Json;
using System.Windows;

namespace WalletAppWPF.Controller
{
    public class GetTransactionsFromApi
    {
        public async Task<IEnumerable<TransactionsList>> GetTransactions(int userId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(App.connectionApiField);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync($"api/Transactions/{userId}");
                    if (response.IsSuccessStatusCode)
                    {
                        var transactions = await response.Content.ReadFromJsonAsync<IEnumerable<TransactionsList>>();
                        if(transactions == null)
                        {
                            throw new Exception("Transactions list is empty!");
                        }
                        return transactions;
                    }
                    else
                    {
                        throw new Exception($"Response isn't success. Response status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return new List<TransactionsList>();
            }
        }

    }
}
