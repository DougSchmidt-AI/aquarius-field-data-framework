using System;

namespace PluginTester.DataModel.DischargeActivities
{
    [Serializable]
    public class GageHeightMeasurement
    {
        public Measurement GageHeight { get; set; }

        public DateTimeOffset? MeasurementTime { get; set; }

        public bool Include { get; set; }
    }
}
