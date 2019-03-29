// ReSharper disable ConvertToAutoPropertyWithPrivateSetter - Backing store for serialization

using System;

namespace PluginTester.DataModel
{
    [Serializable]
    public class MeasurementDevice
    {
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string SerialNumber { get; set; }
    }
}
