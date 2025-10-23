using HarmonyLib;
using RimWorld;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(GenConstruct), nameof(GenConstruct.CanPlaceBlueprintOver))]
public static class GenConstruct_CanPlaceBlueprintOver
{
    private static bool Prefix(ref bool __result, BuildableDef newDef)
    {
        if (!newDef.ToString().StartsWith("RTR_"))
        {
            return true;
        }

        __result = true;
        return false;
    }
}