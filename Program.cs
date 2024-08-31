namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int myInt = 5;
            int mySecondInt = 10;

            Console.WriteLine(myInt.Equals(mySecondInt));
            Console.WriteLine(myInt.Equals(mySecondInt / 2));

            Console.WriteLine(myInt == mySecondInt);
            Console.WriteLine(myInt == mySecondInt / 2);

            Console.WriteLine(myInt != mySecondInt);
            Console.WriteLine(myInt != mySecondInt / 2);

            Console.WriteLine(myInt >= mySecondInt);
            Console.WriteLine(myInt > mySecondInt);
            Console.WriteLine(myInt <= mySecondInt);
            Console.WriteLine(myInt < mySecondInt);

            Console.WriteLine(myInt);
            myInt++;
            Console.WriteLine(myInt);

            myInt += 7;
            Console.WriteLine(myInt);

            myInt -= 8;
            Console.WriteLine(myInt);

            Console.WriteLine(myInt * mySecondInt);
            Console.WriteLine(myInt / mySecondInt);
            Console.WriteLine(myInt + mySecondInt);
            Console.WriteLine(myInt - mySecondInt);

            //PEMDAS ORDER
            Console.WriteLine(5 + 5 * 10);
            Console.WriteLine((5 + 5) * 10);

            Console.WriteLine($"Pow of 5: {Math.Pow(5, 2)}");
            Console.WriteLine($"Sqrt of 25: {Math.Sqrt(25)}");

            string str = "\"first ";
            Console.WriteLine(str);

            str += "second ";
            Console.WriteLine(str);

            str = str + "third\"";
            Console.WriteLine(str);

            string[] splitArray = str.Split(" ");
            Console.WriteLine(splitArray[0]);
            Console.WriteLine(splitArray[1]);
            Console.WriteLine(splitArray[2]);


            Console.WriteLine(true && true);
            Console.WriteLine(true && false);
            Console.WriteLine(false && true);
            Console.WriteLine(false && false);

            Console.WriteLine(true || true);
            Console.WriteLine(true || false);
            Console.WriteLine(false || true);
            Console.WriteLine(false || false);
        }
    }
}