using HarmonyLib;
using RimWorld;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(GenConstruct), nameof(GenConstruct.CanConstruct), typeof(Thing), typeof(Pawn), typeof(bool),
    typeof(bool), typeof(JobDef))]
public static class GenConstruct_CanConstruct
{
    private static bool canConstruct(Building b)
    {
        return RoofCollapseUtility.WithinRangeOfRoofHolder(b.Position, b.Map) &&
               RoofCollapseUtility.ConnectedToRoofHolder(b.Position, b.Map, true);
    }

    private static void Postfix(ref bool __result, Thing t)
    {
        if (__result && t is Building building && RTRUtils.RoofFrameOrBlueprintExists(building))
        {
            __result = canConstruct(building);
        }
    }
}