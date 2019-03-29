using System;
using System.Collections.Generic;
using System.Linq;
using FieldDataPluginFramework.Validation;

namespace PluginTester.DataModel.LevelSurveys
{
    [Serializable]
    public class LevelSurvey
    {
        private string _party;
        private string _comments;
        private string _originReferencePointName;
        private string _method;
        private List<LevelSurveyMeasurement> _measurements = new List<LevelSurveyMeasurement>();

        public string Party
        {
            get => _party;
            set => _party = value;
        }

        public string Comments
        {
            get => _comments;
            set => _comments = value;
        }

        public string OriginReferencePointName
        {
            get => _originReferencePointName;
            set
            {
                ValidationChecks.CannotBeNullOrEmpty(nameof(OriginReferencePointName), value);
                _originReferencePointName = value;
            }
        }

        public string Method
        {
            get => _method;
            set
            {
                ValidationChecks.CannotBeNullOrEmpty(nameof(Method), value);
                _method = value;
            }
        }

        public List<LevelSurveyMeasurement> LevelSurveyMeasurements
        {
            get => _measurements;
            set
            {
                ValidationChecks.CannotBeNullOrEmpty(nameof(LevelSurveyMeasurements), value);

                ValidationChecks.MustHaveUniqueValues(nameof(LevelSurveyMeasurements), value,
                    nameof(LevelSurveyMeasurement.ReferencePointName), m => m.ReferencePointName);

                _measurements = value;
            }
        }

        public DateTimeInterval SurveyPeriod => GetSurveyPeriodFromMeasurements();

        private DateTimeInterval GetSurveyPeriodFromMeasurements()
        {
            if (!_measurements.Any())
                return null;

            var startTime = _measurements.Min(m => m.MeasurementTime);
            var endtTime = _measurements.Max(m => m.MeasurementTime);

            return new DateTimeInterval(startTime, endtTime);
        }
    }
}
