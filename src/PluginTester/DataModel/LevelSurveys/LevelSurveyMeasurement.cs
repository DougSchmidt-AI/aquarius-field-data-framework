using System;

namespace PluginTester.DataModel.LevelSurveys
{
    [Serializable]
    public class LevelSurveyMeasurement
    {
        public string ReferencePointName { get; set; }

        public DateTimeOffset MeasurementTime { get; set; }

        public double MeasuredElevation { get; set; }

        public string Comments { get; set; }
    }
}
