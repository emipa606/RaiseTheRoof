using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(Designator_Build), nameof(Designator_Build.Visible), MethodType.Getter)]
public static class Designator_Build_Visible
{
    private static readonly FieldInfo FI_entDef = typeof(Designator_Build).GetField("entDef",
        BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic |
        BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.SetProperty);

    private static BuildableDef entDef(Designator_Build instance)
    {
        return (BuildableDef)FI_entDef.GetValue(instance);
    }

    private static bool Prefix(Designator_Build __instance, ref bool __result)
    {
        if (entDef(__instance) == RaiseTheRoofDefOf.RTR_SolarArray)
        {
            __result = false;
            return false;
        }

        if (RaiseTheRoofMod.settings == null)
        {
            return true;
        }

        if ((RaiseTheRoofMod.settings.removeMountainousRoofEnabled ||
             entDef(__instance) != RaiseTheRoofDefOf.RTR_RemoveMountainousRoof) &&
            (RaiseTheRoofMod.settings.steelRoofEnabled ||
             entDef(__instance) != RaiseTheRoofDefOf.RTR_SteelRoof &&
             entDef(__instance) != RaiseTheRoofDefOf.RTR_RemoveSteelRoof) &&
            (RaiseTheRoofMod.settings.transparentRoofEnabled ||
             entDef(__instance) != RaiseTheRoofDefOf.RTR_TransparentRoof &&
             entDef(__instance) != RaiseTheRoofDefOf.RTR_RemoveTransparentRoof) &&
            (RaiseTheRoofMod.settings.solarRoofEnabled ||
             entDef(__instance) != RaiseTheRoofDefOf.RTR_SolarRoof &&
             entDef(__instance) != RaiseTheRoofDefOf.RTR_RemoveSolarRoof) &&
            (RaiseTheRoofMod.settings.transparentSolarRoofEnabled ||
             entDef(__instance) != RaiseTheRoofDefOf.RTR_TransparentSolarRoof &&
             entDef(__instance) != RaiseTheRoofDefOf.RTR_RemoveTransparentSolarRoof))
        {
            return true;
        }

        __result = false;
        return false;
    }
}