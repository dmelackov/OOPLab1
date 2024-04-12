using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

class Program1
{

    static string? MakeSyncRequest(string uri)
    {
        var httpClient = new HttpClient();
        var response = httpClient.Send(new HttpRequestMessage(HttpMethod.Get, uri));
        if (response.IsSuccessStatusCode)
        {
            var str = response.Content.ReadAsStringAsync().Result;
            return str;
        }
        return null;
    }

    static async Task<string?> MakeAsyncRequest(string uri)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        return null;
    }

    class OwapiResponse
    {
        public string name { get; set; }
        public string description { get; set; }
        public string version { get; set; }
        public string homepage { get; set; }
        public string bugs { get; set; }
        public string docs { get; set; }
    }
    public static void Main(String[] args)
    {
        Stopwatch stopwatchSync = new Stopwatch();
        Stopwatch stopwatchAsync = new Stopwatch();

        stopwatchAsync.Start();
        List<Task<string?>> strings = new List<Task<string?>>{
           MakeAsyncRequest("https://owapi.io/"),
           MakeAsyncRequest("https://owapi.io/"),
           MakeAsyncRequest("https://owapi.io/"),
           MakeAsyncRequest("https://owapi.io/"),
           MakeAsyncRequest("https://owapi.io/"),
           MakeAsyncRequest("https://owapi.io/"),
           MakeAsyncRequest("https://owapi.io/")
        };
        Task.WaitAll(strings.ToArray());
        stopwatchAsync.Stop();

        stopwatchSync.Start();
        List<string?> strings2 = new List<string?>{
           MakeSyncRequest("https://owapi.io/"),
           MakeSyncRequest("https://owapi.io/"),
           MakeSyncRequest("https://owapi.io/"),
           MakeSyncRequest("https://owapi.io/"),
           MakeSyncRequest("https://owapi.io/"),
           MakeSyncRequest("https://owapi.io/"),
           MakeSyncRequest("https://owapi.io/")
        };
        stopwatchSync.Stop();

        int succefullAsyncCount = 0; 
        int succefullSyncCount = 0;
        foreach (var item in strings)
        {
            if (item.Result != null) succefullAsyncCount++;
        }
        foreach (var item in strings2)
        {
            if (item != null) succefullSyncCount++;
        }

        Console.WriteLine($"Выполнено {strings.Count} асихронных запросов, {succefullAsyncCount} успешно");
        Console.WriteLine($"Выполнено {strings2.Count} сихронных запросов, {succefullSyncCount} успешно");

        Console.WriteLine($"Время выполнения асихронно: {stopwatchAsync.ElapsedMilliseconds} ms");
        Console.WriteLine($"Время выполнения сихронно: {stopwatchSync.ElapsedMilliseconds} ms");

        Console.WriteLine($"JSON ответ: {strings2.Last()}");

        OwapiResponse response = JsonSerializer.Deserialize<OwapiResponse>(strings2.Last());
        Console.WriteLine($"Вернувшийся ответ: name={response.name} description={response.description} version={response.version}");

    }
}