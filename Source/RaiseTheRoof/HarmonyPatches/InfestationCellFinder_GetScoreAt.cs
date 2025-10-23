using HarmonyLib;
using RimWorld;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(InfestationCellFinder), "GetScoreAt")]
public static class InfestationCellFinder_GetScoreAt
{
    private static bool canSpawnAt(IntVec3 cell, Map map)
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

    private static void Postfix(ref float __result, IntVec3 cell, Map map)
    {
        if (RaiseTheRoofMod.settings != null && !RaiseTheRoofMod.settings.allowInfestations &&
            !canSpawnAt(cell, map))
        {
            __result = 0f;
        }
    }
}