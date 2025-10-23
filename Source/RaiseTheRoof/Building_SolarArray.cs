using Verse;

namespace RaiseTheRoof;

public class Building_SolarArray : Building
{
    public override void DeSpawn(DestroyMode mode = DestroyMode.Vanish)
    {
        var roofDef = Map.roofGrid.RoofAt(Position);
        if (roofDef != null && !Map.roofCollapseBuffer.IsMarkedToCollapse(Position))
        {
            Map.roofGrid.SetRoof(Position, null);
        }

        base.DeSpawn(mode);
    }
}