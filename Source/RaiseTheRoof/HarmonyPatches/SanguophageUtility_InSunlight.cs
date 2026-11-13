using HarmonyLib;
using RimWorld;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(SanguophageUtility), nameof(SanguophageUtility.InSunlight))]
public static class SanguophageUtility_InSunlight
{
    public static void Postfix(ref bool __result, IntVec3 cell, Map map)
    {
        if (__result || !cell.InBounds(map))
        {
            return;
        }

        var roof = cell.GetRoof(map);

        if (roof == RoofDefOf.RTR_RoofTransparent || roof == RoofDefOf.RTR_RoofTransparentSolar)
        {
            __result = map.skyManager.CurSkyGlow > 0.1f;
        }
    }
}