using Builder.Presentation;
using HarmonyLib;

namespace Patches
{
    [HarmonyPatch(typeof(ApplicationManager),
        nameof(ApplicationManager.SetDarkTheme))]
    internal class Patch01
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}