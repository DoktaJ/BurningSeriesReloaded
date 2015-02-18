
using System.Collections.Generic;


namespace BurningSeriesReloaded
{
    public partial class Epi
    {
        public string description { get; set; }
        public string id { get; set; }
    }

    public class Link
    {
        public string hoster { get; set; }
        public string part { get; set; }
        public string id { get; set; }
    }

    public class JsonID
    {
        public string series { get; set; }
        public Epi epi { get; set; }
        public List<Link> links { get; set; }
    }
}
