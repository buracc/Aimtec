using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Config;
using Aimtec.SDK.Orbwalking;
using Aimtec.SDK.TargetSelector;

namespace Sivir
{
    internal partial class Sivir
    {
        public Sivir()
        {
            this.InitMethods();
            this.InitSpells();
            this.InitMenus();
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
                     
                     if (target != null && target.IsValidTarget())
                     {
                         Q.Cast(target);
                     }
                     break;
            }
            
        }
    }
}