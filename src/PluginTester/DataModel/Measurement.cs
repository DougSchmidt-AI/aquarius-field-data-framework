using System;

namespace PluginTester.DataModel
{
    [Serializable]
    public class Measurement
    {
        public double Value { get; set; }

        public string UnitId { get; set; }
    }
}
