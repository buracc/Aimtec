using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                ComboMenu.Add(new MenuBool("useq", "Use Q"));
                ComboMenu.Add(new MenuBool("usew", "Use W to cancel AA"));
                ComboMenu.Add(new MenuSeperator("na", "E not implemented yet."));
            }

            Menu.Add(ComboMenu);

            var HarassMenu = new Menu("harass", "Harass");
            {
                HarassMenu.Add(new MenuBool("useq", "Use Q to Harass"));
                HarassMenu.Add(new MenuBool("usew", "Use W to Harass"));
            }

            Menu.Add(HarassMenu);

            var LaneClear = new Menu("lane", "Lane Clear");
            {
                LaneClear.Add(new MenuBool("useq", "Use Q to Lane Clear"));
                LaneClear.Add(new MenuBool("usew", "Use W to Lane Clear"));
            }
            Menu.Add(LaneClear);

            var DrawMenu = new Menu("drawings", "Drawings");
            {
                DrawMenu.Add(new MenuBool("drawq", "Draw Q Range"));
            }
            Menu.Add(DrawMenu);
            Menu.Attach();


        }
    }
}