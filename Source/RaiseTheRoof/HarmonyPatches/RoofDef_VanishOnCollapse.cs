using HarmonyLib;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(RoofDef), nameof(RoofDef.VanishOnCollapse), MethodType.Getter)]
public static class RoofDef_VanishOnCollapse
{
    private static bool Prefix(RoofDef __instance, ref bool __result)
    {
        if (!__instance.ToString().StartsWith("RTR_"))
        {
            return true;
        }

        __result = true;
        return false;
    }
}