using HarmonyLib;
using RimWorld;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(Designator_AreaBuildRoof), nameof(Designator_AreaBuildRoof.CanDesignateCell))]
public static class Designator_AreaBuildRoof_CanDesignateCell
{
    private static bool canDesignateCell(Designator_AreaBuildRoof instance, IntVec3 c)
    {
        if (!c.InBounds(instance.Map))
        {
            return false;
        }

        if (c.Fogged(instance.Map))
        {
            return false;
        }

        if (RTRUtils.RoofThingDefExists(instance.Map.thingGrid.ThingsListAt(c)))
        {
            return false;
        }

        var roofDef = instance.Map.roofGrid.RoofAt(c);
        if (roofDef == null)
        {
            return true;
        }

        return roofDef == RimWorld.RoofDefOf.RoofRockThin;
    }

    private static bool Prefix(Designator_AreaBuildRoof __instance, ref AcceptanceReport __result, IntVec3 c)
    {
        __result = canDesignateCell(__instance, c);
        return false;
    }
}