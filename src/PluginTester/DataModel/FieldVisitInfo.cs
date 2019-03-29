using System;
using System.Collections.Generic;
using PluginTester.DataModel.ControlConditions;
using PluginTester.DataModel.LevelSurveys;
using PluginTester.DataModel.Readings;
using DischargeActivity = PluginTester.DataModel.DischargeActivities.DischargeActivity;
using CrossSectionSurvey = PluginTester.DataModel.CrossSection.CrossSectionSurvey;

namespace PluginTester.DataModel
{
    [Serializable]
    public class FieldVisitInfo
    {
        public FieldVisitInfo()
        {
            DischargeActivities = new List<DischargeActivity>();
            ControlConditions = new List<ControlCondition>();
            CrossSectionSurveys = new List<CrossSectionSurvey>();
            LevelSurveys = new List<LevelSurvey>();
            Readings = new List<Reading>();
        }

        public LocationInfo LocationInfo { get; set; }

        public Int64 LocationId => LocationInfo.LocationId;

        public Int64 FieldVisitId => default(Int64);

        public DateTimeOffset StartDate => FieldVisitDetails.FieldVisitPeriod.Start;

        public DateTimeOffset EndDate => FieldVisitDetails.FieldVisitPeriod.End;

        public string Party => FieldVisitDetails.Party;

        public string FieldVisitIdentifier => GenerateIdentifier(this);

        public FieldVisitDetails FieldVisitDetails { get; set; }

        public static string GenerateIdentifier(FieldVisitInfo fieldVisit) => FormattableString.Invariant($"{fieldVisit.LocationInfo.LocationIdentifier}:{fieldVisit.StartDate}");

        public ICollection<DischargeActivity> DischargeActivities { get; set; }
        public ICollection<ControlCondition> ControlConditions { get; set; }
        public ICollection<CrossSectionSurvey> CrossSectionSurveys { get; set; }
        public ICollection<LevelSurvey> LevelSurveys { get; set; }
        public ICollection<Reading> Readings { get; set;  }
    }
}
