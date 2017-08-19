using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aimtec;

namespace Illaoi
{
    internal partial class Illaoi
    {
        public void InitDrawings()
        {
            Vector2 a;
            var pos = Render.WorldToScreen(Player.Position, out a);
            var xaOffset = (int)a.X;
            var yaOffset = (int)a.Y;

            if (Menu["draws"]["drawq"].Enabled && Q.Ready)
            {
                Render.Circle(Player.Position, Q.Range, 50, Color.Chartreuse);
            }

            if (Menu["draws"]["draww"].Enabled && W.Ready)
            {
                Render.Circle(Player.Position, W.Range, 50, Color.Chocolate);
            }

            if (Menu["draws"]["drawe"].Enabled && E.Ready)
            {
                Render.Circle(Player.Position, E.Range, 50, Color.BlueViolet);
            }

            if (Menu["draws"]["drawr"].Enabled && R.Ready)
            {
                Render.Circle(Player.Position, R.Range, 50, Color.DarkRed);
            }

            if (Menu["draws"]["draws"].Enabled)
            {
                string on = "Spell Farm: ON";
                string off = "Spell Farm: OFF";

                if (!Menu["misc"]["spells"].Enabled)
                {
                    Render.Text(xaOffset - 50, yaOffset + 50, Color.Orange, off);
                }
                else
                {
                    Render.Text(xaOffset - 50, yaOffset + 50, Color.Orange, on);
                }
            }
        }
    }
}
