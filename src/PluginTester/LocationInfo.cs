using System;

namespace FieldDataPluginFramework.Context
{
    [Serializable]
    public class LocationInfo
    {
        public Int64 LocationId { get; }

        public string LocationIdentifier { get; }

        public string LocationName { get; }

        public string UniqueId { get; }

        public TimeSpan UtcOffset { get; }

        internal LocationInfo(string name, string identifier, Int64 id, Guid uniqueId, double utcOffset)
        {
            LocationIdentifier = identifier;
            LocationName = name;
            LocationId = id;
            UniqueId = uniqueId.ToString();
            UtcOffset = TimeSpan.FromHours(utcOffset);
        }
    }
}
