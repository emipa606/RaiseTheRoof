using System.Reflection;
using HarmonyLib;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(RoofGrid), nameof(RoofGrid.SetRoof))]
public static class RoofGrid_SetRoof
{
    private static readonly FieldInfo fiMap = typeof(RoofGrid).GetField("map",
        BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic |
        BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.SetProperty);

    private static Map map(RoofGrid instance)
    {
        return (Map)fiMap.GetValue(instance);
    }

    private static void Postfix(RoofGrid __instance, IntVec3 c, RoofDef def)
    {
        if (def != null)
        {
            return;
        }

        foreach (var item in map(__instance).thingGrid.ThingsAt(c))
        {
            if (item.def == RaiseTheRoofDefOf.RTR_SolarArray)
            {
                item.Destroy();
            }
        }
    }
}