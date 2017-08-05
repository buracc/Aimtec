using System.Drawing;
using Aimtec;

namespace Sivir
{

    internal partial class Sivir
    {
        public void InitDrawings()
        {
            if (Menu["drawings"]["drawq"].Enabled && Q.Ready)
            {
                Render.Circle(Player.Position, Q.Range, 50, Color.Chartreuse);
            }
        }
    }
}
