using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Net.Http.Json;

namespace WalletAppWPF.Controller
{
    public class GetTransactionsFromApi
    {
        public async Task</*IEnumerable<TransactionsList>*/string> GetTransactions(int userId)
        {
            using (var client = new HttpClient())
            {
                // Задайте базовий URL для вашого API
                client.BaseAddress = new Uri(App.connectionApiField);

                // Встановіть заголовок, якщо вам потрібно (наприклад, авторизація або інше)
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // Виконати GET-запит до API для отримання транзакцій для певного користувача
                    var response = await client.GetAsync($"api/DailyPoints");
                    if (response.IsSuccessStatusCode)
                    {
                        // Прочитати відповідь як список транзакцій
                        var transactions = await response.Content.ReadAsStringAsync();
                        //var transactions = await response.Content.ReadFromJsonAsync<IEnumerable<TransactionsList>>();
                        return transactions;
                    }
                    else
                    {
                        // Обробити помилку, якщо не вдалося отримати дані
                        // Наприклад, вивести повідомлення або здійснити інші дії
                    }
                }
                catch (Exception ex)
                {
                    // Обробити виняток, якщо сталася помилка під час виконання запиту
                }

                return "";
            }
        }

    }
}
