using System.Collections.Generic;
using Verse;

namespace RaiseTheRoof;

public static class RoofCollapser
{
    private static readonly List<IntVec3> roofsCollapsingBecauseTooFar = [];

    private static readonly HashSet<IntVec3> visitedCells = [];

    public static void ProcessRoofHolderDespawned(IntVec3 loc, Map map)
    {
        CheckCollapseFlyingRoofs(loc, map);
        var roofGrid = map.roofGrid;
        roofsCollapsingBecauseTooFar.Clear();
        for (var i = 0; i < RoofCollapseUtility.RoofSupportRadialCellsCount; i++)
        {
            var intVec = loc + GenRadial.RadialPattern[i];
            if (!intVec.InBounds(map) || !roofGrid.Roofed(intVec.x, intVec.z) ||
                map.roofCollapseBuffer.IsMarkedToCollapse(intVec) ||
                RoofCollapseUtility.WithinRangeOfRoofHolder(intVec, map))
            {
                continue;
            }

            RTRUtils.RemoveRoofExists(intVec, map)?.Kill();
            map.roofCollapseBuffer.MarkToCollapse(intVec);
            roofsCollapsingBecauseTooFar.Add(intVec);
        }

        foreach (var item in roofsCollapsingBecauseTooFar)
        {
            CheckCollapseFlyingRoofs(item, map);
        }

        roofsCollapsingBecauseTooFar.Clear();
    }

    private static void CheckCollapseFlyingRoofs(IntVec3 loc, Map map, bool removalMode = false)
    {
        visitedCells.Clear();
        CheckCollapseFlyingRoofAtAndAdjInternal(loc, map, removalMode);
        visitedCells.Clear();
    }

    private static void CheckCollapseFlyingRoofAtAndAdjInternal(IntVec3 loc, Map map, bool removalMode)
    {
        var roofCollapseBuffer = map.roofCollapseBuffer;
        if (removalMode && roofCollapseBuffer.CellsMarkedToCollapse.Count > 0)
        {
            map.roofCollapseBufferResolver.CollapseRoofsMarkedToCollapse();
        }

        for (var i = 0; i < 5; i++)
        {
            var intVec = loc + GenAdj.CardinalDirectionsAndInside[i];
            if (intVec.InBounds(map) && intVec.Roofed(map) && !visitedCells.Contains(intVec) &&
                !roofCollapseBuffer.IsMarkedToCollapse(intVec) &&
                !RoofCollapseCellsFinder.ConnectsToRoofHolder(intVec, map, visitedCells))
            {
                map.floodFiller.FloodFill(intVec, x => x.Roofed(map), delegate(IntVec3 x)
                {
                    RTRUtils.RemoveRoofExists(x, map)?.Kill();
                    roofCollapseBuffer.MarkToCollapse(x);
                });
            }
        }
    }
}