﻿namespace PKHeX.Core
{
    public interface ILocation
    {
        int Location { get; set; }
        int EggLocation { get; set; }
    }

    public static partial class Extensions
    {
        public static int GetLocation(this ILocation encounter)
        {
            return encounter.Location != 0
                ? encounter.Location
                : encounter.EggLocation;
        }

        internal static string? GetEncounterLocation(this ILocation Encounter, int gen, int version = -1)
        {
            int loc = Encounter.GetLocation();
            if (loc < 0)
                return null;

            bool egg = loc != Encounter.Location;
            return GameInfo.GetLocationName(egg, loc, gen, gen, (GameVersion)version);
        }
    }
}
