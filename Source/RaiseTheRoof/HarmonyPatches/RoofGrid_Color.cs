using HarmonyLib;
using UnityEngine;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(RoofGrid), nameof(RoofGrid.Color), MethodType.Getter)]
public static class RoofGrid_Color
{
    private static bool Prefix(ref Color __result)
    {
        __result = Color.white;
        return false;
    }
}