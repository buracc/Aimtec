using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aimtec;

namespace Illaoi
{
    internal partial class Illaoi
    {
        private void InitMethods()
        {
            Game.OnUpdate += OnUpdate;
            Render.OnPresent += OnDrawings;
        }
    }
}
