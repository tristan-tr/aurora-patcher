using System.Runtime.InteropServices;
using HarmonyLib;

namespace Patches
{
    public class EntryPoint
    {
        public EntryPoint()
        {
            AllocConsole();
            var harmony = new Harmony("com.example.patch");
            harmony.PatchAll();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
    }
}