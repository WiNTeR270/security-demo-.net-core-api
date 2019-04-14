using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api")]
    public class IpAddressController : Controller
    {
        //  NOTE: Requires https://ipinfo.io/ Developer API Key
        private static readonly string GEO_IP_ADDRESS_URL = "http://ipinfo.io/";
        private static readonly string BAD_IP_ADDRESS_FEED_URL = "https://www.binarydefense.com/banlist.txt";
        private static readonly string IP_GEO_LOOKUP_API_KEY = null;
        private readonly List<String> BadIpAddresses;

        public IpAddressController()
        {
            //  TODO: Make this smarter with error recovery in case data feed is down
            HttpWebRequest request = WebRequest.Create(BAD_IP_ADDRESS_FEED_URL) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                this.BadIpAddresses = new List<string>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (String.IsNullOrEmpty(line) || line.StartsWith("#")) continue;
                    this.BadIpAddresses.Add(line);
                }
            }
        }

        //  GET: /maliciousIp/:address
        [HttpGet("maliciousIp")]
        public List<String> Get()
        {
            return this.BadIpAddresses;
        }

        //  GET: /maliciousIp/:address
        [HttpGet("maliciousIp/{address}")]
        public IpAddress Get(string address)
        {
            //  TODO: Improve error handling / source address is inaccessible
            HttpWebRequest request = WebRequest.Create(GEO_IP_ADDRESS_URL + address + "?token=" + IP_GEO_LOOKUP_API_KEY) as HttpWebRequest;
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";
            request.ContentType = "application/json; charset=utf-8";
            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    var ipAddress = JsonConvert.DeserializeObject<IpAddress>(reader.ReadToEnd());
                    ipAddress.Malicious = this.BadIpAddresses.Contains(address);
                    return ipAddress;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to retrieve IP address details");
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
