using HarmonyLib;
using RimWorld;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(Designator_AreaBuildRoof), nameof(Designator_AreaBuildRoof.SelectedUpdate))]
public static class Designator_AreaBuildRoof_SelectedUpdate
{
    private static bool Prefix(ref Designator_AreaBuildRoof __instance)
    {
        GenUI.RenderMouseoverBracket();
        __instance.Map.areaManager.BuildRoof.MarkForDraw();
        __instance.Map.areaManager.NoRoof.MarkForDraw();
        __instance.Map.roofGrid.Drawer.MarkForDraw();
        return false;
    }
}