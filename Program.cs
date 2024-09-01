namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = new int[] { 10, 45, 65, 89, 78, 45 };
            int[] numArray1 = new int[] { 10, 45, 45, 39, 44, 45 };

            static int GetSum(int[] numbers)
            {
                int total = 0;
                IEnumerable<int> iEnumerableNumbers = numbers;
                foreach (int number in iEnumerableNumbers)
                {
                    total += number;
                }
                return total;
            }

            Console.WriteLine(GetSum(numArray));
            Console.WriteLine(GetSum(numArray1));
        }
    }
}