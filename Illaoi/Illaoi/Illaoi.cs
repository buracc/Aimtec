using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using Aimtec;
using Aimtec.SDK.Orbwalking;

namespace Illaoi
{
    internal partial class Illaoi
    {
        public Illaoi()
        {
            InitMethods();
            InitSpells();
            InitMenus();
        }

        private void OnUpdate()
        {
            if (Player.IsDead)
            {
                return;
            }

            switch (Orbwalker.Implementation.Mode)
            {
                case OrbwalkingMode.Combo:
                    Combo();
                    break;
                case OrbwalkingMode.Mixed:
                    Harass();
                    break;
                case OrbwalkingMode.Lasthit:
                    LastHit();
                    break;
                case OrbwalkingMode.Laneclear:
                    LaneClear();
                    break;
            }
            AutoQ();
        }

        private void OnDrawings()
        {
            if (Player.IsDead)
            {
                return;
            }
            InitDrawings();
        }
    }
}

