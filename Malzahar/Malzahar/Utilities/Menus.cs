using Aimtec.SDK.Menu;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Orbwalking;
using Aimtec.SDK.Util;
using Aimtec.SDK.Util.Cache;


namespace Malzahar
{
    internal partial class Malzahar
    {
        public static Menu Menu = new Menu("Malzahar", "Malzahar", true);

        public void InitMenus()
        {
            Orbwalker.Implementation.Attach(Menu);

            var QMenu = new Menu("q", "Q");
            {
                QMenu.Add(new MenuBool("comboq", "Use Q in combo"));
                QMenu.Add(new MenuBool("harassq", "Use Q to harass"));
                QMenu.Add(new MenuBool("laneq", "Use Q to lane clear"));
            }

            Menu.Add(QMenu);

            var WMenu = new Menu("w", "W");
            {
                WMenu.Add(new MenuBool("combow", "Use W in combo"));
                WMenu.Add(new MenuBool("harassw", "Use W to harass"));
                WMenu.Add(new MenuBool("lanew", "Use W to lane clear"));
            }

            Menu.Add(WMenu);

            var EMenu = new Menu("e", "E");
            {
                EMenu.Add(new MenuBool("comboe", "Use E in combo"));
                EMenu.Add(new MenuBool("harasse", "Use E to harass"));
                EMenu.Add(new MenuBool("lanee", "Use E to lane clear"));
                EMenu.Add(new MenuBool("laste", "Only E if can kill"));
            }
            Menu.Add(EMenu);

            var RMenu = new Menu("r", "R");
            {
                RMenu.Add(new MenuBool("combor", "Use R in combo"));
                var RWhiteList = new Menu("rwl", "R Whitelist");
                {
                    foreach (var target in GameObjects.EnemyHeroes)
                    {
                        RWhiteList.Add(
                            new MenuBool(target.ChampionName.ToLower(), "Use R: " + target.ChampionName));
                    }
                }
                RMenu.Add(RWhiteList);
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