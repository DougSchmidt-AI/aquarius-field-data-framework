using System;
using PluginTester.DataModel.PickLists;

namespace PluginTester.DataModel.Readings
{
    [Serializable]
    public class Reading
    {
        public string ParameterId { get; set; }

        public string Method { get; set; }

        public Measurement Measurement { get; set; }

        public double? Uncertainty { get; set; }

        public ReadingType ReadingType { get; set; }

        public MeasurementDevice MeasurementDevice { get; set; }

        public DateTimeOffset? DateTimeOffset { get; set; }

        public bool Publish { get; set; }

        public string SubLocation { get; set; }

        public string Comments { get; set; }

        public string ReferencePointName { get; set; }

        public ReadingQualifierPickList ReadingQualifier { get; set; }

        public GroundWaterMeasurementDetails GroundWaterMeasurementDetails { get; set; }
    }
}
