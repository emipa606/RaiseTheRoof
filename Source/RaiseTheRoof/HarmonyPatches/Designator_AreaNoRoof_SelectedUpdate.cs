using HarmonyLib;
using RimWorld;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(Designator_AreaNoRoof), nameof(Designator_AreaNoRoof.SelectedUpdate))]
public static class Designator_AreaNoRoof_SelectedUpdate
{
    private static bool Prefix(ref Designator_AreaNoRoof __instance)
    {
        GenUI.RenderMouseoverBracket();
        __instance.Map.areaManager.NoRoof.MarkForDraw();
        __instance.Map.areaManager.BuildRoof.MarkForDraw();
        __instance.Map.roofGrid.Drawer.MarkForDraw();
        return false;
    }
}