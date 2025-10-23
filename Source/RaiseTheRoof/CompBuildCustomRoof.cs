using RimWorld;
using Verse;

namespace RaiseTheRoof;

public class CompBuildCustomRoof : ThingComp
{
    private CompProperties_BuildCustomRoof Props => (CompProperties_BuildCustomRoof)props;

    public override void PostSpawnSetup(bool respawningAfterLoad)
    {
        base.PostSpawnSetup(respawningAfterLoad);
        if (respawningAfterLoad)
        {
            return;
        }

        var roofDef = parent.Map.roofGrid.RoofAt(parent.Position);
        if (roofDef != null && roofDef.defName == Props.roofDef.defName)
        {
            return;
        }

        parent.Map.roofGrid.SetRoof(parent.Position, Props.roofDef);
        MoteMaker.PlaceTempRoof(parent.Position, parent.Map);
        var thingDef = RTRUtils.FindSolarArray(Props.roofDef);
        if (thingDef != null)
        {
            RTRUtils.InstallSolarArray(thingDef, parent.Position, parent.Map);
        }
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