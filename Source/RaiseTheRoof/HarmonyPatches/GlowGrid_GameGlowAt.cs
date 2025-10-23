using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(GlowGrid), nameof(GlowGrid.GroundGlowAt))]
public static class GlowGrid_GameGlowAt
{
    private static readonly FieldInfo fiMap = typeof(GlowGrid).GetField("map",
        BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic |
        BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.SetProperty);

    private static readonly MethodInfo miGetAccumulatedGlowAt = typeof(GlowGrid).GetMethod("GetAccumulatedGlowAt",
        BindingFlags.Instance | BindingFlags.NonPublic, null, CallingConventions.Any, [
            typeof(IntVec3),
            typeof(bool)
        ], null);

    private static Map map(GlowGrid instance)
    {
        return (Map)fiMap.GetValue(instance);
    }

    private static Color32 getAccumulatedGlowAt(GlowGrid instance, IntVec3 c, bool ignoreCavePlants)
    {
        return (Color32)miGetAccumulatedGlowAt.Invoke(instance, [c, ignoreCavePlants]);
    }

    private static float groundGlowAt(GlowGrid instance, IntVec3 c, bool ignoreCavePlants = false,
        bool ignoreSky = false)
    {
        var num = 0f;
        var map = GlowGrid_GameGlowAt.map(instance);
        if (!ignoreSky && !map.roofGrid.Roofed(c) || map.roofGrid.RoofAt(c) == RoofDefOf.RTR_RoofTransparent ||
            map.roofGrid.RoofAt(c) == RoofDefOf.RTR_RoofTransparentSolar)
        {
            num = map.skyManager.CurSkyGlow;
            if (num == 1f)
            {
                return num;
            }
        }

        var accumulatedGlowAt = getAccumulatedGlowAt(instance, c, ignoreCavePlants);
        if (accumulatedGlowAt.a == 1)
        {
            return 1f;
        }

        var b = Mathf.Max(Mathf.Max(accumulatedGlowAt.r, accumulatedGlowAt.g), accumulatedGlowAt.b) / 255f * 3.6f;
        b = Mathf.Min(0.5f, b);
        return Mathf.Max(num, b);
    }

    private static bool Prefix(ref GlowGrid __instance, ref float __result, ref IntVec3 c,
        bool ignoreCavePlants = false)
    {
        __result = groundGlowAt(__instance, c, ignoreCavePlants);
        return false;
    }
}