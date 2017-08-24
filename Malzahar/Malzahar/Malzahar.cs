using System;
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Orbwalking;

namespace Malzahar
{
    internal partial class Malzahar
    {
        public Malzahar()
        {
            InitMethods();
            InitSpells();
            InitMenus();
        }

        private void Game_OnUpdate()
        {
            if (Player.IsDead)
            {
                return;
            }

            if (Player.HasBuff("malzaharrsound"))
            {
                Orbwalker.Implementation.AttackingEnabled = false;
                Orbwalker.Implementation.MovingEnabled = false;
            }
            else
            {
                Orbwalker.Implementation.AttackingEnabled = true;
                Orbwalker.Implementation.MovingEnabled = true;
            }

            switch (Orbwalker.Implementation.Mode)
            {
                case OrbwalkingMode.Combo:
                    Combo();
                    break;
                case OrbwalkingMode.Mixed:
                    Harass();
                    break;
                case OrbwalkingMode.Laneclear:
                    LaneClear();
                    break;
            }
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