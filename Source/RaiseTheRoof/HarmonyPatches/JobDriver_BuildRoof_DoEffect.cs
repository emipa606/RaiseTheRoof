using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(JobDriver_BuildRoof), "DoEffect")]
public static class JobDriver_BuildRoof_DoEffect
{
    private static readonly PropertyInfo piCell = typeof(JobDriver_AffectRoof).GetProperty("Cell",
        BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic |
        BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.SetProperty);

    private static readonly PropertyInfo piMap = typeof(JobDriver).GetProperty("Map",
        BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic |
        BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.SetProperty);

    private static IntVec3 cell(JobDriver_AffectRoof instance)
    {
        return (IntVec3)piCell.GetValue(instance, null);
    }

    private static Map map(JobDriver instance)
    {
        return (Map)piMap.GetValue(instance, null);
    }

    private static bool Prefix(JobDriver_BuildRoof __instance)
    {
        for (var i = 0; i < 9; i++)
        {
            var intVec = cell(__instance) + GenAdj.AdjacentCellsAndInside[i];
            if (!intVec.InBounds(map(__instance)) || !map(__instance).areaManager.BuildRoof[intVec] ||
                intVec.Roofed(map(__instance)) ||
                !RoofCollapseUtility.WithinRangeOfRoofHolder(intVec, map(__instance)) ||
                RoofUtility.FirstBlockingThing(intVec, map(__instance)) != null)
            {
                continue;
            }

            map(__instance).roofGrid.SetRoof(intVec, RimWorld.RoofDefOf.RoofConstructed);
            MoteMaker.PlaceTempRoof(intVec, map(__instance));
            map(__instance).areaManager.BuildRoof[intVec] = false;
        }

        return false;
    }
}