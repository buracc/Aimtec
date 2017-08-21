using Aimtec.SDK.Menu;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Orbwalking;
using Aimtec.SDK.Util;
using Aimtec.SDK.Util.Cache;


namespace Template
{
    internal partial class Template
    {
        public static Menu Menu = new Menu("xx", "xx", true);

        public void InitMenus()
        {
            Orbwalker.Implementation.Attach(Menu);

            var QMenu = new Menu("q", "Q");
            {
                
            }

            Menu.Add(QMenu);

            var WMenu = new Menu("w", "W");
            {
                
            }

            Menu.Add(WMenu);

            var EMenu = new Menu("e", "E");
            {
                
            }
            Menu.Add(EMenu);

            var RMenu = new Menu("r", "R");
            {

            }
            Menu.Add(RMenu);

            var MiscMenu = new Menu("misc", "Misc");
            {
                MiscMenu.Add(new MenuKeyBind("spells", "Spells farm toggle", KeyCode.M, KeybindType.Toggle));
            }
            Menu.Add(MiscMenu);
            
            var DrawMenu = new Menu("drawings", "Drawings");
            {
                DrawMenu.Add(new MenuBool("draws", "Display spell farm status"));
            }
            Menu.Add(DrawMenu);
            
            Menu.Add(new MenuSeperator("sep2", "Made by Burak"));

            Menu.Attach();

        }
    }
}