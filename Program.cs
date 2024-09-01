using System.Data;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            DataContextDapper dapper = new DataContextDapper();

            // string sqlCommand = "SELECT GETDATE()";
            // DateTime rightNow = dapper.LoadDataSingle<DateTime>(sqlCommand);
            // Console.WriteLine(rightNow);

            Computer myComputer = new Computer() {
                MotherBoard = "Z690",
                HasWifi = true,
                HasLTE = true,
                ReleaseDate = DateTime.Now,
                Price = 343.87m,
                VideoCard = "RTX 2060"
            };

            myComputer.HasWifi = false;
            Console.WriteLine(myComputer.MotherBoard);
            Console.WriteLine(myComputer.HasLTE);
            Console.WriteLine(myComputer.HasWifi);
            Console.WriteLine(myComputer.ReleaseDate);
            Console.WriteLine(myComputer.Price);
            Console.WriteLine(myComputer.VideoCard);

            string sqlQuery = $@"INSERT INTO TutorialAppSchema.Computer (
                MotherBoard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES(
                '{myComputer.MotherBoard}',
                '{myComputer.HasWifi}',
                '{myComputer.HasLTE}',
                '{myComputer.ReleaseDate}',
                '{myComputer.Price}',
                '{myComputer.VideoCard}'
            );";
        
            Console.WriteLine(sqlQuery);
            int result = dapper.ExecuteSqlWithCount(sqlQuery);
            Console.WriteLine(result);
            // bool result = dapper.ExecuteSql(sqlQuery);
            // Console.WriteLine(result);

            string readQuery = @"SELECT * FROM TutorialAppSchema.Computer";
            IEnumerable<Computer> computers = dapper.LoadData<Computer>(readQuery);

            Console.WriteLine("MotherBoard','HasWifi','HasLTE','ReleaseDate','Price','VideoCard'");
            foreach(Computer currComputer in computers) {
                Console.WriteLine($"'{currComputer.MotherBoard}','{currComputer.MotherBoard}','{currComputer.HasWifi}','{currComputer.HasLTE}','{currComputer.ReleaseDate}','{currComputer.Price}','{currComputer.VideoCard}'");
            }
        }
    }
}