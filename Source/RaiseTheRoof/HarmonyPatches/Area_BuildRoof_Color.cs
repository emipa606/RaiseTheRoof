using HarmonyLib;
using RimWorld;
using UnityEngine;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(Area_BuildRoof), nameof(Area_BuildRoof.Color), MethodType.Getter)]
public static class Area_BuildRoof_Color
{
    private static bool Prefix(ref Color __result)
    {
        __result = Color.green;
        return false;
    }
}