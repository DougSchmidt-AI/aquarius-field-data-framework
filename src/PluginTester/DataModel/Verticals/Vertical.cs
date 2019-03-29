using System;

namespace PluginTester.DataModel.Verticals
{
    [Serializable]
    public class Vertical
    {
        private Segment _segment;
        private MeasurementConditionData _measurementConditionData;
        private VelocityObservation _velocityObservation;
        private int _sequenceNumber;
        private VerticalType _verticalType;
        private FlowDirectionType _flowDirection;
        private double _taglinePosition;
        private double _soundedDepth;
        private bool _isSoundedDepthEstimated;
        private DateTimeOffset? _measurementTime;
        private double _obliqueFlowCorrection;
        private string _comments;
        private double _effectiveDepth;

        public Segment Segment
        {
            get { return _segment; }
            set { _segment = value; }
        }

        public MeasurementConditionData MeasurementConditionData
        {
            get { return _measurementConditionData; }
            set { _measurementConditionData = value; }
        }

        public VelocityObservation VelocityObservation
        {
            get { return _velocityObservation; }
            set { _velocityObservation = value; }
        }

        public int SequenceNumber
        {
            get { return _sequenceNumber; }
            set { _sequenceNumber = value; }
        }

        public VerticalType VerticalType
        {
            get { return _verticalType; }
            set { _verticalType = value; }
        }

        public FlowDirectionType FlowDirection
        {
            get { return _flowDirection; }
            set { _flowDirection = value; }
        }

        public double TaglinePosition
        {
            get { return _taglinePosition; }
            set { _taglinePosition = value; }
        }

        public double SoundedDepth
        {
            get { return _soundedDepth; }
            set { _soundedDepth = value; }
        }

        public bool IsSoundedDepthEstimated
        {
            get { return _isSoundedDepthEstimated; }
            set { _isSoundedDepthEstimated = value; }
        }

        public DateTimeOffset? MeasurementTime
        {
            get { return _measurementTime; }
            set { _measurementTime = value; }
        }

        public double ObliqueFlowCorrection
        {
            get { return _obliqueFlowCorrection; }
            set { _obliqueFlowCorrection = value; }
        }

        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public double EffectiveDepth
        {
            get { return _effectiveDepth; }
            set { _effectiveDepth = value; }
        }
    }
}
