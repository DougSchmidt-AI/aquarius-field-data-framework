using System;
using PluginTester.DataModel.PickLists;

namespace PluginTester.DataModel.ChannelMeasurements
{
    [Serializable]
    public class AdcpDischargeSection : ChannelMeasurementBase
    {
        public string AdcpDeviceType { get; set; }

        public int? NumberOfTransects { get; set; }

        public double? MagneticVariation { get; set; }

        public double? DischargeCoefficientVariation { get; set; }

        public double? PercentOfDischargeMeasured { get; set; }

        public Measurement Width { get; set; }

        public string AreaUnitId { get; set; }

        public Measurement Area { get; set; }

        public string VelocityUnitId { get; set; }

        public Measurement VelocityAverage { get; set; }

        public double? TransducerDepth { get; set; }

        public double? TopEstimateExponent { get; set; }
        public TopEstimateMethodPickList TopEstimateMethod { get; set; }
        public double? BottomEstimateExponent { get; set; }
        public BottomEstimateMethodPickList BottomEstimateMethod { get; set; }

        public MeasurementDevice MeasurementDevice { get; set; }
        public NavigationMethodPickList NavigationMethod { get; set; }
        public string FirmwareVersion { get; set; }
        public string SoftwareVersion { get; set; }
        public DepthReferenceType DepthReference { get; set; }
        public AdcpDeploymentMethodType DeploymentMethod { get; set; }
        public AdcpMeterSuspensionType MeterSuspension { get; set; }
    }
}
