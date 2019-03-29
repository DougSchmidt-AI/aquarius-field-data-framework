using System;
using PluginTester.DataModel.PickLists;

namespace PluginTester.DataModel.ControlConditions
{
    [Serializable]
    public class ControlCondition
    {
        private string _party;
        private ControlCodePickList _controlCode;
        private ConditionType _controlCondition;
        private Measurement _distanceToGage;
        private ControlCleanedType _controlCleaned;
        private DateTimeOffset? _dateCleaned;
        private string _comments;

        public string Party
        {
            get => _party;
            set => _party = value;
        }

        public ControlCodePickList ControlCode
        {
            get => _controlCode;
            set => _controlCode = value;
        }

        public ConditionType ConditionType
        {
            get => _controlCondition;
            set => _controlCondition = value;
        }

        public Measurement DistanceToGage
        {
            get => _distanceToGage;
            set => _distanceToGage = value;
        }

        public ControlCleanedType ControlCleaned
        {
            get => _controlCleaned;
            set => _controlCleaned = value;
        }

        public DateTimeOffset? DateCleaned
        {
            get => _dateCleaned;
            set => _dateCleaned = value;
        }

        public string Comments
        {
            get => _comments;
            set => _comments = value;
        }
    }
}
