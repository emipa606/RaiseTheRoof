using HarmonyLib;
using Verse;

namespace RaiseTheRoof;

[HarmonyPatch(typeof(SavedGameLoaderNow), nameof(SavedGameLoaderNow.LoadGameFromSaveFileNow))]
public static class SavedGameLoaderNow_LoadGameFromSaveFileNow
{
    private static void Prefix()
    {
        RTRUtils.ApplySettings();
    }
}