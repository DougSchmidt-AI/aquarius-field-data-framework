using System;
using System.Collections.ObjectModel;
using PluginTester.DataModel.ChannelMeasurements;
using PluginTester.DataModel.Meters;

namespace PluginTester.DataModel.Verticals
{
    [Serializable]
    public class VelocityObservation
    {
        private MeterCalibration _meterCalibration;
        private PointVelocityObservationType? _velocityObservationMethod;
        private DeploymentMethodType? _deploymentMethod;
        private readonly Collection<VelocityDepthObservation> _observations = new Collection<VelocityDepthObservation>();
        private double _meanVelocity;

        public MeterCalibration MeterCalibration
        {
            get { return _meterCalibration; }
            set { _meterCalibration = value; }
        }

        public PointVelocityObservationType? VelocityObservationMethod
        {
            get { return _velocityObservationMethod; }
            set { _velocityObservationMethod = value; }
        }

        public DeploymentMethodType? DeploymentMethod
        {
            get { return _deploymentMethod; }
            set { _deploymentMethod = value; }
        }

        public Collection<VelocityDepthObservation> Observations => _observations;

        public double MeanVelocity
        {
            get { return _meanVelocity; }
            set { _meanVelocity = value; }
        }
    }
}
