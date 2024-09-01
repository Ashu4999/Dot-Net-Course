using System.Data;
using System.Text.Json;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            //     Computer myComputer = new Computer() {
            //         MotherBoard = "Z690",
            //         HasWifi = true,
            //         HasLTE = true,
            //         ReleaseDate = DateTime.Now,
            //         Price = 343.87m,
            //         VideoCard = "RTX 2060"
            //     };

            //     myComputer.HasWifi = false;

            //     var result = dataContextEF.Add(myComputer);
            //     dataContextEF.SaveChanges();

            //     IEnumerable<Computer> computers = dataContextEF.Computer.ToList();

            //     Console.WriteLine("'Id', 'MotherBoard', 'CPUCores', 'HasWifi','HasLTE','ReleaseDate','Price','VideoCard'");
            //     foreach(Computer currComputer in computers) {
            //         Console.WriteLine($"'{currComputer.ComputerId}','{currComputer.MotherBoard}','{currComputer.CPUCores}','{currComputer.HasWifi}','{currComputer.HasLTE}','{currComputer.ReleaseDate}','{currComputer.Price}','{currComputer.VideoCard}'");
            //     }

            // string writeContent = "HERE is the first line\nThen second\nSo third\n";
            // // File.WriteAllText("log.txt", writeContent);

            // using StreamWriter openFile = new("log.txt", append: true);
            // openFile.WriteLine(writeContent);
            // openFile.Close();

            // string fileContent = File.ReadAllText("log.txt");
            // Console.WriteLine(fileContent);

            string computersJson = File.ReadAllText("Computers.json");

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            //System.Text.Json.JsonSerializer - inbuild 
            //JsonConvert - (Newtonsoft.Json pkg)
            IEnumerable<Computer>? computerSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);

            IEnumerable<Computer>? computerNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            if (computerNewtonSoft != null)
            {
                foreach (Computer currComputer in computerNewtonSoft)
                {
                    Computer computerObject = new Computer()
                    {
                        Motherboard = currComputer.Motherboard,
                        CPUCores = currComputer.CPUCores,
                        HasWifi = currComputer.HasWifi,
                        HasLTE = currComputer.HasLTE,
                        ReleaseDate = currComputer.ReleaseDate,
                        Price = currComputer.Price,
                        VideoCard = currComputer.VideoCard
                    };

                    dataContextEF.Computer.Add(computerObject);
                }
                dataContextEF.SaveChanges();
            }

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            string computerCopyNewtonSoft = JsonConvert.SerializeObject(computerNewtonSoft, settings);
            File.WriteAllText("computerCopyNewtonSoft.txt", computerCopyNewtonSoft);

            string computerCopySystem = System.Text.Json.JsonSerializer.Serialize(computerNewtonSoft, options);
            File.WriteAllText("computerCopySystem.txt", computerCopySystem);
        }
    }
}