using System.Drawing;
using Aimtec;

namespace Malzahar
{

    internal partial class Malzahar
    {
        public void InitDrawings()
        {
            Vector2 a;
            var pos = Render.WorldToScreen(Player.Position, out a);
            var xaOffset = (int)a.X;
            var yaOffset = (int)a.Y;


            if (Menu["drawings"]["drawq"].Enabled)
            {
                Render.Circle(Player.Position, Q.Range, 50, Color.Chartreuse);
            }

            if (Menu["drawings"]["drawe"].Enabled)
            {
                Render.Circle(Player.Position, E.Range, 50, Color.BlueViolet);
            }

            if (Menu["drawings"]["drawr"].Enabled)
            {
                Render.Circle(Player.Position, R.Range, 50, Color.DarkRed);
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