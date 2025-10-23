using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace RaiseTheRoof;

// Patch Regenerate with a Postfix instead of full replacement.
[HarmonyPatch(typeof(SectionLayer_LightingOverlay), nameof(SectionLayer_LightingOverlay.Regenerate))]
public static class SectionLayer_LightingOverlay_Regenerate
{
    private static readonly FieldInfo fiSectRect = AccessTools.Field(typeof(SectionLayer_LightingOverlay), "sectRect");

    private static readonly FieldInfo fiFirstCenterInd =
        AccessTools.Field(typeof(SectionLayer_LightingOverlay), "firstCenterInd");

    private static readonly PropertyInfo piMap = AccessTools.Property(typeof(SectionLayer), "Map");

    private static Map Map(SectionLayer_LightingOverlay inst)
    {
        return (Map)piMap.GetValue(inst, null);
    }

    private static CellRect SectRect(SectionLayer_LightingOverlay inst)
    {
        return (CellRect)fiSectRect.GetValue(inst);
    }

    private static int FirstCenterInd(SectionLayer_LightingOverlay inst)
    {
        return (int)fiFirstCenterInd.GetValue(inst);
    }

    // Postfix: vanilla already populated mesh colors; adjust only cells under our transparent roofs so they are brighter.
    private static void Postfix(SectionLayer_LightingOverlay __instance)
    {
        var map = Map(__instance);
        if (map == null)
        {
            return;
        }

        var rect = SectRect(__instance);
        var firstCenter = FirstCenterInd(__instance);
        var subMesh = __instance.GetSubMesh(MatBases.LightOverlay);
        if (subMesh?.mesh == null)
        {
            return;
        }

        var colors = subMesh.mesh.colors32;
        if (colors == null || colors.Length == 0)
        {
            return;
        }

        var width = rect.Width;
        // Iterate center cells only (same indexing as vanilla: firstCenter + dx + dz*width)
        for (int z = rect.minZ, dz = 0; z <= rect.maxZ; z++, dz++)
        {
            for (int x = rect.minX, dx = 0; x <= rect.maxX; x++, dx++)
            {
                var cell = new IntVec3(x, 0, z);
                var roof = cell.GetRoof(map);
                if (roof != RoofDefOf.RTR_RoofTransparent && roof != RoofDefOf.RTR_RoofTransparentSolar)
                {
                    continue;
                }

                var centerIndex = firstCenter + (dz * width) + dx;
                if (centerIndex < 0 || centerIndex >= colors.Length)
                {
                    continue;
                }

                // Only reduce alpha to let underlying light show; keep original RGB to avoid square artifact.
                var c = colors[centerIndex];
                var a = (byte)Mathf.Clamp(c.a * 0.1f, 0, 255); // retain some roof shading
                colors[centerIndex] = new Color32(c.r, c.g, c.b, a);
            }
        }

        subMesh.mesh.colors32 = colors;
    }
}