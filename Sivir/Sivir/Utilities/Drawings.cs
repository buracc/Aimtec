using Aimtec.SDK.Menu.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aimtec;

namespace Sivir
{

    internal partial class Sivir
    {
        public void InitDrawings()
        {
            if (Menu["drawings"]["drawq"].As<MenuBool>().Enabled && Q.Ready)
            {
                Render.Circle(Player.Position, Q.Range, 30, Color.LightGreen);
            }
        }
    }
}
