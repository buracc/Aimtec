using Aimtec.SDK.Menu;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Orbwalking;
using Aimtec.SDK.Util;
using Aimtec.SDK.Util.Cache;

namespace Illaoi
{
    internal partial class Illaoi
    {
        private static Menu Menu;
        public static Menu QMenu, WMenu, EMenu, RMenu, MiscMenu, DrawMenu;

        public void InitMenus()
        {
            Menu = new Menu("Illaoi", "Illaoi", true);
            Orbwalker.Implementation.Attach(Menu);

            QMenu = new Menu("q", "Q");
            {
                QMenu.Add(new MenuBool("comboq", "Use Q in combo"));
                QMenu.Add(new MenuBool("laneq", "Lane clear with Q"));
                QMenu.Add(new MenuBool("harassq", "Harass with Q"));
                
            }
            Menu.Add(QMenu);

            WMenu = new Menu("w", "W");
            {
                WMenu.Add(new MenuBool("combow", "AA with W in combo"));
                WMenu.Add(new MenuBool("lanew", "Lane clear with W"));
                WMenu.Add(new MenuBool("lastw", "Last hit with W"));
                WMenu.Add(new MenuBool("harassw", "Harass with W"));
            }
            Menu.Add(WMenu);

            EMenu = new Menu("e", "E");
            {
                EMenu.Add(new MenuBool("comboe", "Use E in combo"));
                EMenu.Add(new MenuBool("harasse", "Harass with E"));
                EMenu.Add(new MenuList("emode", "Spirit attack preference:", new []{"Spirit if enemy out of range", "Always spirit", "Always enemy"}, 0));
            }
            Menu.Add(EMenu);

            RMenu = new Menu("r", "R");
            {
                RMenu.Add(new MenuBool("combor", "Use R in combo"));
                RMenu.Add(new MenuSliderBool("rcount", "Only R if >= x enemies", true, 3, 1, 5));
                RMenu.Add(new MenuBool("addspirit", "Include spirit in enemies count?"));
            }
            Menu.Add(RMenu);

            MiscMenu = new Menu("misc", "Misc");
            {
                MiscMenu.Add(new MenuBool("blockq", "Block Q usage while ulted"));
                MiscMenu.Add(new MenuBool("blocke", "Block E usage while ulted"));
                MiscMenu.Add(new MenuKeyBind("spells", "Spells farm toggle", KeyCode.M, KeybindType.Toggle));
            }
            Menu.Add(MiscMenu);

            DrawMenu = new Menu("draws", "Drawings");
            {
                DrawMenu.Add(new MenuBool("drawq", "Draw Q range"));
                DrawMenu.Add(new MenuBool("draww", "Draw W range"));
                DrawMenu.Add(new MenuBool("drawe", "Draw E range"));
                DrawMenu.Add(new MenuBool("drawr", "Draw R range"));
                DrawMenu.Add(new MenuBool("draws", "Display spell farm status"));
            }
            Menu.Add(DrawMenu);
            
            Menu.Add(new MenuSeperator("sep2", "Made by Burak"));

            Menu.Attach();
        }
    }
}



