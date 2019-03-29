using System;

namespace PluginTester.DataModel.CrossSection
{
    [Serializable]
    public class CrossSectionPoint
    {
        public int SortOrder { get; set; }

        public double? Depth { get; set; }

        public double Distance { get; set; }

        public double Elevation { get; set; }

        public string Comments { get; set; }
    }
}
