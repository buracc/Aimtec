using Aimtec.SDK.Menu;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Orbwalking;
using Aimtec.SDK.Util;
using Aimtec.SDK.Util.Cache;


namespace Karma
{
    internal partial class Karma
    {
        public static Menu Menu = new Menu("Karma", "Karma", true);

        public void InitMenus()
        {
            Orbwalker.Implementation.Attach(Menu);
            
            var QMenu = new Menu("q", "Q");
            {
                QMenu.Add(new MenuBool("comboq", "Use Q in combo"));
                QMenu.Add(new MenuBool("laneq", "Lane clear with Q"));
                QMenu.Add(new MenuBool("haraq", "Harass with Q"));

                QMenu.Add(new MenuSeperator("text1", "Auto Q config: "));
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

            var WMenu = new Menu("w", "W");
            {
                WMenu.Add(new MenuBool("combow", "Use W in combo"));
                WMenu.Add(new MenuBool("haraw", "Harass with W"));
            }

            Menu.Add(WMenu);

            var EMenu = new Menu("e", "E");
            {
                EMenu.Add(new MenuSeperator("agre", "Aggressive E settings: "));
                EMenu.Add(new MenuSliderBool("smarte", "Cast E if target range >= x", true, 700, 100, 900));

                EMenu.Add(new MenuSeperator("defe", "Defensive E settings:"));
                EMenu.Add(new MenuSeperator("soontm", "Defensive shield logic SoonTM"));
            }
            Menu.Add(EMenu);

            var RMenu = new Menu("r", "R");
            {
                RMenu.Add(new MenuBool("combrq", "Empower Q in combo"));
                RMenu.Add(new MenuBool("hararq", "Empower Q to harass"));
                RMenu.Add(new MenuSliderBool("combrw", "Empower W if HP lower than", true, 30, 10, 100));
            }
            Menu.Add(RMenu);

            var MiscMenu = new Menu("misc", "Misc");
            {
                MiscMenu.Add(new MenuKeyBind("spells", "Spells farm toggle", KeyCode.M, KeybindType.Toggle));
                MiscMenu.Add(new MenuKeyBind("eself", "Empower E on self", KeyCode.A, KeybindType.Press));
            }
            Menu.Add(MiscMenu);
            
            var DrawMenu = new Menu("drawings", "Drawings");
            {
                DrawMenu.Add(new MenuBool("drawq", "Draw Q range"));
                DrawMenu.Add(new MenuBool("draww", "Draw W range"));
                DrawMenu.Add(new MenuBool("draws", "Display spell farm status"));
            }
            Menu.Add(DrawMenu);
            
            Menu.Add(new MenuSeperator("text3", "Made by Burak"));

            Menu.Attach();

        }
    }
}
