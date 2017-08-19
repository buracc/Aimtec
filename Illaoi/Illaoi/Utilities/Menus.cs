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
                QMenu.Add(new MenuBool("haraq", "Harass with Q"));

                QMenu.Add(new MenuSeperator("sep1", "Auto Q config: "));
                QMenu.Add(new MenuBool("qks", "Auto Q if killable enemy in range"));
                QMenu.Add(new MenuBool("qcc", "Auto Q if enemy immobile"));
                QMenu.Add(new MenuBool("qslow", "Auto Q if enemy slowed"));

                var QWhiteList = new Menu("qwl", "Auto Q on CC whitelist");
                {

                    foreach (var target in GameObjects.EnemyHeroes)
                    {
                        QWhiteList.Add(
                            new MenuBool(target.ChampionName.ToLower(), "Auto Q: " + target.ChampionName));
                    }
                }
                QMenu.Add(QWhiteList);
            }
            Menu.Add(QMenu);

            WMenu = new Menu("w", "W");
            {
                WMenu.Add(new MenuBool("combow", "AA cancel with W in combo"));
                WMenu.Add(new MenuBool("lanew", "Lane clear with W"));
                WMenu.Add(new MenuBool("haraw", "Harass with W"));
            }
            Menu.Add(WMenu);

            EMenu = new Menu("e", "E");
            {
                EMenu.Add(new MenuBool("comboe", "Use E in combo"));
                EMenu.Add(new MenuSeperator("sep2", "More E logic coming soon"));
            }
            Menu.Add(EMenu);

            RMenu = new Menu("r", "R");
            {
                RMenu.Add(new MenuBool("combor", "Use R in combo"));
                RMenu.Add(new MenuSliderBool("rcount", "R if >= x enemies", true, 3, 1, 5));
            }
            Menu.Add(RMenu);

            MiscMenu = new Menu("misc", "Misc");
            {
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

            Menu.Add(new MenuSeperator("sep3", "Work in progress"));
            Menu.Add(new MenuSeperator("sep4", "Made by Burak"));

            Menu.Attach();
        }
    }
}



