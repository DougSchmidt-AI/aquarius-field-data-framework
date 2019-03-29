using System;

namespace PluginTester.DataModel.PickLists
{
    [Serializable]
    public abstract class PickList
    {
        public string IdOrDisplayName { get; set; }
    }
}
