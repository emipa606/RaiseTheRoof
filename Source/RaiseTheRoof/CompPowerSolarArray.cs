using RimWorld;
using UnityEngine;
using Verse;

namespace RaiseTheRoof;

[StaticConstructorOnStartup]
public class CompPowerSolarArray : CompPowerPlant
{
    protected override float DesiredPowerOutput =>
        Mathf.Lerp(0f, RaiseTheRoofMod.settings.solarPowerOutput, parent.Map.skyManager.CurSkyGlow);
}