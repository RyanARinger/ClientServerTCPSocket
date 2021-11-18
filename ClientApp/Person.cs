using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ClientApp
{
    class Person
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
