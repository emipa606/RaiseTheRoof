using HarmonyLib;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(RoofCollapseCellsFinder), nameof(RoofCollapseCellsFinder.Notify_RoofHolderDespawned))]
public static class RoofCollapseCellsFinder_Notify_RoofHolderDespawned
{
    public static bool Prefix(Thing t, Map map)
    {
        if (Current.ProgramState == ProgramState.Playing)
        {
            RoofCollapser.ProcessRoofHolderDespawned(t.Position, map);
        }

        return false;
    }
}