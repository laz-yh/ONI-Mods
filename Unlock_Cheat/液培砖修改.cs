using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Unlock_Cheat.HydroponicFarm
{
    internal class HydroponicFarm
    {

        [HarmonyPatch(typeof(HydroponicFarmConfig))]
        [HarmonyPatch("ConfigureBuildingTemplate")]
        public static class HydroponicFarmConfig_ConfigureBuildingTemplate_Patch
        {
            public static void Postfix(GameObject go, Tag prefab_tag)
            {
                Storage storage= go.GetComponent<Storage>();
                List<Storage.StoredItemModifier> defaultStoredItemModifiers = new List<Storage.StoredItemModifier>
                {
                    Storage.StoredItemModifier.Hide,
                    Storage.StoredItemModifier.Seal,
                    Storage.StoredItemModifier.Insulate,
                    Storage.StoredItemModifier.Preserve
                };
                storage.SetDefaultStoredItemModifiers(defaultStoredItemModifiers);
            }
        }


    }
}
