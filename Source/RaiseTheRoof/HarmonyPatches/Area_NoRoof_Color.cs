using HarmonyLib;
using RimWorld;
using UnityEngine;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(Area_NoRoof), nameof(Area_NoRoof.Color), MethodType.Getter)]
public static class Area_NoRoof_Color
{
    private static bool Prefix(ref Color __result)
    {
        __result = Color.red;
        return false;
    }
}