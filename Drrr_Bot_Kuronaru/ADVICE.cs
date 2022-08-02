using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Drrr_Bot_Kuronaru
{
   public class ADVICE
    {
        public class Slip
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("advice")]
            public string Advice { get; set; }
        }

        public class Root
        {
            [JsonPropertyName("slip")]
            public Slip Slip { get; set; }
        }


    }
}
