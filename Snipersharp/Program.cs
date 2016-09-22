using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensage;
using Ensage.Common.Extensions;
using Ensage.Common.Menu;
using SharpDX;


namespace SniperSharp
{
    internal class SniperSharp
    {
        private static Hero me;
        private static Hero target;
        private static readonly Menu Menu = new Menu("Sniper Sharp", "SniperSharp", true, "npc_dota_hero_sniper", true); //test commit 1
        private static string _isalived;
        private static AbilityToggler useAbility;
        private static bool useitemCheck;
        private static Ability Assasinate;
        private static bool enableR = true;
        private static int minimumDistance = 2000;

        static void Main(string[] args)
        {
            Menu.AddItem(new MenuItem("toggle", "Enabled").SetValue(true));
            Menu.AddToMainMenu();
            Game.OnUpdate += Game_OnUpdate;
            Console.WriteLine("SniperSharp Loaded");
        }

        public static void Game_OnUpdate(EventArgs args)
        {
            if (!Game.IsInGame || me.ClassID != ClassID.CDOTA_Unit_Hero_Sniper) return;
            if (!Menu.Item("toggle").GetValue<bool>()) return;
            var r = me.Spellbook.SpellR;
            var rlvl = me.Spellbook.SpellR.Level;
            var rdmg = 0;
            if (rlvl <= 0)
                rdmg = 0;
            if (rlvl == 1)
                rdmg = 220;
            if (rlvl == 2)
                rdmg = 385;
            if (rlvl == 3)
                rdmg = 550;
            if (rdmg > target.Health) return;

            if (target != null && Assasinate != null)
            {
                Assasinate.UseAbility(target);
                target = null;
                
            }

        }

    }
}
