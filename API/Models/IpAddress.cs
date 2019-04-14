using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    /**
     * Simple IP Address JSON Record
     */
    public class IpAddress
    {
        [JsonProperty("ip")]
        public string Ip { get; set; }
        [JsonProperty("hostname")]
        public string Host { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("postal")]
        public int ZipCode { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("company")]
        public IpProvider IpProvider { get; set; }
        [JsonProperty("loc")]
        public string Location
        {
            set
            {
                //  convert location string to Latitude/Longitude variables
                if(!String.IsNullOrEmpty(value))
                {
                    var values = value.Split(',');
                    if (values.Length != 2) return;
                    Latitude = Double.Parse(values[0]);
                    Longitude = Double.Parse(values[1]);
                }
            }

        }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Malicious { get; set; }
    }
    
    /**
     * Simple IP Provider JSON Record
     */
    public class IpProvider
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("domain")]
        public string Domain { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
