using System.Net.Http.Json;

namespace Onellect_Task
{
    internal class ApiClient
    {
        private string _apiUrl;

        public ApiClient(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        public async Task SendSortedNumbersAsync(List<int> sortedNumbers)
        {
            using HttpClient httpClient = new HttpClient();

            try
            {                
                var response = await httpClient.PostAsJsonAsync(_apiUrl, sortedNumbers);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Данные успешно отправлены на сервер ");
                }
                else
                {
                    Console.WriteLine($"Данные не отправлены на сервер!");
                }
            }
            catch
            {
                Console.WriteLine("Error: Ошибка отправки данных");
            }
        }
    }
}
