using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace RaiseTheRoof;

public class RTRUtils
{
    private static ThingDef GetRoofThingDef(RoofDef roofDef)
    {
        if (roofDef == RoofDefOf.RTR_RoofSteel)
        {
            return RaiseTheRoofDefOf.RTR_SteelRoof;
        }

        if (roofDef == RoofDefOf.RTR_RoofTransparent)
        {
            return RaiseTheRoofDefOf.RTR_TransparentRoof;
        }

        if (roofDef == RoofDefOf.RTR_RoofSolar)
        {
            return RaiseTheRoofDefOf.RTR_SolarRoof;
        }

        return roofDef == RoofDefOf.RTR_RoofTransparentSolar ? RaiseTheRoofDefOf.RTR_TransparentSolarRoof : null;
    }

    private static List<ThingDef> ListOfRTRThingDefs()
    {
        var list = new List<ThingDef>
        {
            RaiseTheRoofDefOf.RTR_SteelRoof,
            RaiseTheRoofDefOf.RTR_TransparentRoof,
            RaiseTheRoofDefOf.RTR_SolarRoof,
            RaiseTheRoofDefOf.RTR_TransparentSolarRoof
        };
        return list;
    }

    public static void ApplySettings()
    {
        if (RaiseTheRoofMod.settings == null)
        {
            return;
        }

        if (!RaiseTheRoofMod.settings.transparentRoofEnabled)
        {
            RaiseTheRoofMod.settings.transparentSolarRoofEnabled = false;
        }

        if (!RaiseTheRoofMod.settings.solarRoofEnabled)
        {
            RaiseTheRoofMod.settings.transparentSolarRoofEnabled = false;
        }

        var list = ListOfRTRThingDefs();
        if (list.NullOrEmpty())
        {
            return;
        }

        foreach (var item in list)
        {
            if (item == RaiseTheRoofDefOf.RTR_SteelRoof)
            {
                var costList = item.costList;
                foreach (var item2 in costList)
                {
                    if (item2.thingDef == ThingDefOf.Steel)
                    {
                        item2.count = RaiseTheRoofMod.settings.steelRoofSteelCost;
                    }
                }
            }
            else if (item == RaiseTheRoofDefOf.RTR_TransparentRoof)
            {
                var costList2 = item.costList;
                foreach (var item3 in costList2)
                {
                    if (item3.thingDef == ThingDefOf.Steel)
                    {
                        item3.count = RaiseTheRoofMod.settings.transparentRoofSteelCost;
                    }

                    if (item3.thingDef == ThingDef.Named("Synthread"))
                    {
                        item3.count = RaiseTheRoofMod.settings.transparentRoofSynthreadCost;
                    }
                }
            }
            else if (item == RaiseTheRoofDefOf.RTR_SolarRoof)
            {
                var costList3 = item.costList;
                foreach (var item4 in costList3)
                {
                    if (item4.thingDef == ThingDefOf.Steel)
                    {
                        item4.count = RaiseTheRoofMod.settings.solarRoofSteelCost;
                    }

                    if (item4.thingDef == ThingDefOf.ComponentIndustrial)
                    {
                        item4.count = RaiseTheRoofMod.settings.solarRoofComponentCost;
                    }
                }
            }
            else
            {
                if (item != RaiseTheRoofDefOf.RTR_TransparentSolarRoof)
                {
                    continue;
                }

                var costList4 = item.costList;
                foreach (var item5 in costList4)
                {
                    if (item5.thingDef == ThingDefOf.Steel)
                    {
                        item5.count = RaiseTheRoofMod.settings.transparentSolarRoofSteelCost;
                    }

                    if (item5.thingDef == ThingDef.Named("Synthread"))
                    {
                        item5.count = RaiseTheRoofMod.settings.transparentSolarRoofSynthreadCost;
                    }

                    if (item5.thingDef == ThingDefOf.ComponentIndustrial)
                    {
                        item5.count = RaiseTheRoofMod.settings.transparentSolarRoofComponentCost;
                    }
                }
            }
        }
    }

