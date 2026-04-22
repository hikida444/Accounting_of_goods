using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Accounting_of_goods
{
    public static class CurrencyConverter
    {
        // Базовая валюта по умолчанию
        public static string CurrentCurrency { get; private set; } = "RUB";
        // Текущий множитель курса (для рублей он всегда 1)
        public static decimal CurrentRate { get; private set; } = 1m;

        private static readonly HttpClient client = new HttpClient();

        // Метод для обновления курса
        public static async Task ChangeCurrencyAsync(string targetCurrency)
        {
            if (targetCurrency == "RUB")
            {
                CurrentCurrency = "RUB";
                CurrentRate = 1m;
                return;
            }

            try
            {
                // Бесплатный API без ключа. Базовая валюта - RUB
                string url = "https://open.er-api.com/v6/latest/RUB";
                string response = await client.GetStringAsync(url);

                using (JsonDocument doc = JsonDocument.Parse(response))
                {
                    // Достаем множитель для выбранной валюты (например, USD)
                    JsonElement rates = doc.RootElement.GetProperty("rates");
                    if (rates.TryGetProperty(targetCurrency, out JsonElement rateElement))
                    {
                        CurrentRate = rateElement.GetDecimal();
                        CurrentCurrency = targetCurrency;
                    }
                }
            }
            catch (Exception ex)
            {
                // Если нет интернета или API упал - просто выводим ошибку и оставляем рубли
                System.Windows.Forms.MessageBox.Show($"Ошибка загрузки курса: {ex.Message}", "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                CurrentCurrency = "RUB";
                CurrentRate = 1m;
            }
        }

        // Удобный метод, который мы будем вызывать везде для перевода цены
        // Он берет рубли из БД и умножает на текущий курс
        public static decimal ConvertPrice(decimal priceInRub)
        {
            return Math.Round(priceInRub * CurrentRate, 2);
        }
    }
}
