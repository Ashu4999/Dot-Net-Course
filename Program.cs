using System.Data;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DataContextEF dataContextEF = new DataContextEF(config);
            Computer myComputer = new Computer() {
                MotherBoard = "Z690",
                HasWifi = true,
                HasLTE = true,
                ReleaseDate = DateTime.Now,
                Price = 343.87m,
                VideoCard = "RTX 2060"
            };

            myComputer.HasWifi = false;

            var result = dataContextEF.Add(myComputer);
            dataContextEF.SaveChanges();
           
            IEnumerable<Computer> computers = dataContextEF.Computer.ToList();

            Console.WriteLine("'Id', 'MotherBoard', 'CPUCores', 'HasWifi','HasLTE','ReleaseDate','Price','VideoCard'");
            foreach(Computer currComputer in computers) {
                Console.WriteLine($"'{currComputer.ComputerId}','{currComputer.MotherBoard}','{currComputer.CPUCores}','{currComputer.HasWifi}','{currComputer.HasLTE}','{currComputer.ReleaseDate}','{currComputer.Price}','{currComputer.VideoCard}'");
            }
        }
    }
}