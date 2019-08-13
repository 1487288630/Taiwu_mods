﻿using Harmony12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartWear
{
    //WorldMapSystem.DoMapHealing
    [HarmonyPatch(typeof(WorldMapSystem), "DoMapHealing")]
    public class WorldMapSystem_DoMapHealing_Patch
    {
        private static void Prefix(int typ)
        {
            if (!Main.Enabled || !Main.settings.HealingAutoAccessories) return;
            if(typ == 0)
            {
                // 醫療
                StateManager.EquipAccessories((int)AptitudeType.Treatment);
            }
            else
            {
                // 解毒
                StateManager.EquipAccessories((int)AptitudeType.Poison);
            }
        }

        private static void Postfix()
        {
            StateManager.Restore();
        }
    }

}
