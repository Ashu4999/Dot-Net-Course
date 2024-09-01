using System.Data;
using System.Text.Json;
using AutoMapper;
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

            // string computersJson = File.ReadAllText("Computers.json");

            // JsonSerializerOptions options = new JsonSerializerOptions()
            // {
            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            // };

            //System.Text.Json.JsonSerializer - inbuild 
            //JsonConvert - (Newtonsoft.Json pkg)
            // IEnumerable<Computer>? computerSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);

            // IEnumerable<Computer>? computerNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            // if (computerNewtonSoft != null)
            // {
            //     foreach (Computer currComputer in computerNewtonSoft)
            //     {
            //         Computer computerObject = new Computer()
            //         {
            //             Motherboard = currComputer.Motherboard,
            //             CPUCores = currComputer.CPUCores,
            //             HasWifi = currComputer.HasWifi,
            //             HasLTE = currComputer.HasLTE,
            //             ReleaseDate = currComputer.ReleaseDate,
            //             Price = currComputer.Price,
            //             VideoCard = currComputer.VideoCard
            //         };

            //         dataContextEF.Computer.Add(computerObject);
            //     }
            //     dataContextEF.SaveChanges();
            // }

            // JsonSerializerSettings settings = new JsonSerializerSettings()
            // {
            //     ContractResolver = new CamelCasePropertyNamesContractResolver()
            // };

            // string computerCopyNewtonSoft = JsonConvert.SerializeObject(computerNewtonSoft, settings);
            // File.WriteAllText("computerCopyNewtonSoft.txt", computerCopyNewtonSoft);

            // string computerCopySystem = System.Text.Json.JsonSerializer.Serialize(computerNewtonSoft, options);
            // File.WriteAllText("computerCopySystem.txt", computerCopySystem);

            string computersSnakeJson = File.ReadAllText("ComputersSnake.json");

            Mapper mapper = new Mapper(new MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<ComputerSnake, Computer>().ForMember(destination => destination.ComputerId, options => options.MapFrom(source => source.computer_id));
                cfg.CreateMap<ComputerSnake, Computer>().ForMember(destination => destination.Motherboard, options => options.MapFrom(source => source.motherboard));
                cfg.CreateMap<ComputerSnake, Computer>().ForMember(destination => destination.CPUCores, options => options.MapFrom(source => source.cpu_cores));
                cfg.CreateMap<ComputerSnake, Computer>().ForMember(destination => destination.HasWifi, options => options.MapFrom(source => source.has_wifi));
                cfg.CreateMap<ComputerSnake, Computer>().ForMember(destination => destination.HasLTE, options => options.MapFrom(source => source.has_lte));
                cfg.CreateMap<ComputerSnake, Computer>().ForMember(destination => destination.ReleaseDate, options => options.MapFrom(source => source.release_date));
                cfg.CreateMap<ComputerSnake, Computer>().ForMember(destination => destination.Price, options => options.MapFrom(source => source.price));
                cfg.CreateMap<ComputerSnake, Computer>().ForMember(destination => destination.VideoCard, options => options.MapFrom(source => source.video_card));
            }));
            
            IEnumerable<ComputerSnake>? computerSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computersSnakeJson);

            if (computerSystem != null) {
                IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computerSystem);

                foreach(Computer currComputer in computerResult) {
                    Console.WriteLine($"{currComputer.ComputerId} {currComputer.Motherboard} {currComputer.CPUCores} {currComputer.HasWifi} {currComputer.HasLTE} {currComputer.ReleaseDate} {currComputer.Price} {currComputer.VideoCard}");
                }
            }

             IEnumerable<Computer>? computerSystemJsonPropertyName = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersSnakeJson);
             if (computerSystemJsonPropertyName != null) {
                IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computerSystemJsonPropertyName);

                foreach(Computer currComputer in computerResult) {
                    Console.WriteLine($"{currComputer.ComputerId} {currComputer.Motherboard} {currComputer.CPUCores} {currComputer.HasWifi} {currComputer.HasLTE} {currComputer.ReleaseDate} {currComputer.Price} {currComputer.VideoCard}");
                }
            }
        }
    }
}