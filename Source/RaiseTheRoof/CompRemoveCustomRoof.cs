using Verse;

namespace RaiseTheRoof;

public class CompRemoveCustomRoof : ThingComp
{
    private CompProperties_RemoveCustomRoof Props => (CompProperties_RemoveCustomRoof)props;

    public override void PostSpawnSetup(bool respawningAfterLoad)
    {
        base.PostSpawnSetup(respawningAfterLoad);
        if (respawningAfterLoad)
        {
            return;
        }

        var roofDef = parent.Map.roofGrid.RoofAt(parent.Position);
        if (roofDef != null && roofDef.defName != Props.roofDef.defName)
        {
            return;
        }

        parent.Map.roofGrid.SetRoof(parent.Position, null);
        RTRUtils.RemoveRoof(parent.Position, parent.Map, roofDef);
    }

    public override void CompTick()
    {
        base.CompTick();
        if (!parent.Destroyed)
        {
            parent.Destroy();
        }
    }
}