    public static bool RoofThingDefExists(List<Thing> things)
    {
        if (things.NullOrEmpty())
        {
            return false;
        }

        foreach (var thing in things)
        {
            if (thing.def == RaiseTheRoofDefOf.RTR_SteelRoof)
            {
                return true;
            }

            if (thing.def == RaiseTheRoofDefOf.RTR_TransparentRoof)
            {
                return true;
            }

            if (thing.def == RaiseTheRoofDefOf.RTR_SolarRoof)
            {
                return true;
            }

            if (thing.def == RaiseTheRoofDefOf.RTR_TransparentSolarRoof)
            {
                return true;
            }

            if (thing.def == RaiseTheRoofDefOf.RTR_RemoveSteelRoof)
            {
                return true;
            }

            if (thing.def == RaiseTheRoofDefOf.RTR_RemoveTransparentRoof)
            {
                return true;
            }

            if (thing.def == RaiseTheRoofDefOf.RTR_RemoveSolarRoof)
            {
                return true;
            }

            if (thing.def == RaiseTheRoofDefOf.RTR_RemoveTransparentSolarRoof)
            {
                return true;
            }

            if (thing.def == RaiseTheRoofDefOf.RTR_RemoveMountainousRoof)
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Blueprint_RTR_SteelRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Blueprint_RTR_TransparentRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Blueprint_RTR_SolarRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Blueprint_RTR_TransparentSolarRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Blueprint_RTR_RemoveSteelRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Blueprint_RTR_RemoveTransparentRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Blueprint_RTR_RemoveSolarRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Blueprint_RTR_RemoveTransparentSolarRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Blueprint_RTR_RemoveMountainousRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Frame_RTR_SteelRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Frame_RTR_TransparentRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Frame_RTR_SolarRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Frame_RTR_TransparentSolarRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Frame_RTR_RemoveSteelRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Frame_RTR_RemoveTransparentRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Frame_RTR_RemoveSolarRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Frame_RTR_RemoveTransparentSolarRoof"))
            {
                return true;
            }

            if (thing.def == ThingDef.Named("Frame_RTR_RemoveMountainousRoof"))
            {
                return true;
            }
        }

        return false;
    }

    public static bool RoofFrameOrBlueprintExists(Thing thing)
    {
        if (thing == null)
        {
            return false;
        }

        if (thing.def == ThingDef.Named("Blueprint_RTR_SteelRoof"))
        {
            return true;
        }

        if (thing.def == ThingDef.Named("Blueprint_RTR_TransparentRoof"))
        {
            return true;
        }

        if (thing.def == ThingDef.Named("Blueprint_RTR_SolarRoof"))
        {
            return true;
        }

        if (thing.def == ThingDef.Named("Blueprint_RTR_TransparentSolarRoof"))
        {
            return true;
        }

        if (thing.def == ThingDef.Named("Frame_RTR_SteelRoof"))
        {
            return true;
        }

        if (thing.def == ThingDef.Named("Frame_RTR_TransparentRoof"))
        {
            return true;
        }

        if (thing.def == ThingDef.Named("Frame_RTR_SolarRoof"))
        {
            return true;
        }

        return thing.def == ThingDef.Named("Frame_RTR_TransparentSolarRoof");
    }

    public static Thing RemoveRoofExists(IntVec3 cell, Map map)
    {
        var enumerable = map.thingGrid.ThingsAt(cell);
        if (enumerable.EnumerableNullOrEmpty())
        {
            return null;
        }

        foreach (var item in enumerable)
        {
            if (item.def == RaiseTheRoofDefOf.RTR_RemoveSteelRoof ||
                item.def == RaiseTheRoofDefOf.RTR_RemoveTransparentRoof ||
                item.def == RaiseTheRoofDefOf.RTR_RemoveSolarRoof ||
                item.def == RaiseTheRoofDefOf.RTR_RemoveTransparentSolarRoof ||
                item.def == RaiseTheRoofDefOf.RTR_RemoveMountainousRoof ||
                item.def == ThingDef.Named("Blueprint_RTR_RemoveSteelRoof") ||
                item.def == ThingDef.Named("Blueprint_RTR_RemoveTransparentRoof") ||
                item.def == ThingDef.Named("Blueprint_RTR_RemoveSolarRoof") ||
                item.def == ThingDef.Named("Blueprint_RTR_RemoveTransparentSolarRoof") ||
                item.def == ThingDef.Named("Blueprint_RTR_RemoveMountainousRoof") ||
                item.def == ThingDef.Named("Frame_RTR_RemoveSteelRoof") ||
                item.def == ThingDef.Named("Frame_RTR_RemoveTransparentRoof") ||
                item.def == ThingDef.Named("Frame_RTR_RemoveSolarRoof") ||
                item.def == ThingDef.Named("Frame_RTR_RemoveTransparentSolarRoof") ||
                item.def == ThingDef.Named("Frame_RTR_RemoveMountainousRoof"))
            {
                return item;
            }
        }

        return null;
    }

