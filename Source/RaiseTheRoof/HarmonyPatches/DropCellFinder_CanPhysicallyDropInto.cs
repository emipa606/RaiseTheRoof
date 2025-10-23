using HarmonyLib;
using RimWorld;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(DropCellFinder), nameof(DropCellFinder.CanPhysicallyDropInto))]
public static class DropCellFinder_CanPhysicallyDropInto
{
    private static bool canDropInto(IntVec3 cell, Map map)
    {
        if (cell.GetRoof(map) == RoofDefOf.RTR_RoofSteel)
        {
            return false;
        }

        if (cell.GetRoof(map) == RoofDefOf.RTR_RoofTransparent)
        {
            return false;
        }

        if (cell.GetRoof(map) == RoofDefOf.RTR_RoofSolar)
        {
            return false;
        }

        return cell.GetRoof(map) != RoofDefOf.RTR_RoofTransparentSolar;
    }

    private static void Postfix(ref bool __result, IntVec3 c, Map map)
    {
        if (!canDropInto(c, map))
        {
            __result = false;
        }
    }
}