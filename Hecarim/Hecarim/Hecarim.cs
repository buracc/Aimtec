using Aimtec.SDK.Orbwalking;

namespace Hecarim
{
    internal partial class Hecarim
    {
        public Hecarim()
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