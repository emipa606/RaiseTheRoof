using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(PowerNet), nameof(PowerNet.CurrentEnergyGainRate))]
public static class PowerNet_CurrentEnergyGainRate
{
    private static bool Prefix(PowerNet __instance, ref float __result)
    {
        if (DebugSettings.unlimitedPower)
        {
            return true;
        }

        var num = (int)Mathf.Lerp(0f, 50f, __instance.Map.skyManager.CurSkyGlow);
        var num2 = 0;
        if (RaiseTheRoofMod.settings != null)
        {
            num = (int)Mathf.Lerp(0f, RaiseTheRoofMod.settings.solarPowerOutput,
                __instance.Map.skyManager.CurSkyGlow);
        }

        foreach (var transmitter in __instance.transmitters)
        {
            if (transmitter.parent.def == RaiseTheRoofDefOf.RTR_SolarArray)
            {
                num2 += num;
            }
        }

        if (num2 == 0)
        {
            return true;
        }

        var num3 = 0f;
        foreach (var compPowerTrader in __instance.powerComps)
        {
            if (compPowerTrader.PowerOn)
            {
                num3 += compPowerTrader.EnergyOutputPerTick;
            }
        }

        num3 += num2 * CompPower.WattsToWattDaysPerTick;
        __result = num3;
        return false;
    }
}