using Aimtec.SDK.Menu;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Orbwalking;
using Aimtec.SDK.Util;
using Aimtec.SDK.Util.Cache;


namespace Karthus
{
    internal partial class Karthus
    {
        private static Menu Menu = new Menu("Karthus", "Karthus", true);

        public void InitMenus()
        {
            Orbwalker.Implementation.Attach(Menu);

            var QMenu = new Menu("q", "Q");
            {
                QMenu.Add(new MenuBool("comboq", "Use Q in combo"));
                QMenu.Add(new MenuBool("laneq", "Use Q to laneclear"));
                QMenu.Add(new MenuBool("harassq", "Use Q to harass"));
                QMenu.Add(new MenuBool("lastq", "Use Q to last hit"));
            }
            Menu.Add(QMenu);

            var WMenu = new Menu("w", "W");
            {
                WMenu.Add(new MenuBool("combow", "Use W in combo"));
                WMenu.Add(new MenuBool("harassw", "Use W to harass"));
            }
            Menu.Add(WMenu);

            var EMenu = new Menu("e", "E");
            {
                EMenu.Add(new MenuBool("comboe", "Use E in combo"));
                EMenu.Add(new MenuBool("lanee", "Use E to laneclear"));
                EMenu.Add(new MenuBool("harasse", "Use E to harass"));
                EMenu.Add(new MenuList("emode", "E laneclear mode: ", new[] {"Keep on", "Only lasthits"}, 0));
            }
            Menu.Add(EMenu);

            var RMenu = new Menu("r", "R");
            {
                RMenu.Add(new MenuBool("user", "Enable auto R"));
                RMenu.Add(new MenuBool("deadr", "Auto R only when dead"));
                RMenu.Add(new MenuList("rmode", "R mode: ", new[] { "Auto R", "Notify" }, 1));
            }
            Menu.Add(RMenu);

            var MiscMenu = new Menu("misc", "Misc");
            {
                MiscMenu.Add(new MenuKeyBind("spells", "Spells farm toggle", KeyCode.M, KeybindType.Toggle));
            }
            Menu.Add(MiscMenu);
            
            var DrawMenu = new Menu("drawings", "Drawings");
            {
                DrawMenu.Add(new MenuBool("drawq", "Draw Q range"));
                DrawMenu.Add(new MenuBool("draww", "Draw W range"));
                DrawMenu.Add(new MenuBool("drawe", "Draw E range"));
                DrawMenu.Add(new MenuBool("draws", "Display spell farm status"));
            }
            Menu.Add(DrawMenu);

            Menu.Add(new MenuSeperator("sep2", "Made by Burak"));

            Menu.Attach();

        }
    }
}