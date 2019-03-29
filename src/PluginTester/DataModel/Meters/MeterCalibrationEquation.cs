using System;

namespace PluginTester.DataModel.Meters
{
    [Serializable]
    public class MeterCalibrationEquation
    {
        private double? _rangeStart;
        private double? _rangeEnd;
        private double _slope;
        private double _intercept;
        private string _interceptUnitId;

        public double? RangeStart
        {
            get { return _rangeStart; }
            set { _rangeStart = value; }
        }

        public double? RangeEnd
        {
            get { return _rangeEnd; }
            set { _rangeEnd = value; }
        }

        public double Slope
        {
            get { return _slope; }
            set { _slope = value; }
        }

        public double Intercept
        {
            get { return _intercept; }
            set { _intercept = value; }
        }

        public string InterceptUnitId
        {
            get { return _interceptUnitId; }
            set { _interceptUnitId = value; }
        }
    }
}
