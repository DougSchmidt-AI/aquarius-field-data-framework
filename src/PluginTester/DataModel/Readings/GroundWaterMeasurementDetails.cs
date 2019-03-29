using System;

namespace PluginTester.DataModel.Readings
{
    [Serializable]
    public class GroundWaterMeasurementDetails
    {
        private double? _cut;
        private double? _hold;
        private double? _tapeCorrection;
        private double? _waterLevel;

        public double? Cut
        {
            get => _cut;
            set => _cut = value;
        }

        public double? Hold
        {
            get => _hold;
            set => _hold = value;
        }

        public double? TapeCorrection
        {
            get => _tapeCorrection;
            set => _tapeCorrection = value;
        }

        public double? WaterLevel
        {
            get =>  _waterLevel;
            set => _waterLevel = value;
        }
    }
}
