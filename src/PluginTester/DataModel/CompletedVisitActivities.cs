using System;

namespace PluginTester.DataModel
{
    [Serializable]
    public class CompletedVisitActivities
    {
        private bool _groundWaterLevels;
        private bool _conductedLevelSurvey;
        private bool _recorderDataCollected;
        private bool _safetyInspectionPerformed;
        private bool _otherSample;
        private bool _biologicalSample;
        private bool _sedimentSample;
        private bool _waterQualitySample;

        public bool GroundWaterLevels
        {
            get => _groundWaterLevels;
            set => _groundWaterLevels = value;
        }

        public bool ConductedLevelSurvey
        {
            get => _conductedLevelSurvey;
            set => _conductedLevelSurvey = value;
        }

        public bool RecorderDataCollected
        {
            get => _recorderDataCollected;
            set => _recorderDataCollected = value;
        }

        public bool SafetyInspectionPerformed
        {
            get => _safetyInspectionPerformed;
            set => _safetyInspectionPerformed = value;
        }

        public bool OtherSample
        {
            get => _otherSample;
            set => _otherSample = value;
        }

        public bool BiologicalSample
        {
            get => _biologicalSample;
            set => _biologicalSample = value;
        }

        public bool SedimentSample
        {
            get => _sedimentSample;
            set => _sedimentSample = value;
        }

        public bool WaterQualitySample
        {
            get => _waterQualitySample;
            set => _waterQualitySample = value;
        }
    }
}
