// ReSharper disable ConvertToAutoPropertyWithPrivateSetter - Backing store for serialization

using System;
using System.Collections.Generic;
using PluginTester.DataModel.ChannelMeasurements;

namespace PluginTester.DataModel.CrossSection
{
    [Serializable]
    public class CrossSectionSurvey
    {
        private List<CrossSectionPoint> _points = new List<CrossSectionPoint>();
        private string _channelName;
        private string _comments;
        private string _distanceUnitId;
        private string _party;
        private string _relativeLocationName;
        private Measurement _stageMeasurement;
        private StartPointType _startPoint;
        private DateTimeInterval _surveyPeriod;

        public DateTimeOffset StartTime => SurveyPeriod.Start;

        public DateTimeOffset EndTime => SurveyPeriod.End;

        public DateTimeInterval SurveyPeriod
        {
            get => _surveyPeriod;
            set
            {
                _surveyPeriod = value;
            }
        }

        public string Party
        {
            get => _party;
            set => _party = value;
        }

        public string ChannelName
        {
            get => _channelName;
            set
            {
                _channelName = value;
            }
        }

        public string RelativeLocationName
        {
            get => _relativeLocationName;
            set
            {
                _relativeLocationName = value;
            }
        }

        public string DistanceUnitId
        {
            get => _distanceUnitId;
            set
            {
                _distanceUnitId = value;
            }
        }

        public StartPointType StartPoint
        {
            get => _startPoint;
            set
            {
                _startPoint = value;
            }
        }

        public Measurement StageMeasurement
        {
            get => _stageMeasurement;
            set => _stageMeasurement = value;
        }

        public string Comments
        {
            get => _comments;
            set => _comments = value;
        }

        public List<CrossSectionPoint> CrossSectionPoints
        {
            get => _points;
            set
            {

                _points = value;
            }
        }
    }
}
