using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(RoofGrid), nameof(RoofGrid.GetCellExtraColor))]
public static class RoofGrid_GetCellExtraColor
{
    private static readonly FieldInfo fiRoofGrid = typeof(RoofGrid).GetField("roofGrid",
        BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic |
        BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.SetProperty);


    private static RoofDef[] roofGrid(RoofGrid instance)
    {
        return (RoofDef[])fiRoofGrid.GetValue(instance);
    }

    private static Color GetCellExtraColor(RoofGrid instance, int index)
    {
        if (roofGrid(instance)[index] == RimWorld.RoofDefOf.RoofRockThick)
        {
            return new Color(1f, 0.65f, 0f);
        }

        if (roofGrid(instance)[index] == RimWorld.RoofDefOf.RoofRockThin)
        {
            return Color.yellow;
        }

        if (roofGrid(instance)[index] == RimWorld.RoofDefOf.RoofConstructed)
        {
            return Color.cyan;
        }

        if (roofGrid(instance)[index] == RoofDefOf.RTR_RoofSteel)
        {
            return Color.blue;
        }

        if (roofGrid(instance)[index] == RoofDefOf.RTR_RoofTransparent)
        {
            return new Color(0.93f, 0.51f, 0.93f);
        }

        if (roofGrid(instance)[index] == RoofDefOf.RTR_RoofSolar)
        {
            return new Color(0f, 0.42f, 0.33f);
        }

        return roofGrid(instance)[index] == RoofDefOf.RTR_RoofTransparentSolar
            ? new Color(0.49f, 0.15f, 0.8f)
            : Color.white;
    }

    private static bool Prefix(RoofGrid __instance, ref Color __result, int index)
    {
        __result = GetCellExtraColor(__instance, index);
        return false;
    }
}