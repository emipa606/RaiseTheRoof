using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(MainTabWindow_Research), nameof(MainTabWindow_Research.VisibleResearchProjects),
    MethodType.Getter)]
public static class MainTabWindow_Research_VisibleResearchProjects
{
    private static readonly FieldInfo fiCachedVisibleResearchProjects = typeof(MainTabWindow_Research).GetField(
        "cachedVisibleResearchProjects",
        BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic |
        BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.SetProperty);

    private static List<ResearchProjectDef> cachedVisibleResearchProjects(MainTabWindow_Research instance)
    {
        return (List<ResearchProjectDef>)fiCachedVisibleResearchProjects.GetValue(instance);
    }

    private static bool isHiddenResearch(ResearchProjectDef def)
    {
        if (!RaiseTheRoofMod.settings.removeMountainousRoofEnabled &&
            def == RaiseTheRoofDefOf.RTR_OverheadMountainRemoval)
        {
            return true;
        }

        if (!RaiseTheRoofMod.settings.transparentRoofEnabled && def == RaiseTheRoofDefOf.RTR_TransparentRoofing)
        {
            return true;
        }

        if (!RaiseTheRoofMod.settings.solarRoofEnabled && def == RaiseTheRoofDefOf.RTR_SolarRoofing)
        {
            return true;
        }

        return !RaiseTheRoofMod.settings.transparentSolarRoofEnabled &&
               def == RaiseTheRoofDefOf.RTR_TransparentSolarRoofing;
    }

    private static bool Prefix(MainTabWindow_Research __instance, ref List<ResearchProjectDef> __result)
    {
        if (cachedVisibleResearchProjects(__instance) == null)
        {
            fiCachedVisibleResearchProjects.SetValue(__instance,
                new List<ResearchProjectDef>(DefDatabase<ResearchProjectDef>.AllDefsListForReading.Where(d =>
                    (Find.Storyteller.difficulty.AllowedBy(d.hideWhen) || d == Find.ResearchManager.GetProject()) &&
                    !isHiddenResearch(d))));
        }

        __result = cachedVisibleResearchProjects(__instance);
        return false;
    }
}