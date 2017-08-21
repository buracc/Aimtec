using System.Linq;
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Util.Cache;

namespace Template
{
    internal partial class Template
    {

        public void LaneClear()
        {
            bool spells = Menu["misc"]["spells"].Enabled;

            foreach (var minion in GetEnemyLaneMinionsTargetsInRange(1500))
            {
                if (minion != null && spells)
                {
                   
                }
            }
        }

        public void Harass()
        {
            target = GetBestEnemyHeroTargetInRange(1500);

            if (target == null)
            {
                return;
            }

        }

        public void Combo()
        {
            target = GetBestEnemyHeroTargetInRange(1500);

            if (target == null)
            {
                return;
            }
            
        }

        public void LastHit()
        {
            bool spells = Menu["misc"]["spells"].Enabled;

            foreach (var minion in GetEnemyLaneMinionsTargetsInRange(1500))
            {
                if (minion != null && spells)
                {

                }
            }
        }
       
    }
}