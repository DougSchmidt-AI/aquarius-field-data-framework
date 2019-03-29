using System;

namespace PluginTester.DataModel
{
    [Serializable]
    public class DateTimeInterval
    {
        public DateTimeInterval()
        {

        }

        public DateTimeInterval(DateTimeOffset start, DateTimeOffset end)
        {
            Start = start;
            End = end;
        }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }
    }
}
