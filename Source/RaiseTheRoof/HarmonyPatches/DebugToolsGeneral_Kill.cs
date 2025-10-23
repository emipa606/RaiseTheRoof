using System.Linq;
using HarmonyLib;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(DebugToolsGeneral), "Kill")]
public static class DebugToolsGeneral_Kill
{
    private static bool Prefix()
    {
        foreach (var item in Find.CurrentMap.thingGrid.ThingsAt(UI.MouseCell()).ToList())
        {
            if (item.def != RaiseTheRoofDefOf.RTR_SolarArray)
            {
                item.Kill();
            }
        }

        return false;
    }
}