using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Config;
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

            if (GlobalKeys.ComboKey.Active)
            {
                target = TargetSelector.GetTarget(1500);
                if (target != null && target.IsValidTarget(1500))
                {
                    Q.Cast(target);
                }
            }
        }
    }
}