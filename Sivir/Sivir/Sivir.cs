using System;
using Aimtec;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Menu.Config;
using Aimtec.SDK.TargetSelector;
using System.Linq;

namespace Sivir
{
    internal partial class Sivir
    {
        public Sivir()
        {
            InitMenus();
            InitSpells();
            InitMethods();
        }

        public void OnTick()
        {
            target = TargetSelector.GetTarget(1500);

            if (GlobalKeys.ComboKey.Active)
            {
                Combo();
            }

            if (GlobalKeys.WaveClearKey.Active)
            {
                //lane clear logic
            }

            if (GlobalKeys.LastHitKey.Active)
            {
                //last hit logic
            }

            if (GlobalKeys.MixedKey.Active)
            {
                //harass logic
            }
        }

        public void OnDraws()
        {
            if (Player.IsDead)
            {
                return;
            }
            InitDrawings();
        }
    }
}