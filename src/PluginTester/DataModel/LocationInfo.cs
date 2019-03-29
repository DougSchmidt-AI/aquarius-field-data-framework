using System;

namespace PluginTester.DataModel
{
    [Serializable]
    public class LocationInfo
    {
        public Int64 LocationId { get; set;  }

        public string LocationIdentifier { get; set; }

        public string LocationName { get; set; }

        public string UniqueId { get; set; }

        public TimeSpan UtcOffset { get; set; }
    }
}
