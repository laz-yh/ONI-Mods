using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unlock_Cheat.AutoGoToMedBed
{
    internal class AutoGoToMedBed
    {
        [HarmonyPatch(typeof(WoundMonitor))]
        [HarmonyPatch("InitializeStates")]
        public class WoundMonitorInitializeStates
        {
                        public static void Postfix(ref WoundMonitor __instance)
            {
                __instance.wounded.light.ToggleUrge(Db.Get().Urges.Heal).Update("AutoAssignClinic", delegate (WoundMonitor.Instance smi, float dt)
                {
                    smi.FindAvailableMedicalBed();
                }, UpdateRate.SIM_1000ms, false);
                __instance.wounded.medium.ToggleUrge(Db.Get().Urges.Heal).Update("AutoAssignClinic", delegate (WoundMonitor.Instance smi, float dt)
                {
                    smi.FindAvailableMedicalBed();

                }, UpdateRate.SIM_1000ms, false);

            }

                        //public static void AutoAssignClinic(WoundMonitor.Instance smi)
            //{
            //    Ownables soleOwner = smi.gameObject.GetComponent<MinionIdentity>().GetSoleOwner();
            //    AssignableSlot clinic = Db.Get().AssignableSlots.Clinic;
            //    AssignableSlotInstance slot = soleOwner.GetSlot(clinic);
            //    if (slot == null || slot.assignable != null)
            //    {
            //        return;
            //    }
            //    soleOwner.AutoAssignSlot(clinic);
            //}


        }
    }
}
