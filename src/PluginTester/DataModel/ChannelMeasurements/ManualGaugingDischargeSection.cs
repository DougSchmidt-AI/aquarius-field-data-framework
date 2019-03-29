using System;
using System.Collections.ObjectModel;
using PluginTester.DataModel.Verticals;

namespace PluginTester.DataModel.ChannelMeasurements
{
    [Serializable]
    public class ManualGaugingDischargeSection : ChannelMeasurementBase
    {
        public DischargeMethodType DischargeMethod { get; set; }

        public StartPointType StartPoint { get; set; }

        public PointVelocityObservationType VelocityObservationMethod { get; set; }

        public MeterSuspensionType MeterSuspension { get; set; }

        public Measurement Width { get; set; }

        public string AreaUnitId { get; set; }

        public Measurement Area { get; set; }

        public string VelocityUnitId { get; set; }

        public DeploymentMethodType DeploymentMethod { get; set; }

        public Measurement VelocityAverage { get; set; }

        public Collection<Vertical> Verticals { get; set; }
    }
}
