using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Drrr_Bot_Kuronaru
{
    public class GIF_TENOR
    {
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class Nanomp4
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("dims")]
            public List<int> Dims { get; set; }

            [JsonPropertyName("duration")]
            public double Duration { get; set; }

            [JsonPropertyName("preview")]
            public string Preview { get; set; }

            [JsonPropertyName("size")]
            public int Size { get; set; }
        }

        public class Nanowebm
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("dims")]
            public List<int> Dims { get; set; }

            [JsonPropertyName("preview")]
            public string Preview { get; set; }

            [JsonPropertyName("size")]
            public int Size { get; set; }
        }

        public class Tinygif
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("dims")]
            public List<int> Dims { get; set; }

            [JsonPropertyName("preview")]
            public string Preview { get; set; }

            [JsonPropertyName("size")]
            public int Size { get; set; }
        }

        public class Tinymp4
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("dims")]
            public List<int> Dims { get; set; }

            [JsonPropertyName("duration")]
            public double Duration { get; set; }

            [JsonPropertyName("preview")]
            public string Preview { get; set; }

            [JsonPropertyName("size")]
            public int Size { get; set; }
        }

        public class Tinywebm
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("dims")]
            public List<int> Dims { get; set; }

            [JsonPropertyName("preview")]
            public string Preview { get; set; }

            [JsonPropertyName("size")]
            public int Size { get; set; }
        }

        public class Webm
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("dims")]
            public List<int> Dims { get; set; }

            [JsonPropertyName("preview")]
            public string Preview { get; set; }

            [JsonPropertyName("size")]
            public int Size { get; set; }
        }

        public class Gif
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("dims")]
            public List<int> Dims { get; set; }

            [JsonPropertyName("preview")]
            public string Preview { get; set; }

            [JsonPropertyName("size")]
            public int Size { get; set; }
        }

        public class Mp4
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("dims")]
            public List<int> Dims { get; set; }

            [JsonPropertyName("duration")]
            public double Duration { get; set; }

            [JsonPropertyName("preview")]
            public string Preview { get; set; }

            [JsonPropertyName("size")]
            public int Size { get; set; }
        }

        public class Loopedmp4
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("dims")]
            public List<int> Dims { get; set; }

            [JsonPropertyName("duration")]
            public double Duration { get; set; }

            [JsonPropertyName("preview")]
            public string Preview { get; set; }

            [JsonPropertyName("size")]
            public int Size { get; set; }
        }

        public class Mediumgif
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("dims")]
            public List<int> Dims { get; set; }

            [JsonPropertyName("preview")]
            public string Preview { get; set; }

            [JsonPropertyName("size")]
            public int Size { get; set; }
        }

        public class Nanogif
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("dims")]
            public List<int> Dims { get; set; }

            [JsonPropertyName("preview")]
            public string Preview { get; set; }

            [JsonPropertyName("size")]
            public int Size { get; set; }
        }

        public class Medium
        {
            [JsonPropertyName("nanomp4")]
            public Nanomp4 Nanomp4 { get; set; }

            [JsonPropertyName("nanowebm")]
            public Nanowebm Nanowebm { get; set; }

            [JsonPropertyName("tinygif")]
            public Tinygif Tinygif { get; set; }

            [JsonPropertyName("tinymp4")]
            public Tinymp4 Tinymp4 { get; set; }

            [JsonPropertyName("tinywebm")]
            public Tinywebm Tinywebm { get; set; }

            [JsonPropertyName("webm")]
            public Webm Webm { get; set; }

            [JsonPropertyName("gif")]
            public Gif Gif { get; set; }

            [JsonPropertyName("mp4")]
            public Mp4 Mp4 { get; set; }

            [JsonPropertyName("loopedmp4")]
            public Loopedmp4 Loopedmp4 { get; set; }

            [JsonPropertyName("mediumgif")]
            public Mediumgif Mediumgif { get; set; }

            [JsonPropertyName("nanogif")]
            public Nanogif Nanogif { get; set; }
        }

        public class Result
        {
            [JsonPropertyName("tags")]
            public List<object> Tags { get; set; }

            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("media")]
            public List<Medium> Media { get; set; }

            [JsonPropertyName("created")]
            public double Created { get; set; }

            [JsonPropertyName("shares")]
            public int Shares { get; set; }

            [JsonPropertyName("itemurl")]
            public string Itemurl { get; set; }

            [JsonPropertyName("composite")]
            public object Composite { get; set; }

            [JsonPropertyName("hasaudio")]
            public bool Hasaudio { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("hascaption")]
            public bool? Hascaption { get; set; }
        }

        public class Root
        {
            [JsonPropertyName("weburl")]
            public string Weburl { get; set; }

            [JsonPropertyName("results")]
            public List<Result> Results { get; set; }

            [JsonPropertyName("next")]
            public string Next { get; set; }
        }


    }
}
