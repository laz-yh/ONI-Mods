using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using UnityEngine;

namespace Unlock_Cheat.RocketPatch
{
    internal class RocketTile
    {
        [HarmonyPatch(typeof(RocketEnvelopeWindowTileConfig))]
        [HarmonyPatch("DoPostConfigureComplete")]
        public class RocketTile_RocketEnvelopeWindowTileConfig
        {
            public static void Postfix(ref GameObject go)
            {
                go.GetComponent<Deconstructable>().allowDeconstruction = true;
            }
        }

        [HarmonyPatch(typeof(RocketWallTileConfig))]
        [HarmonyPatch("DoPostConfigureComplete")]
        public class RocketTile_RocketWallTileConfig
        {
            public static void Postfix(ref GameObject go)
            {
                go.GetComponent<Deconstructable>().allowDeconstruction = true;
            }
        }


    }

    internal class Rocket_Speed
    {
        [HarmonyPatch(typeof(Clustercraft))]
        [HarmonyPatch("Speed", MethodType.Getter)]
        public class Clustercraft_Speed
        {
            public static void Postfix(ref float __result)
            {
                if (__result > 0f)
                {
                    __result *= Unlock_Cheat.Options.Rocket_Speed;
                }

            }
        }

    }

    internal class Rocket_Telescope
    {
        [HarmonyPatch(typeof(ClusterTelescope.ClusterTelescopeWorkable))]
        [HarmonyPatch("OnWorkTick")]
        public class ClusterTelescopeWorkable_OnWorkTick
        {
            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                Debug.Log(" === ClusterTelescopeWorkable_OnWorkTick Transpiler applied === ");
                return instructions.Manipulator(
                    instr => instr.opcode == OpCodes.Ldc_R4 && ((float)instr.operand) == 600f,
                    instr => instr.operand = 6f
                );
            }
        }

    }
}
