using System.Diagnostics;

namespace ScanService.ConsoleClient;

public static class Program
{
    private const string Api = "https://localhost:5001/";
    private static readonly HttpClient _client = new();

    public static void Main(string[] args)
    {
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
                        if (input.Contains("scan_util scan "))
                        {
                            CreateScan(attribute);
                        }
                        else if (input.Contains("scan_util status "))
                        {
                            GetScanStatus(attribute);
                        }
                        else
                        {
                            Console.WriteLine("There is no such command!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no such command!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("There is no such command!");
                }
            }

            input = Console.ReadLine()?.ToLower();
        }
    }

    private static void StartScanService()
    {
        Console.WriteLine("Scan service was started.");
        
        Process.Start(Path.Combine(
            Directory.GetParent(Directory.GetCurrentDirectory())
                .Parent.Parent.Parent.FullName, 
            @"ScanService.API\bin\Debug\net6.0\ScanService.API.exe"
            ));
        
        _client.BaseAddress = new Uri(Api);
        
        Console.WriteLine("Write <Exit> to exit...");
    }

    private static void CreateScan(string directory)
    {
        
    }

    private static void GetScanStatus(string id)
    {
        
    }
}