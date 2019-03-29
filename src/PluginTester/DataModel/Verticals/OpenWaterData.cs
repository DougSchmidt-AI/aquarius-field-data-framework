using System;

namespace PluginTester.DataModel.Verticals
{
    [Serializable]
    public class OpenWaterData : MeasurementConditionData
    {
        private string _suspensionWeight;
        private double? _distanceToMeter;
        private double _dryLineAngle;
        private double? _surfaceCoefficient;
        private double? _distanceToWaterSurface;
        private double? _dryLineCorrection;
        private double? _wetLineCorrection;

        public string SuspensionWeight
        {
            get { return _suspensionWeight; }
            set { _suspensionWeight = value; }
        }

        public double? DistanceToMeter
        {
            get { return _distanceToMeter; }
            set { _distanceToMeter = value; }
        }

        public double DryLineAngle
        {
            get { return _dryLineAngle; }
            set { _dryLineAngle = value; }
        }

        public double? SurfaceCoefficient
        {
            get { return _surfaceCoefficient; }
            set { _surfaceCoefficient = value; }
        }

        public double? DistanceToWaterSurface
        {
            get { return _distanceToWaterSurface; }
            set { _distanceToWaterSurface = value; }
        }

        public double? DryLineCorrection
        {
            get { return _dryLineCorrection; }
            set { _dryLineCorrection = value; }
        }

        public double? WetLineCorrection
        {
            get { return _wetLineCorrection; }
            set { _wetLineCorrection = value; }
        }
    }
}
