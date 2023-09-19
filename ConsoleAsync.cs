using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Start of the program.");

        // Start two asynchronous tasks
        Task<int> task1 = DoAsyncWork(1);
        Task<int> task2 = DoAsyncWork(2);

        // Await both tasks to complete
        int result1 = await task1;
        int result2 = await task2;

        Console.WriteLine($"Result from task 1: {result1}");
        Console.WriteLine($"Result from task 2: {result2}");

        Console.WriteLine("End of the program.");
    }

    static async Task<int> DoAsyncWork(int id)
    {
        Console.WriteLine($"Task {id} started.");
        await Task.Delay(2000); // Simulate some asynchronous work (2 seconds delay)
        Console.WriteLine($"Task {id} completed.");
        return id * 100;
    }
}
