using System.Reflection;
using HarmonyLib;
using Verse;

namespace RaiseTheRoof;

[StaticConstructorOnStartup]
internal static class Patches
{
    static Patches()
    {
        new Harmony("raisetheroof.harmony").PatchAll(Assembly.GetExecutingAssembly());
    }
}