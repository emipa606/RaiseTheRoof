using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(JobDriver_RemoveRoof), "DoEffect")]
public static class JobDriver_RemoveRoof_DoEffect
{
    private static readonly PropertyInfo piCell = typeof(JobDriver_AffectRoof).GetProperty("Cell",
        BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic |
        BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.SetProperty);

    private static readonly PropertyInfo piMap = typeof(JobDriver).GetProperty("Map",
        BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic |
        BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.SetProperty);

    private static IntVec3 cell(JobDriver_AffectRoof instance)
    {
        return (IntVec3)piCell.GetValue(instance, null);
    }

    private static Map map(JobDriver instance)
    {
        return (Map)piMap.GetValue(instance, null);
    }

    private static void Postfix(JobDriver_RemoveRoof __instance)
    {
        map(__instance).areaManager.NoRoof[cell(__instance)] = false;
    }
}