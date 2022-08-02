using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Drrr_Bot_Kuronaru
{
    public class YTMUSIC
    {
        public class UploadedAt
        {
            [JsonPropertyName("date")]
            public string Date { get; set; }

            [JsonPropertyName("timezone_type")]
            public int TimezoneType { get; set; }

            [JsonPropertyName("timezone")]
            public string Timezone { get; set; }
        }

        public class Root
        {
            [JsonPropertyName("error")]
            public bool Error { get; set; }

            [JsonPropertyName("youtube_id")]
            public string YoutubeId { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("alt_title")]
            public string AltTitle { get; set; }

            [JsonPropertyName("duration")]
            public int Duration { get; set; }

            [JsonPropertyName("file")]
            public string File { get; set; }

            [JsonPropertyName("uploaded_at")]
            public UploadedAt UploadedAt { get; set; }
        }


    }
}
