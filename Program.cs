namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int myInt = 5;
            int mySecondInt = 10;

            if (mySecondInt > myInt) {
                Console.WriteLine("Second int is greater");
            }

            string firstStr = "cow";
            string secondStr = "cow";

            if (firstStr == secondStr) {
                Console.WriteLine("Equal");
            } else if (firstStr.ToLower() == secondStr.ToLower()) {
                Console.WriteLine("Equal without case sensitivity");
            } else {
                Console.WriteLine("Not equal");
            }

            string option = "one";

            switch(option) {
                case "one": Console.WriteLine("One");
                            break;
                case "two": Console.WriteLine("Two");
                            break;     
                default   : Console.WriteLine("Invalid Option");
                            break;      
            }
        }
    }
}