using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Unlock_Cheat.NuclearResearchCenter
{
    internal class NuclearResearchCenter_Patch
    {


        [HarmonyPatch(typeof(NuclearResearchCenterConfig))]
        [HarmonyPatch("ConfigureBuildingTemplate")] 
        public class NuclearResearchCenterConfig_ConfigureBuildingTemplate_Patch
        {
            public static void Postfix(NuclearResearchCenterConfig __instance, GameObject go)
            {
               go.AddOrGet<NuclearResearchCenter_SideScreen>();

            }
        }

    }
}
