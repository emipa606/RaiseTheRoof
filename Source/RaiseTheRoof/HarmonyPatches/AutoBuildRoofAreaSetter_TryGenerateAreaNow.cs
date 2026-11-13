using HarmonyLib;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(AutoBuildRoofAreaSetter), nameof(AutoBuildRoofAreaSetter.TryGenerateAreaFor))]
public static class AutoBuildRoofAreaSetter_TryGenerateAreaNow
{
    public static bool Prefix()
    {
        return RaiseTheRoofMod.settings == null || RaiseTheRoofMod.settings.autoBuildRoof;
    }
}