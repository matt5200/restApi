using Newtonsoft.Json;
using System;

namespace HelloWorldService.Models
{
    public class Contact
    {
        public int Id { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonProperty("date_added")]
        public DateTime DateAdded { get; set; }

    }
}