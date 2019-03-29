using System;

namespace PluginTester.DataModel.Verticals
{
    [Serializable]
    public class VelocityDepthObservation
    {
        private double _depth;
        private int? _revolutionCount;
        private double? _observationInterval;
        private double _velocity;
        private bool _isVelocityEstimated;

        public double Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        public int? RevolutionCount
        {
            get { return _revolutionCount; }
            set { _revolutionCount = value; }
        }

        public double? ObservationInterval
        {
            get { return _observationInterval; }
            set { _observationInterval = value; }
        }

        public double Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public bool IsVelocityEstimated
        {
            get { return _isVelocityEstimated; }
            set { _isVelocityEstimated = value; }
        }
    }
}
