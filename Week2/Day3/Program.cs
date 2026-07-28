using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("===== Sequential Execution =====");
        await SequentialDemo();

        Console.WriteLine("\n===== Concurrent Execution =====");
        await ConcurrentDemo();

        Console.WriteLine("\n===== Cancellation Demo =====");
        await CancellationDemo();
    }

//sequential
    static async Task SequentialDemo()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        await GetUsersAsync();
        await GetOrdersAsync();
        await GetProductsAsync();

        stopwatch.Stop();

        Console.WriteLine($"Sequential Time: {stopwatch.ElapsedMilliseconds} ms");
    }

    // Concurrent 

    static async Task ConcurrentDemo()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        Task usersTask = GetUsersAsync();
        Task ordersTask = GetOrdersAsync();
        Task productsTask = GetProductsAsync();

        await Task.WhenAll(usersTask, ordersTask, productsTask);

        stopwatch.Stop();

        Console.WriteLine($"Concurrent Time: {stopwatch.ElapsedMilliseconds} ms");
    }

    //  Cancellation

    static async Task CancellationDemo()
    {
        CancellationTokenSource cts = new CancellationTokenSource();

        cts.CancelAfter(2000);

        try
        {
            await LongRunningUsersAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation was cancelled.");
        }
    }

    //  Async Methods 

    static async Task GetUsersAsync()
    {
        Console.WriteLine("Loading Users...");
        await Task.Delay(2000);
        Console.WriteLine("Users Loaded");
    }

    static async Task GetOrdersAsync()
    {
        Console.WriteLine("Loading Orders...");
        await Task.Delay(2000);
        Console.WriteLine("Orders Loaded");
    }

    static async Task GetProductsAsync()
    {
        Console.WriteLine("Loading Products...");
        await Task.Delay(2000);
        Console.WriteLine("Products Loaded");
    }

    static async Task LongRunningUsersAsync(CancellationToken token)
    {
        Console.WriteLine("Loading Users (Long Operation)...");
        await Task.Delay(5000, token);
        Console.WriteLine("Users Loaded");
    }
}