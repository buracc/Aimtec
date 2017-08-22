using System.Drawing;
using Aimtec;

namespace Karthus
{
    internal partial class Karthus
    {
        public void InitDrawings()
        {
            
            Vector2 a;
            var pos = Render.WorldToScreen(Player.Position, out a);
            var x = (int)a.X;
            var y = (int)a.Y;


            if (Menu["drawings"]["drawq"].Enabled)
            {
                Render.Circle(Player.Position, Q.Range, 50, Color.Aqua);
            }

            if (Menu["drawings"]["draww"].Enabled)
            {
                Render.Circle(Player.Position, W.Range, 50, Color.Crimson);
            }

            if (Menu["drawings"]["drawe"].Enabled)
            {
                Render.Circle(Player.Position, E.Range, 50, Color.DarkMagenta);
            }
            

            if (Menu["drawings"]["draws"].Enabled)
            {
                string on = "Spell Farm: ON";
                string off = "Spell Farm: OFF";

                if (!Menu["misc"]["spells"].Enabled)
                {
                    Render.Text(x - 50, y + 50, Color.Orange, off);
                }
                else
                {
                    Render.Text(x - 50, y + 50, Color.Orange, on);
                }
            }
            
            if (Menu["r"]["rmode"].Value == 1 && killableTargBool && R.Ready)
            {
                Render.Text(x - 50, y - 150, Color.Red, killableTarg + " KILLABLE WITH R");
            }
        }
    }
}