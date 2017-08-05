using Aimtec.SDK.Menu;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Orbwalking;


namespace Sivir
{
    internal partial class Sivir
    {
        public static Menu Menu = new Menu("Sivir", "Sivir", true);

        public void InitMenus()
        {
            Orbwalker.Implementation.Attach(Menu);
            
            var ComboMenu = new Menu("combo", "Combo");
            {
                ComboMenu.Add(new MenuBool("useq", "Use Q in combo"));
                ComboMenu.Add(new MenuBool("usew", "AA cancel with W in combo"));
            }

            Menu.Add(ComboMenu);

            var HarassMenu = new Menu("harass", "Harass");
            {
                HarassMenu.Add(new MenuBool("useq", "Harass with Q"));
                HarassMenu.Add(new MenuBool("usew", "Harass with W"));
            }

            Menu.Add(HarassMenu);

            var LaneClear = new Menu("lane", "Lane clear");
            {
                LaneClear.Add(new MenuBool("useq", "Lane clear with Q"));
                LaneClear.Add(new MenuBool("usew", "Lane clear with W"));
            }
            Menu.Add(LaneClear);

            var LastHit = new Menu("last", "Last hitting");
            {
                LastHit.Add(new MenuBool("usew", "Use W to last hit"));
            }

            var Misc = new Menu("misc", "Misc.");
            {
                Misc.Add(new MenuBool("qks", "Auto Q if killable enemy in range"));
                Misc.Add(new MenuBool("qcc", "Auto Q if enemy immobile"));
            }
            Menu.Add(Misc);

            Menu.Add(LastHit);
            var DrawMenu = new Menu("drawings", "Drawings");
            {
                DrawMenu.Add(new MenuBool("drawq", "Draw Q range"));
            }
            Menu.Add(DrawMenu);

            Menu.Add(new MenuSeperator("text1", "Use Eluder for spellshield usage."));
            Menu.Add(new MenuSeperator("text2", "Use R manually for best results."));

            Menu.Attach();

        }
    }
}