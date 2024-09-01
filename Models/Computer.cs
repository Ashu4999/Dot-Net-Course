using System.Text.Json.Serialization;

namespace HelloWorld.Models
{
    public class Computer
    {
        // private string _motherboard;
        // private string MotherBoard { get { return _motherboard; } set { _motherboard = value; } }
        [JsonPropertyName("computer_id")]
        public int ComputerId { get; set; }
        [JsonPropertyName("motherboard")]
        public string Motherboard { get; set; } = String.Empty;
        [JsonPropertyName("cpu_cores")]
        public int? CPUCores { get; set; } = 0;
        [JsonPropertyName("has_wifi")]
        public bool HasWifi { get; set; }
        [JsonPropertyName("has_lte")]
        public bool HasLTE { get; set; }
        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("video_card")]
        public string VideoCard { get; set; } = String.Empty;

        // public Computer()
        // {
        //     if (MotherBoard == null)
        //     {
        //         MotherBoard = "";
        //     }
        //     if (VideoCard == null)
        //     {
        //         VideoCard = "";
        //     }
        // }
    }
}