    public static void RemoveRoof(IntVec3 cell, Map map, RoofDef roofDef)
    {
        if (roofDef == null)
        {
            return;
        }

        RoofCollapser.ProcessRoofHolderDespawned(cell, map);
        var roofThingDef = GetRoofThingDef(roofDef);
        if (roofThingDef != null)
        {
            var costList = roofThingDef.costList;
            if (costList == null || !costList.Any())
            {
                return;
            }

            foreach (var item in costList)
            {
                var num = (int)(item.count * 0.8f);
                if (num <= 0)
                {
                    continue;
                }

                var thing = ThingMaker.MakeThing(item.thingDef);
                thing.stackCount = num;
                GenPlace.TryPlaceThing(thing, cell, map, ThingPlaceMode.Near, null, null, default(Rot4));
            }
        }

        if (roofDef != RimWorld.RoofDefOf.RoofRockThick || RaiseTheRoofMod.settings == null)
        {
            return;
        }

        var thingDef = CreateChunk(cell, map);
        if (thingDef == null || Rand.Range(1, 100) > RaiseTheRoofMod.settings.chunkChance)
        {
            return;
        }

        var thing2 = ThingMaker.MakeThing(thingDef);
        GenPlace.TryPlaceThing(thing2, cell, map, ThingPlaceMode.Near, null, null, default(Rot4));
    }

    private static ThingDef CreateChunk(IntVec3 cell, Map map)
    {
        var terrainDef = map.terrainGrid.TerrainAt(cell);
        if (terrainDef != null)
        {
            if (terrainDef == TerrainDef.Named("Sandstone_RoughHewn") ||
                terrainDef == TerrainDef.Named("Sandstone_Rough"))
            {
                return ThingDef.Named("ChunkSandstone");
            }

            if (terrainDef == TerrainDef.Named("Granite_RoughHewn") || terrainDef == TerrainDef.Named("Granite_Rough"))
            {
                return ThingDef.Named("ChunkGranite");
            }

            if (terrainDef == TerrainDef.Named("Marble_RoughHewn") || terrainDef == TerrainDef.Named("Marble_Rough"))
            {
                return ThingDef.Named("ChunkMarble");
            }

            if (terrainDef == TerrainDef.Named("Limestone_RoughHewn") ||
                terrainDef == TerrainDef.Named("Limestone_Rough"))
            {
                return ThingDef.Named("ChunkLimestone");
            }

            if (terrainDef == TerrainDef.Named("Slate_RoughHewn") || terrainDef == TerrainDef.Named("Slate_Rough"))
            {
                return ThingDef.Named("ChunkSlate");
            }
        }

        var allThings = map.listerThings.AllThings;
        if (allThings.NullOrEmpty())
        {
            return null;
        }

        var list = new List<Thing>();
        foreach (var item in allThings)
        {
            if (item != null && (item.def == ThingDef.Named("ChunkSandstone") ||
                                 item.def == ThingDef.Named("ChunkGranite") ||
                                 item.def == ThingDef.Named("ChunkMarble") ||
                                 item.def == ThingDef.Named("ChunkLimestone") ||
                                 item.def == ThingDef.Named("ChunkSlate")))
            {
                list.Add(item);
            }
        }

        if (list.NullOrEmpty())
        {
            return null;
        }

        return GenClosest.ClosestThing_Global_Reachable(cell, map, list, PathEndMode.OnCell,
            TraverseParms.For(TraverseMode.PassAllDestroyableThings))?.def;
    }

    public static ThingDef FindSolarArray(RoofDef roofDef)
    {
        if (roofDef.defName.Equals("RTR_RoofSolar") || roofDef.defName.Equals("RTR_RoofTransparentSolar"))
        {
            return RaiseTheRoofDefOf.RTR_SolarArray;
        }

        return null;
    }

    public static void InstallSolarArray(ThingDef def, IntVec3 cell, Map map)
    {
        var thing = ThingMaker.MakeThing(def);
        thing.SetFaction(Faction.OfPlayer);
        GenPlace.TryPlaceThing(thing, cell, map, ThingPlaceMode.Direct, null, null, default(Rot4));
    }
}