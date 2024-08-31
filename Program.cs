namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] myGrocery = new string[2];

            myGrocery[0] = "Apple";
            myGrocery[1] = "Ice-Cream";

            Console.WriteLine(myGrocery[0]);
            Console.WriteLine(myGrocery[1]);

            string[] myGrocery2 = { "Mango", "Choclate" };

            Console.WriteLine(myGrocery2[0]);
            Console.WriteLine(myGrocery2[1]);

            List<string> myGroceryList = new List<string> { "Milk", "Cheese" };
            Console.WriteLine(myGroceryList[0]);
            Console.WriteLine(myGroceryList[1]);

            myGroceryList.Add("Oranges");
            Console.WriteLine(myGroceryList[2]);

            IEnumerable<string> myGroceryIEnumerable = myGroceryList;
            Console.WriteLine(myGroceryIEnumerable.First());

            string[,] my2DArray = new string[,] {
                { "Mango", "Choclate" },
                { "Milk", "Cheese" }
            };

            Console.WriteLine(my2DArray[0, 1]);

            Dictionary<string, string[]> myGroceryDict = new Dictionary<string, string[]> {
                { "Dairy", new string[] { "Milk", "Cheese" }},
                { "Market", new string[] { "Choclate", "Mango", "Oranges" }}
            };

            Console.WriteLine(myGroceryDict["Market"][0]);
        }
    }
}