namespace HelloWorld
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task firstTask = new Task(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine("Task 1");
            });
            firstTask.Start();

            Task secondTask = ConsoleAfterDelayAsync("Task 2", 150);

            ConsoleAfterDelay("Delay", 75);

            Task thirdTask = ConsoleAfterDelayAsync("Task 3", 50);

            await firstTask;
            Console.WriteLine("After the task was created");
            await secondTask;
            await thirdTask;
        }

        static void ConsoleAfterDelay(string text, int delay) {
            Thread.Sleep(delay);
            Console.WriteLine(text);
        }

        static async Task ConsoleAfterDelayAsync(string text, int delay) {
            await Task.Delay(delay);
            Console.WriteLine(text);
        }
    }
}