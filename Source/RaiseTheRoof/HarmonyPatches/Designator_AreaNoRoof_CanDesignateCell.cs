using HarmonyLib;
using RimWorld;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(Designator_AreaNoRoof), nameof(Designator_AreaNoRoof.CanDesignateCell))]
public static class Designator_AreaNoRoof_CanDesignateCell
{
    private static bool canDesignateCell(Designator_AreaNoRoof instance, IntVec3 c)
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
            return false;
        }

        if (roofDef == RimWorld.RoofDefOf.RoofRockThin)
        {
            return true;
        }

        return roofDef == RimWorld.RoofDefOf.RoofConstructed;
    }

    private static bool Prefix(Designator_AreaNoRoof __instance, ref AcceptanceReport __result, IntVec3 c)
    {
        __result = canDesignateCell(__instance, c);
        return false;
    }
}