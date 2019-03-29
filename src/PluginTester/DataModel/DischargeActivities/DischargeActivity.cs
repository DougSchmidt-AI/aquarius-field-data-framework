using System;
using System.Collections.Generic;
using PluginTester.DataModel.ChannelMeasurements;

namespace PluginTester.DataModel.DischargeActivities
{
    [Serializable]
    public class DischargeActivity
    {
        private DateTimeInterval _measurementPeriod;
        private string _party;
        private string _measurementId;
        private Measurement _meanIndexVelocity;
        private Measurement _discharge;
        private string _comments;
        private bool _showInDataCorrection;
        private bool _showInRatingDevelopment;
        private bool _preventAutomaticPublishing;
        private AdjustmentType? _adjustmentType;
        private double? _adjustmentAmount;
        private ReasonForAdjustmentType? _reasonForAdjustment;

        public DateTimeOffset MeasurementStartTime => MeasurementPeriod.Start;

        public DateTimeOffset MeasurementEndTime => MeasurementPeriod.End;

        public DateTimeInterval MeasurementPeriod
        {
            get => _measurementPeriod;
            set
            {
                _measurementPeriod = value;
            }
        }

        public string Party
        {
            get => _party;
            set => _party = value;
        }

        public string MeasurementId
        {
            get => _measurementId;
            set => _measurementId = value;
        }

        public Measurement MeanIndexVelocity
        {
            get => _meanIndexVelocity;
            set => _meanIndexVelocity = value;
        }

        public Measurement Discharge
        {
            get => _discharge;
            set
            {
                _discharge = value;
            }
        }

        public string Comments
        {
            get => _comments;
            set => _comments = value;
        }

        public bool ShowInRatingDevelopment
        {
            get => _showInRatingDevelopment;
            set => _showInRatingDevelopment = value;
        }

        public bool ShowInDataCorrection
        {
            get => _showInDataCorrection;
            set => _showInDataCorrection = value;
        }

        public bool PreventAutomaticPublishing
        {
            get => _preventAutomaticPublishing;
            set => _preventAutomaticPublishing = value;
        }

        public AdjustmentType? AdjustmentType
        {
            get => _adjustmentType;
            set => _adjustmentType = value;
        }

        public double? AdjustmentAmount
        {
            get => _adjustmentAmount;
            set => _adjustmentAmount = value;
        }

        public ReasonForAdjustmentType? ReasonForAdjustment
        {
            get => _reasonForAdjustment;
            set => _reasonForAdjustment = value;
        }

        public Measurement ManuallyCalculatedMeanGageHeight { get; set; }

        public Measurement MeanGageHeightDifferenceDuringVisit { get; set; }

        public double? MeanGageHeightDurationHours { get; set; }

        public ICollection<GageHeightMeasurement> GageHeightMeasurements { get; set; }

        public ICollection<ChannelMeasurementBase> ChannelMeasurements { get; set; }
    }
}
