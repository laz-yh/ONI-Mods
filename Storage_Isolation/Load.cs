using HarmonyLib;
using KMod;

namespace Storage_Isolation
{
    internal class HarmonyPatches : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            harmony.PatchAll();

        }
    }
}
