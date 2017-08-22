using System;
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Orbwalking;
using Aimtec.SDK.Util.Cache;

namespace Karthus
{
    internal partial class Karthus
    {
        public Karthus()
        {
            InitMethods();
            InitSpells();
            InitMenus();
        }

        private void Game_OnUpdate()
        {
            if (Player.IsDead && !Player.HasBuff("KarthusDeathDefiedBuff"))
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
            AutoR();
        }

        private void OnDrawings()
        {
            if (Player.IsDead && !Player.HasBuff("KarthusDeathDefiedBuff"))
            {
                return;
            }
            InitDrawings();
        }
    }
}