using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drrr_Bot_Kuronaru
{
   public class ANIME_MANGA_SEARCH
    {
        #region [RESULT ANIME]
        public class Result_Anime
        {
            
            public int mal_id { get; set; }
            public string url { get; set; }
            public string image_url { get; set; }
            public string title { get; set; }
            public bool airing { get; set; }
            public string synopsis { get; set; }
            public string type { get; set; }
            public int episodes { get; set; }
            public double score { get; set; }
            public DateTime? start_date { get; set; }
            public DateTime? end_date { get; set; }
            public int members { get; set; }
            public string rated { get; set; }
        }

        public class Root_Anime
        {
            public string request_hash { get; set; }
            public bool request_cached { get; set; }
            public int request_cache_expiry { get; set; }
            public List<Result_Anime> results { get; set; }
            public int last_page { get; set; }
        }
        #endregion

        #region [RESULT MANGA]
        public class Result_Manga
        {
            public int mal_id { get; set; }
            public string url { get; set; }
            public string image_url { get; set; }
            public string title { get; set; }
            public bool publishing { get; set; }
            public string synopsis { get; set; }
            public string type { get; set; }
            public int chapters { get; set; }
            public int volumes { get; set; }
            public double score { get; set; }
            public DateTime? start_date { get; set; }
            public DateTime? end_date { get; set; }
            public int members { get; set; }
        }

        public class Root_Manga
        {
            public string request_hash { get; set; }
            public bool request_cached { get; set; }
            public int request_cache_expiry { get; set; }
            public List<Result_Manga> results { get; set; }
            public int last_page { get; set; }
        }


        #endregion

    }
}
