using RimWorld;
using UnityEngine;
using Verse;

namespace RaiseTheRoof;

public class PlaceWorker_BuildRoof : PlaceWorker
{
    public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
        Thing thingToIgnore = null, Thing thing = null)
    {
        if (!loc.InBounds(map))
        {
            return false;
        }

        if (loc.Fogged(map))
        {
            return false;
        }

        var roofDef = map.roofGrid.RoofAt(loc);
        if (roofDef is { isThickRoof: true })
        {
            return false;
        }

        return !RTRUtils.RoofThingDefExists(map.thingGrid.ThingsListAt(loc));
    }

    public override void PostPlace(Map map, BuildableDef def, IntVec3 loc, Rot4 rot)
    {
        foreach (var item in map.thingGrid.ThingsAt(loc))
        {
            if (item.def.plant is { interferesWithRoof: true })
            {
                Messages.Message("MessageRoofIncompatibleWithPlant".Translate(item), MessageTypeDefOf.CautionInput,
                    false);
            }
        }
    }

    public override void DrawGhost(ThingDef def, IntVec3 center, Rot4 rot, Color ghostCol, Thing thing = null)
    {
        var currentMap = Find.CurrentMap;
        GenUI.RenderMouseoverBracket();
        currentMap.areaManager.BuildRoof.MarkForDraw();
        currentMap.areaManager.NoRoof.MarkForDraw();
        currentMap.roofGrid.Drawer.MarkForDraw();
    }
}