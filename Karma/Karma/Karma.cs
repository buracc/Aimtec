using Aimtec.SDK.Orbwalking;

namespace Karma
{
    internal partial class Karma
    {
        public Karma()
        {
            InitMethods();
            InitSpells();
            InitMenus();
        }

        public void Game_OnUpdate()
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
            AutoQ();
            ManualE();
        }

        public void OnDrawings()
        {
            if (Player.IsDead)
            {
                return;
            }
            InitDrawings();
        }
        
    }
}
