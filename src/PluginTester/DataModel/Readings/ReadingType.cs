namespace PluginTester.DataModel.Readings
{
    public enum ReadingType
    {
        Unknown = 0,
        RoutineBefore,
        Routine,
        RoutineAfter,
        ResetBefore,
        ResetAfter,
        CleaningBefore,
        CleaningAfter,
        AfterCalibration,
        ReferencePrimary,
        Reference,
        ExtremeMin,
        ExtremeMax
    }
}
