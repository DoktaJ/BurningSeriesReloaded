using System.Collections.Generic;

namespace BurningSeriesReloaded
{
    public partial class Data
    {
        public List<string> director { get; set; }
        public List<string> actor { get; set; }
        public List<string> author { get; set; }
        public List<string> producer { get; set; }
        public List<string> genre { get; set; }
        public string genre_main { get; set; }
    }

    public partial class Series
    {
        public string id { get; set; }
        public string series { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string movies { get; set; }
        public string seasons { get; set; }
        public Data data { get; set; }
    }

    public partial class Epi
    {
        public string german { get; set; }
        public string english { get; set; }
        public string epi { get; set; }
        public string watched { get; set; }
    }

    public class JsonSerienInfos
    {
        public Series series { get; set; }
        public int season { get; set; }
        public List<Epi> epi { get; set; }
    }
}
