using System;

namespace PluginTester.DataModel.Verticals
{
    [Serializable]
    public class Segment
    {
        private double _width;
        private double _area;
        private double _velocity;
        private double _discharge;
        private bool _isDischargeEstimated;
        private double _totalDischargePortion;

        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public double Area
        {
            get { return _area; }
            set { _area = value; }
        }

        public double Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public double Discharge
        {
            get { return _discharge; }
            set { _discharge = value; }
        }

        public bool IsDischargeEstimated
        {
            get { return _isDischargeEstimated; }
            set { _isDischargeEstimated = value; }
        }

        public double TotalDischargePortion
        {
            get { return _totalDischargePortion; }
            set { _totalDischargePortion = value; }
        }
    }
}
