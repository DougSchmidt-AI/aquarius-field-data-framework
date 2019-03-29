using System;

namespace PluginTester.DataModel.Verticals
{
    [Serializable]
    public class IceCoveredData : MeasurementConditionData
    {
        private double? _iceThickness;
        private double _waterSurfaceToBottomOfSlush;
        private double _waterSurfaceToBottomOfIce;
        private string _iceAssemblyType;
        private double? _aboveFooting;
        private double? _belowFooting;
        private double? _underIceCoefficient;

        public double? IceThickness
        {
            get { return _iceThickness; }
            set { _iceThickness = value; }
        }

        public double WaterSurfaceToBottomOfSlush
        {
            get { return _waterSurfaceToBottomOfSlush; }
            set { _waterSurfaceToBottomOfSlush = value; }
        }

        public double WaterSurfaceToBottomOfIce
        {
            get { return _waterSurfaceToBottomOfIce; }
            set { _waterSurfaceToBottomOfIce = value; }
        }

        public string IceAssemblyType
        {
            get { return _iceAssemblyType; }
            set { _iceAssemblyType = value; }
        }

        public double? AboveFooting
        {
            get { return _aboveFooting; }
            set { _aboveFooting = value; }
        }

        public double? BelowFooting
        {
            get { return _belowFooting; }
            set { _belowFooting = value; }
        }

        public double? UnderIceCoefficient
        {
            get { return _underIceCoefficient; }
            set { _underIceCoefficient = value; }
        }
    }
}
