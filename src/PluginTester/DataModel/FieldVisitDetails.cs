using System;

namespace PluginTester.DataModel
{
    [Serializable]
    public class FieldVisitDetails
    {
        public DateTimeOffset StartDate => FieldVisitPeriod.Start;
        public DateTimeOffset EndDate => FieldVisitPeriod.End;

        public DateTimeInterval FieldVisitPeriod { get; set; }

        public string Party { get; set; }

        public string Comments { get; set; }

        public string Weather { get; set; }

        public string CollectionAgency { get; set; }

        public CompletedVisitActivities CompletedVisitActivities { get; set; }
    }
}
