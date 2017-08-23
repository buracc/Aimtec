using System.Drawing;
using Aimtec;

namespace Hecarim
{

    internal partial class Hecarim
    {
        public void InitDrawings()
        {
            Vector2 a;
            var pos = Render.WorldToScreen(Player.Position, out a);
            var xaOffset = (int)a.X;
            var yaOffset = (int)a.Y;

            if (Menu["drawings"]["drawq"].Enabled)
            {
                Render.Circle(Player.Position, Q.Range, 50, Color.Aqua);
            }

            if (Menu["drawings"]["draww"].Enabled)
            {
                Render.Circle(Player.Position, W.Range, 50, Color.Magenta);
            }

            if (Menu["drawings"]["drawr"].Enabled)
            {
                Render.Circle(Player.Position, E.Range, 50, Color.Crimson);
            }

            if (Menu["drawings"]["draws"].Enabled)
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