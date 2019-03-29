using System;

namespace PluginTester.DataModel.ChannelMeasurements
{
    [Serializable]
    public abstract class ChannelMeasurementBase
    {
        public DateTimeInterval MeasurementPeriod { get; set; }

        public string Party { get; set; }

        public string ChannelName { get; set; }

        public Measurement Discharge { get; set; }

        public string Comments { get; set; }

        public string DistanceUnitId { get; set; }

    }
}
