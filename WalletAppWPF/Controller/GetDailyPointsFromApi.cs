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
    public class GetDailyPointsFromApi
    {
        public async Task<string> GetDailyPointsField()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(App.connectionApiField);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync($"api/DailyPoints");
                    if (response.IsSuccessStatusCode)
                    {
                        var transactions = await response.Content.ReadAsStringAsync();
                        int points = Convert.ToInt32(transactions); 
                        if (points > 1000)
                        {
                            return $"{points / 1000}K";
                        }
                        return points.ToString();
                    }
                    else
                    {
                        new Exception($"Response isn't success. Response status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return "";

            }
        }

    }
}
