using Verse;

namespace RaiseTheRoof;

public class RaiseTheRoofSettings : ModSettings
{
    public bool allowInfestations;
    public bool autoBuildRoof = true;

    public int chunkChance = 33;

    public bool removeMountainousRoofEnabled = true;

    public int solarPowerOutput = 50;

    public int solarRoofComponentCost = 1;

    public bool solarRoofEnabled = true;

    public int solarRoofSteelCost = 50;

    public bool steelRoofEnabled = true;

    public int steelRoofSteelCost = 50;

    public bool transparentRoofEnabled = true;

    public int transparentRoofSteelCost = 50;

    public int transparentRoofSynthreadCost = 10;

    public int transparentSolarRoofComponentCost = 1;

    public bool transparentSolarRoofEnabled = true;

    public int transparentSolarRoofSteelCost = 50;

    public int transparentSolarRoofSynthreadCost = 10;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref autoBuildRoof, "autoBuildRoof", true);
        Scribe_Values.Look(ref allowInfestations, "allowInfestations");
        Scribe_Values.Look(ref removeMountainousRoofEnabled, "removeMountainousRoofEnabled", true);
        Scribe_Values.Look(ref steelRoofEnabled, "steelRoofEnabled", true);
        Scribe_Values.Look(ref transparentRoofEnabled, "transparentRoofEnabled", true);
        Scribe_Values.Look(ref solarRoofEnabled, "solarRoofEnabled", true);
        Scribe_Values.Look(ref transparentSolarRoofEnabled, "transparentSolarRoofEnabled", true);
        Scribe_Values.Look(ref chunkChance, "chunkChance", 33);
        Scribe_Values.Look(ref solarPowerOutput, "solarPowerOutput", 50);
        Scribe_Values.Look(ref steelRoofSteelCost, "roofSteelCost", 50);
        Scribe_Values.Look(ref transparentRoofSteelCost, "transparentRoofSteelCost", 50);
        Scribe_Values.Look(ref transparentRoofSynthreadCost, "transparentRoofSynthreadCost", 10);
        Scribe_Values.Look(ref solarRoofSteelCost, "solarRoofSteelCost", 50);
        Scribe_Values.Look(ref solarRoofComponentCost, "solarRoofComponentCost", 1);
        Scribe_Values.Look(ref transparentSolarRoofSteelCost, "transparentSolarRoofSteelCost", 50);
        Scribe_Values.Look(ref transparentSolarRoofSynthreadCost, "transparentSolarRoofSynthreadCost", 10);
        Scribe_Values.Look(ref transparentSolarRoofComponentCost, "transparentSolarRoofComponentCost", 1);
    }
}