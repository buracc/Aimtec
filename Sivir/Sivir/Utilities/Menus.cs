using Aimtec.SDK.Menu;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Orbwalking;
using Aimtec.SDK.Util;
using Aimtec.SDK.Util.Cache;


namespace Sivir
{
    internal partial class Sivir
    {
        public static Menu Menu = new Menu("Sivir", "Sivir", true);

        public void InitMenus()
        {
            Orbwalker.Implementation.Attach(Menu);
            
            var QMenu = new Menu("q", "Q");
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

            var WMenu = new Menu("w", "W");
            {
                WMenu.Add(new MenuBool("combow", "AA cancel with W in combo"));
                WMenu.Add(new MenuBool("lanew", "Lane clear with W"));
                WMenu.Add(new MenuBool("haraw", "Harass with W"));
            }

            Menu.Add(WMenu);

            var EMenu = new Menu("e", "E");
            {
                EMenu.Add(new MenuSeperator("soontm", "Will be made by Laura"));
            }
            Menu.Add(EMenu);

            var MiscMenu = new Menu("misc", "Misc");
            {
                MiscMenu.Add(new MenuKeyBind("spells", "Spells farm toggle", KeyCode.M, KeybindType.Toggle));
            }
            Menu.Add(MiscMenu);

            /*var LastHit = new Menu("last", "Last hitting");
            {
                LastHit.Add(new MenuBool("usew", "Use W to last hit"));
            }
            Menu.Add(LastHit);*/
            
            var DrawMenu = new Menu("drawings", "Drawings");
            {
                DrawMenu.Add(new MenuBool("drawq", "Draw Q range"));
                DrawMenu.Add(new MenuBool("draws", "Display spell farm status"));
            }
            Menu.Add(DrawMenu);
            
            Menu.Add(new MenuSeperator("text1", "Use Eluder/ZZephyr for spellshield usage."));
            Menu.Add(new MenuSeperator("text2", "Use R manually for best results."));

            Menu.Attach();

        }
    }
}