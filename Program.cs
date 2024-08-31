namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0) {
                for(int i = 0; i < args.Length; i++) {
                    Console.WriteLine($"args index {i}: {args[i]}");
                }
            }
            // Write and WriteLine used to print but WriteLine append new line at the end.
            Console.WriteLine("Line 1 With Break Line"); // New Line
            Console.Write("Line 2");
            Console.Write("Line 3");
            Console.WriteLine("Line 4"); //New Line
            Console.WriteLine("Line 5");
        }
    }
}