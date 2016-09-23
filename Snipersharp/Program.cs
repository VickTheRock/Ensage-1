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
        private static int manaForR = 375;
        private static readonly Menu Menu = new Menu("Sniper Sharp", "SniperSharp", true, "npc_dota_hero_sniper", true); //test commit 1
        private static string _isalived;
        private static AbilityToggler useAbility;
        private static bool useitemCheck;
        private static Ability Assasinate;
        private static bool enableR = true;
        private static int minimumDistance = 2000;
        private static int[] AssasinateDmg = new int[3] { 220, 385, 550 };

        static void Main(string[] args)
        {
            Menu.AddItem(new MenuItem("toggle", "Enabled").SetValue(true));
            Menu.AddToMainMenu();
            Game.OnUpdate += Game_OnUpdate;
            Console.WriteLine("Sniper#!");

        }

            public static void Game_OnUpdate(EventArgs args)
        {
            me = ObjectManager.LocalHero;

            if (me.ClassID != ClassID.CDOTA_Unit_Hero_Sniper)
                return;
            if (me == null)
                return;

            if (Assasinate == null)
                Assasinate = me.Spellbook.Spell4;

            if (target != null && Assasinate.CanBeCasted() && me.IsAlive && target.IsAlive);

            {
                if (Assasinate != null && me.Distance2D(target) > 2000 && me.Distance2D(target) < Assasinate.CastRange && Assasinate.CanBeCasted() && me.Health > 250);
            }

            {
                Assasinate.UseAbility(target.Position);
            }

        }

    }

}
