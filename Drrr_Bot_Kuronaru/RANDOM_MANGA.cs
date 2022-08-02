using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drrr_Bot_Kuronaru
{
   public class RANDOM_MANGA
    {
        public class Title
        {
            public string en { get; set; }
        }

        public class AltTitle
        {
            public string en { get; set; }
        }

        public class Description
        {
            public string en { get; set; }
        }

        public class Links
        {
            public string al { get; set; }
            public string ap { get; set; }
            public string kt { get; set; }
            public string mu { get; set; }
            public string mal { get; set; }
        }

        public class Name
        {
            public string en { get; set; }
        }

        public class Attributes2
        {
            public Name name { get; set; }
            public int version { get; set; }
            public Title title { get; set; }
            public List<AltTitle> altTitles { get; set; }
            public Description description { get; set; }
            public bool isLocked { get; set; }
            public Links links { get; set; }
            public string originalLanguage { get; set; }
            public object lastVolume { get; set; }
            public string lastChapter { get; set; }
            public string publicationDemographic { get; set; }
            public string status { get; set; }
            public object year { get; set; }
            public string contentRating { get; set; }
            public List<Tag> tags { get; set; }
            public DateTime createdAt { get; set; }
            public object updatedAt { get; set; }
        }

        public class Tag
        {
            public string id { get; set; }
            public string type { get; set; }
            public Attributes2 attributes { get; set; }
        }

        public class Data
        {
            public string id { get; set; }
            public string type { get; set; }
            public Attributes2 attributes { get; set; }
        }

        public class Relationship
        {
            public string id { get; set; }
            public string type { get; set; }
        }

        public class Root
        {
            public string result { get; set; }
            public Data data { get; set; }
            public List<Relationship> relationships { get; set; }
        }


    }
}
