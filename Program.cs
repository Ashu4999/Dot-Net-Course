namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Example array for foreach loop
            string[] fruits = { "Apple", "Banana", "Cherry" };

            // For Loop
            Console.WriteLine("For Loop:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Iteration {i}");
            }

            // Foreach Loop
            Console.WriteLine("\nForeach Loop:");
            foreach (var fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

            // While Loop
            Console.WriteLine("\nWhile Loop:");
            int counter = 0;
            while (counter < 5)
            {
                Console.WriteLine($"Counter {counter}");
                counter++;
            }

            // Do-While Loop
            Console.WriteLine("\nDo-While Loop:");
            int number = 0;
            do
            {
                Console.WriteLine($"Number {number}");
                number++;
            } while (number < 5);

            int[] numbers = new int[] { 10, 45, 65, 89, 78};

            int sum = numbers.Sum();
            Console.WriteLine(sum);
        }
    }
}