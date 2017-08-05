using System.Linq;
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.TargetSelector;

namespace Sivir
{
    internal partial class Sivir
    {
        public static Obj_AI_Hero Player => ObjectManager.GetLocalPlayer();
        public Obj_AI_Hero target;

        public static Obj_AI_Hero GetBestEnemyHeroTarget()
        {
            return GetBestEnemyHeroTargetInRange(float.MaxValue);
        }

        public static Obj_AI_Hero GetBestEnemyHeroTargetInRange(float range)
        {
            var ts = TargetSelector.Implementation;
            var target = ts.GetTarget(range);
            if (target != null && target.IsValidTarget())
            {
                return target;
            }

            var firstTarget = ts.GetOrderedTargets(range)
                .FirstOrDefault(t => t.IsValidTarget());
            if (firstTarget != null)
            {
                return firstTarget;
            }

            return null;
        }

    }
}
