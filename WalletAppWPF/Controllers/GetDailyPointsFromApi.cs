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
                        int points = 0;
                        bool ParseResult = int.TryParse(transactions, out points);

                        if (ParseResult == false)
                        {
                            throw new Exception($"Response hasn't DailyPoints");
                        }

                        if (points > 1000)
                        {
                            return $"{points / 1000}K";
                        }
                        return points.ToString();
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
                return "0";

            }
        }

    }
}
