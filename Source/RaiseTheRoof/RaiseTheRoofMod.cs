using Mlie;
using UnityEngine;
using Verse;

namespace RaiseTheRoof;

[StaticConstructorOnStartup]
public class RaiseTheRoofMod : Mod
{
    public static RaiseTheRoofSettings settings;
    private static string currentVersion;

    public RaiseTheRoofMod(ModContentPack content)
        : base(content)
    {
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
        settings = GetSettings<RaiseTheRoofSettings>();
    }

    private static void ResetDefaults()
    {
        settings.autoBuildRoof = true;
        settings.allowInfestations = false;
        settings.removeMountainousRoofEnabled = true;
        settings.steelRoofEnabled = true;
        settings.transparentRoofEnabled = true;
        settings.solarRoofEnabled = true;
        settings.transparentSolarRoofEnabled = true;
        settings.chunkChance = 33;
        settings.solarPowerOutput = 50;
        settings.steelRoofSteelCost = 50;
        settings.transparentRoofSteelCost = 50;
        settings.transparentRoofSynthreadCost = 10;
        settings.solarRoofSteelCost = 50;
        settings.solarRoofComponentCost = 1;
        settings.transparentSolarRoofSteelCost = 50;
        settings.transparentSolarRoofSynthreadCost = 10;
        settings.transparentSolarRoofComponentCost = 1;
        settings.Write();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        base.DoSettingsWindowContents(inRect);
        var color = new Color(0.07f, 0.07f, 0.07f, 1f);
        var position = new Rect(0f, inRect.position.y + 16f, (inRect.width / 2f) - 8f, inRect.height - 560f);
        GUI.DrawTexture(position, SolidColorMaterials.NewSolidColorTexture(color));
        var rect = new Rect(inRect.position.x + 8f, inRect.position.y + 16f, (inRect.width / 2f) - 16f,
            inRect.height - 560f);
        Widgets.Label(rect, "RTR.General".Translate());
        var rect2 = new Rect(inRect.position.x + 8f, inRect.position.y + 48f, (inRect.width / 2f) - 16f,
            inRect.height - 560f);
        var topLeft = new Vector2(rect2.x, rect2.y);
        Widgets.Checkbox(topLeft, ref settings.autoBuildRoof);
        var color2 = GUI.color = new Color(0.75f, 0.75f, 0.75f, 1f);
        var rect3 = new Rect(inRect.position.x + 40f, inRect.position.y + 48f, (inRect.width / 2f) - 48f,
            inRect.height - 560f);
        Widgets.Label(rect3, "RTR.AutoRoom".Translate());
        GUI.color = Color.white;
        var rect4 = new Rect(inRect.position.x + 8f, inRect.position.y + 80f, (inRect.width / 2f) - 16f,
            inRect.height - 560f);
        var topLeft2 = new Vector2(rect4.x, rect4.y);
        Widgets.Checkbox(topLeft2, ref settings.allowInfestations);
        GUI.color = color2;
        var rect5 = new Rect(inRect.position.x + 40f, inRect.position.y + 80f, (inRect.width / 2f) - 48f,
            inRect.height - 560f);
        Widgets.Label(rect5, "RTR.Infestations".Translate());
        GUI.color = Color.white;
        var rect6 = new Rect(inRect.position.x + 8f, inRect.position.y + 112f, (inRect.width / 2f) - 16f,
            inRect.height - 560f);
        var topLeft3 = new Vector2(rect6.x, rect6.y);
        Widgets.Checkbox(topLeft3, ref settings.removeMountainousRoofEnabled);
        GUI.color = color2;
        var rect7 = new Rect(inRect.position.x + 40f, inRect.position.y + 112f, (inRect.width / 2f) - 48f,
            inRect.height - 560f);
        Widgets.Label(rect7, "RTR.Mountains".Translate());
        GUI.color = Color.white;
        var rect8 = new Rect(inRect.position.x + 8f, inRect.position.y + 144f, (inRect.width / 2f) - 16f,
            inRect.height - 560f);
        var topLeft4 = new Vector2(rect8.x, rect8.y);
        Widgets.Checkbox(topLeft4, ref settings.steelRoofEnabled);
        GUI.color = color2;
        var rect9 = new Rect(inRect.position.x + 40f, inRect.position.y + 144f, (inRect.width / 2f) - 48f,
            inRect.height - 560f);
        Widgets.Label(rect9, "RTR.SteelRoof".Translate());
        GUI.color = Color.white;
        var rect10 = new Rect(inRect.position.x + 8f, inRect.position.y + 176f, (inRect.width / 2f) - 16f,
            inRect.height - 560f);
        var topLeft5 = new Vector2(rect10.x, rect10.y);
        Widgets.Checkbox(topLeft5, ref settings.transparentRoofEnabled);
        GUI.color = color2;
        var rect11 = new Rect(inRect.position.x + 40f, inRect.position.y + 176f, (inRect.width / 2f) - 48f,
            inRect.height - 560f);
        Widgets.Label(rect11, "RTR.TransparentRoof".Translate());
        GUI.color = Color.white;
        var rect12 = new Rect(inRect.position.x + 8f, inRect.position.y + 208f, (inRect.width / 2f) - 16f,
            inRect.height - 560f);
        var topLeft6 = new Vector2(rect12.x, rect12.y);
        Widgets.Checkbox(topLeft6, ref settings.solarRoofEnabled);
        GUI.color = color2;
        var rect13 = new Rect(inRect.position.x + 40f, inRect.position.y + 208f, (inRect.width / 2f) - 48f,
            inRect.height - 560f);
        Widgets.Label(rect13, "RTR.SolarRoof".Translate());
        GUI.color = Color.white;
        var rect14 = new Rect(inRect.position.x + 8f, inRect.position.y + 240f, (inRect.width / 2f) - 16f,
            inRect.height - 560f);
        var topLeft7 = new Vector2(rect14.x, rect14.y);
        Widgets.Checkbox(topLeft7, ref settings.transparentSolarRoofEnabled);
        GUI.color = color2;
        var rect15 = new Rect(inRect.position.x + 40f, inRect.position.y + 240f, (inRect.width / 2f) - 48f,
            inRect.height - 560f);
        Widgets.Label(rect15, "RTR.TransparentSolarRoof".Translate());
        GUI.color = Color.white;
        var position2 = new Rect(0f, inRect.position.y + 304f, (inRect.width / 2f) - 8f, inRect.height - 560f);
        GUI.DrawTexture(position2, SolidColorMaterials.NewSolidColorTexture(color));
        var rect16 = new Rect(inRect.position.x + 8f, inRect.position.y + 304f, (inRect.width / 2f) - 16f,
            inRect.height - 560f);
        Widgets.Label(rect16, "RTR.Misc".Translate());
        var rect17 = new Rect(inRect.position.x + 8f, inRect.position.y + 352f, (inRect.width / 2f) - 20f,
            inRect.height - 560f);
        settings.solarPowerOutput = (int)Widgets.HorizontalSlider(rect17, settings.solarPowerOutput, 1f, 500f, false,
            null, "RTR.SolarOutput".Translate(), "RTR.PowerUnit".Translate(settings.solarPowerOutput));
        var rect18 = new Rect(inRect.position.x + 8f, inRect.position.y + 384f, (inRect.width / 2f) - 20f,
            inRect.height - 560f);
        settings.chunkChance = (int)Widgets.HorizontalSlider(rect18, settings.chunkChance, 1f, 100f, false, null,
            "RTR.ChunkChance".Translate(), (settings.chunkChance / 100f).ToStringPercent());
        var position3 = new Rect(0f, inRect.position.y + 432f, (inRect.width / 2f) - 8f, inRect.height - 560f);
        GUI.DrawTexture(position3, SolidColorMaterials.NewSolidColorTexture(color));
        var rect19 = new Rect(inRect.position.x + 8f, inRect.position.y + 432f, (inRect.width / 2f) - 16f,
            inRect.height - 560f);
        Widgets.Label(rect19, "RTR.Settings".Translate());
        var rect20 = new Rect(inRect.position.x + 8f, inRect.position.y + 464f, (inRect.width / 2f) - 48f,
            inRect.height - 560f);
        Widgets.Label(rect20, "RTR.ResetSettings".Translate());
        var rect21 = new Rect(inRect.position.x + 296f, inRect.position.y + 464f, (inRect.width / 2f) - 304f,
            inRect.height - 560f);
        if (Widgets.ButtonText(rect21, "RTR.Reset".Translate()))
        {
            ResetDefaults();
        }

        var position4 = new Rect(inRect.position.x + 440f, inRect.position.y + 16f, (inRect.width / 2f) - 8f,
            inRect.height - 560f);
        GUI.DrawTexture(position4, SolidColorMaterials.NewSolidColorTexture(color));
        var rect22 = new Rect(inRect.position.x + 448f, inRect.position.y + 16f, (inRect.width / 2f) - 16f,
            inRect.height - 560f);
        Widgets.Label(rect22, "RTR.SteelCost".Translate());
        var rect23 = new Rect(inRect.position.x + 448f, inRect.position.y + 64f, (inRect.width / 2f) - 20f,
            inRect.height - 560f);
        settings.steelRoofSteelCost = (int)Widgets.HorizontalSlider(rect23, settings.steelRoofSteelCost, 1f, 200f,
            false, null, "RTR.Steel".Translate(), settings.steelRoofSteelCost.ToString());
        var position5 = new Rect(inRect.position.x + 440f, inRect.position.y + 112f, (inRect.width / 2f) - 8f,
            inRect.height - 560f);
        GUI.DrawTexture(position5, SolidColorMaterials.NewSolidColorTexture(color));
        var rect24 = new Rect(inRect.position.x + 448f, inRect.position.y + 112f, (inRect.width / 2f) - 16f,
            inRect.height - 560f);
        Widgets.Label(rect24, "RTR.TransparentCost".Translate());
        var rect25 = new Rect(inRect.position.x + 448f, inRect.position.y + 160f, (inRect.width / 2f) - 20f,
            inRect.height - 560f);
        settings.transparentRoofSteelCost = (int)Widgets.HorizontalSlider(rect25, settings.transparentRoofSteelCost, 1f,
            200f, false, null, "RTR.Steel".Translate(), settings.transparentRoofSteelCost.ToString());
        var rect26 = new Rect(inRect.position.x + 448f, inRect.position.y + 192f, (inRect.width / 2f) - 20f,
            inRect.height - 560f);
        settings.transparentRoofSynthreadCost = (int)Widgets.HorizontalSlider(rect26,
            settings.transparentRoofSynthreadCost, 1f, 100f, false, null, "RTR.Synthread".Translate(),
            settings.transparentRoofSynthreadCost.ToString());
        var position6 = new Rect(inRect.position.x + 440f, inRect.position.y + 240f, (inRect.width / 2f) - 8f,
            inRect.height - 560f);
        GUI.DrawTexture(position6, SolidColorMaterials.NewSolidColorTexture(color));
        var rect27 = new Rect(inRect.position.x + 448f, inRect.position.y + 240f, (inRect.width / 2f) - 16f,
            inRect.height - 560f);
        Widgets.Label(rect27, "RTR.SolarCost".Translate());
        var rect28 = new Rect(inRect.position.x + 448f, inRect.position.y + 288f, (inRect.width / 2f) - 20f,
            inRect.height - 560f);
        settings.solarRoofSteelCost = (int)Widgets.HorizontalSlider(rect28, settings.solarRoofSteelCost, 1f, 200f,
            false, null, "RTR.Steel".Translate(), settings.solarRoofSteelCost.ToString());
        var rect29 = new Rect(inRect.position.x + 448f, inRect.position.y + 320f, (inRect.width / 2f) - 20f,
            inRect.height - 560f);
        settings.solarRoofComponentCost = (int)Widgets.HorizontalSlider(rect29, settings.solarRoofComponentCost, 1f,
            10f, false, null, "RTR.Components".Translate(), settings.solarRoofComponentCost.ToString());
        var position7 = new Rect(inRect.position.x + 440f, inRect.position.y + 368f, (inRect.width / 2f) - 8f,
            inRect.height - 560f);
        GUI.DrawTexture(position7, SolidColorMaterials.NewSolidColorTexture(color));
        var rect30 = new Rect(inRect.position.x + 448f, inRect.position.y + 368f, (inRect.width / 2f) - 16f,
            inRect.height - 560f);
        Widgets.Label(rect30, "RTR.TransparentSolarCost".Translate());
        var rect31 = new Rect(inRect.position.x + 448f, inRect.position.y + 416f, (inRect.width / 2f) - 20f,
            inRect.height - 560f);
        settings.transparentSolarRoofSteelCost = (int)Widgets.HorizontalSlider(rect31,
            settings.transparentSolarRoofSteelCost, 1f, 200f, false, null, "RTR.Steel".Translate(),
            settings.transparentSolarRoofSteelCost.ToString());
        var rect32 = new Rect(inRect.position.x + 448f, inRect.position.y + 448f, (inRect.width / 2f) - 20f,
            inRect.height - 560f);
        settings.transparentSolarRoofSynthreadCost = (int)Widgets.HorizontalSlider(rect32,
            settings.transparentSolarRoofSynthreadCost, 1f, 100f, false, null, "RTR.Synthread".Translate(),
            settings.transparentSolarRoofSynthreadCost.ToString());
        var rect33 = new Rect(inRect.position.x + 448f, inRect.position.y + 480f, (inRect.width / 2f) - 20f,
            inRect.height - 560f);
        settings.transparentSolarRoofComponentCost = (int)Widgets.HorizontalSlider(rect33,
            settings.transparentSolarRoofComponentCost, 1f, 10f, false, null, "RTR.Components".Translate(),
            settings.transparentSolarRoofComponentCost.ToString());
        var rect34 = new Rect(inRect.position.x + 448f, inRect.position.y + 510f, (inRect.width / 2f) - 20f,
            inRect.height - 560f);
        if (currentVersion != null)
        {
            GUI.contentColor = Color.gray;
            Widgets.Label(rect34, "RTR.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        RTRUtils.ApplySettings();
        settings.Write();
    }

    public override string SettingsCategory()
    {
        return "Raise The Roof";
    }
}