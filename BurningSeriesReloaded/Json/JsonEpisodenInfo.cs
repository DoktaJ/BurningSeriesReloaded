using System.Collections.Generic;


namespace BurningSeriesReloaded
{
    public partial class Data
    {

    }

    public partial class Series
    {

    }

    public partial class Epi
    {

    }

    public class JsonEpisodenInfo
    {
        public Series series { get; set; }
        public int season { get; set; }
        public List<Epi> epi { get; set; }
    }
}
