using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Drrr_Bot_Kuronaru
{
    public class ANIME_FIND_IMG
    {

        public class Doc
        {
            [JsonPropertyName("filename")]
            public string Filename { get; set; }

            [JsonPropertyName("episode")]
            public object Episode { get; set; }

            [JsonPropertyName("from")]
            public double From { get; set; }

            [JsonPropertyName("to")]
            public double To { get; set; }

            [JsonPropertyName("similarity")]
            public double Similarity { get; set; }

            [JsonPropertyName("anilist_id")]
            public int AnilistId { get; set; }

            [JsonPropertyName("anime")]
            public string Anime { get; set; }

            [JsonPropertyName("at")]
            public double At { get; set; }

            [JsonPropertyName("is_adult")]
            public bool IsAdult { get; set; }

            [JsonPropertyName("mal_id")]
            public int MalId { get; set; }

            [JsonPropertyName("season")]
            public string Season { get; set; }

            [JsonPropertyName("synonyms")]
            public List<string> Synonyms { get; set; }

            [JsonPropertyName("synonyms_chinese")]
            public List<string> SynonymsChinese { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("title_chinese")]
            public string TitleChinese { get; set; }

            [JsonPropertyName("title_english")]
            public string TitleEnglish { get; set; }

            [JsonPropertyName("title_native")]
            public string TitleNative { get; set; }

            [JsonPropertyName("title_romaji")]
            public string TitleRomaji { get; set; }

            [JsonPropertyName("tokenthumb")]
            public string Tokenthumb { get; set; }
        }

        public class Root
        {
            [JsonPropertyName("RawDocsCount")]
            public int RawDocsCount { get; set; }

            [JsonPropertyName("CacheHit")]
            public bool CacheHit { get; set; }

            [JsonPropertyName("trial")]
            public int Trial { get; set; }

            [JsonPropertyName("limit")]
            public int Limit { get; set; }

            [JsonPropertyName("limit_ttl")]
            public int LimitTtl { get; set; }

            [JsonPropertyName("quota")]
            public int Quota { get; set; }

            [JsonPropertyName("quota_ttl")]
            public int QuotaTtl { get; set; }

            [JsonPropertyName("RawDocsSearchTime")]
            public int RawDocsSearchTime { get; set; }

            [JsonPropertyName("ReRankSearchTime")]
            public int ReRankSearchTime { get; set; }

            [JsonPropertyName("docs")]
            public List<Doc> Docs { get; set; }
        }


    }
}
