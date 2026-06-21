using HarmonyLib;
using KMod;
using System.Collections.Generic;

namespace Storage_Isolation
{
    public class Storage_Patch
    {

        [HarmonyPatch(typeof(Storage))]
        [HarmonyPatch("SetDefaultStoredItemModifiers")]
        public static class Storage_SetDefaultStoredItemModifierse_Patch
        {
            public static bool Prefix(ref List<Storage.StoredItemModifier> ___defaultStoredItemModifers)
            {
                ___defaultStoredItemModifers = defaultStoredItemModifiers;
                return false;
            }
        }

        [HarmonyPatch(typeof(Storage))]
        [HarmonyPatch("OnSpawn")]
        public static class Storage_OnSpawn_Patch
        {
            public static bool Prefix(ref List<Storage.StoredItemModifier> ___defaultStoredItemModifers)
            {
                ___defaultStoredItemModifers = defaultStoredItemModifiers;
                return true;
            }
        }

        public static List<Storage.StoredItemModifier> defaultStoredItemModifiers = new List<Storage.StoredItemModifier>
                {
                    Storage.StoredItemModifier.Hide,     // 隐藏贴图
                    Storage.StoredItemModifier.Seal,     // 升华
                    Storage.StoredItemModifier.Insulate, // 隔热
                    Storage.StoredItemModifier.Preserve  // 腐烂
                };

    }
}
