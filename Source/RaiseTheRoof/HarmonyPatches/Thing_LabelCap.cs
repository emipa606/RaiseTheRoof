using HarmonyLib;
using UnityEngine;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(Thing), nameof(Thing.LabelCap), MethodType.Getter)]
public static class Thing_LabelCap
{
    private static bool Prefix(ref string __result, Thing __instance)
    {
        if (__instance == null || __instance.def != RaiseTheRoofDefOf.RTR_SolarArray)
        {
            return true;
        }

        var num = (int)Mathf.Lerp(0f, 50f, __instance.Map.skyManager.CurSkyGlow);
        if (RaiseTheRoofMod.settings != null)
        {
            num = (int)Mathf.Lerp(0f, RaiseTheRoofMod.settings.solarPowerOutput,
                __instance.Map.skyManager.CurSkyGlow);
        }

        __result = "RTR.PowerOutput".Translate(__instance.Label.CapitalizeFirst(__instance.def), num);
        return false;
    }
}