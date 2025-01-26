using Microsoft.Extensions.Configuration;
using Onellect_Task;

class Program
{
    static async Task Main()
    {
        var listToSend = GenerateDataAndPrint();

        string filePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

        var config = new ConfigurationBuilder().AddJsonFile(filePath).Build();
        string apiUrl = config["ApiUrl"];

        ApiClient apiClient = new ApiClient(apiUrl);
        await apiClient.SendSortedNumbersAsync(listToSend);
    }

    static List<int> GenerateDataAndPrint()
    {
        Random random = new Random();

        int count = random.Next(20, 101);

        List<int> numbers = new List<int>();

        for (int i = 0; i < count; i++)
        {
            numbers.Add(random.Next(-100, 101));
        }

        Console.WriteLine("Исходный список:");
        Console.WriteLine(string.Join(", ", numbers));

        int algorithmChoice = random.Next(1, 4); 
        List<int> numbersToSort = new List<int>(numbers);

        Console.WriteLine("Выбор алгоритма сортировки:");
        switch (algorithmChoice)
        {
            case 1:
                Console.WriteLine("Сортировка пузырьком:");
                BubbleSort(numbersToSort);
                break;
            case 2:
                Console.WriteLine("Сортировка выбором:");
                SelectionSort(numbersToSort);
                break;
            case 3:
                Console.WriteLine("Сортировка вставками:");
                InsertionSort(numbersToSort);
                break;            
        }

        Console.WriteLine("Отсортированный список:");
        Console.WriteLine(string.Join(", ", numbersToSort));

        return numbersToSort;
    }

    static void BubbleSort(List<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 0; j < list.Count - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    int temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
    }

    static void SelectionSort(List<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[j] < list[minIndex])
                {
                    minIndex = j;
                }
            }

            int temp = list[minIndex];
            list[minIndex] = list[i];
            list[i] = temp;
        }
    }

    static void InsertionSort(List<int> list)
    {
        for (int i = 1; i < list.Count; i++)
        {
            int key = list[i];
            int j = i - 1;
            
            while (j >= 0 && list[j] > key)
            {
                list[j + 1] = list[j];
                j--;
            }

            list[j + 1] = key;
        }
    }
}

