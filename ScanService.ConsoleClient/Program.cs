using System.Diagnostics;
using System.Net.Http.Json;
using ScanService.Client.Models;

namespace ScanService.ConsoleClient;

public class Program
{
    private const string Api = "https://localhost:5001";
    private static Process? _processApi;

    public static void Main(string[] args)
    {
        Console.WriteLine("Commands:\n" +
                          "1. scan_service;\n" +
                          "2. scan_util scan 'directory'\n" +
                          "3. scan_util status 'id'\n" +
                          "4. exit");
        
        var input = Console.ReadLine()?.ToLower();

        while (input != "exit")
        {
            if (input == "scan_service")
            {
                StartScanService();
            }
            else
            {
                try
                {
                    var attribute = input.Split(" ")[2];

                    if (!string.IsNullOrEmpty(attribute))
                    {
                        if (input.Contains("scan_util scan"))
                        {
                            CreateScan(attribute);
                        }

                        if (input.Contains("scan_util status"))
                        {
                            GetScanStatus(attribute);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no such command!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            input = Console.ReadLine()?.ToLower();
        }
        
        _processApi?.Kill();
        GC.Collect();
    }

    private static void StartScanService()
    {
        Console.WriteLine("Scan service was started.");
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = Path.Combine(
                Directory.GetParent(Directory.GetCurrentDirectory())
                    .Parent.Parent.Parent.FullName,
                @"ScanService.API\bin\Debug\net6.0\ScanService.API.exe"
            ),
            UseShellExecute = false,
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden
        };
        
        _processApi = Process.Start(startInfo);
        
        Console.WriteLine("Write <Exit> to exit...");
    }

    private static void CreateScan(string directory)
    {
        var requestModel = new
        {
            Directory = directory,
        };

        using var client = new HttpClient();
        
        var response = client.PostAsJsonAsync(Api + "/api/scan", requestModel).Result;
        Console.WriteLine($"Scan task was created with ID: {response.Content.ReadAsStringAsync().Result}");
    }

    private static void GetScanStatus(string id)
    {
        using var client = new HttpClient();
        try
        {
            var response = client.GetFromJsonAsync<GetTaskResponseModel>(Api + "/api/scan?id=" + id).Result;
            Console.WriteLine("====== Scan result ======");
            Console.WriteLine(response?.ToString());
            Console.WriteLine("=========================");
        }
        catch (Exception e)
        {
            Console.WriteLine("Scan task in progress, please wait");
        }
    }
}