using System.Linq;
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Util.Cache;

namespace Sivir
{
    internal partial class Sivir
    {
        
        public void LaneClear()
        {
            bool useQ = Menu["q"]["laneq"].Enabled;
            bool useW = Menu["w"]["lanew"].Enabled;
            bool spells = Menu["misc"]["spells"].Enabled;

            foreach (var minion in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(Q.Range)))
            {
                if (minion != null && spells)
                {
                    if (Q.Ready && useQ)
                    {
                        CastQ(minion);
                    }

                    if (W.Ready && useW)
                    {
                        CastW(minion);
                    }
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

            bool useQ = Menu["q"]["haraq"].Enabled;
            bool useW = Menu["w"]["haraw"].Enabled;

            if (target != null)
            {
                if (Q.Ready && useQ)
                {
                    CastQ(target);
                }

                if (W.Ready && useW)
                {
                    CastW(target);
                }
            }
        }
        
        public void Combo()
        {
            target = GetBestEnemyHeroTargetInRange(1500);

            if (target == null)
            {
                return;
            }

            bool useQ = Menu["q"]["comboq"].Enabled;
            bool useW = Menu["w"]["combow"].Enabled;

            if (target != null)
            {
                if (Q.Ready && useQ)
                {
                    CastQ(target);
                }

                if (W.Ready && useW)
                {
                    CastW(target);
                }
            }
        }

        /*public void LastHit()
        {
            bool useW = Menu["last"]["usew"].Enabled;

            foreach (var minion in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(Q.Range)))
            {
                if (minion != null)
                {
                    double dmg = Player.GetSpellDamage(minion, SpellSlot.W);
                    if (W.Ready && useW && dmg > minion.Health)
                    {
                        CastW(minion);
                    }
                }
            }
        }*/

        public void AutoQ()
        {
            target = GetBestEnemyHeroTargetInRange(1500);
            
            if (target == null)
            {
                return;
            }

            bool ksQ = Menu["q"]["qks"].Enabled;
            bool ccQ = Menu["q"]["qcc"].Enabled;
            bool slowQ = Menu["q"]["qslow"].Enabled;
            bool wlQ = Menu["qwl"][target.ChampionName.ToLower()].Enabled;
            
            if (target != null)
            {
                double dmg = Player.GetSpellDamage(target, SpellSlot.Q);
                if (Q.Ready && ksQ && target.Health <= dmg)
                {
                    CastQ(target);
                }

                if (Q.Ready && ccQ && wlQ)
                {
                    if (target.HasBuffOfType(BuffType.Snare) || target.HasBuffOfType(BuffType.Stun))
                    {
                        CastQ(target);
                    }
                }

                if (Q.Ready && slowQ && wlQ)
                {
                    if (target.HasBuffOfType(BuffType.Slow))
                    {
                        CastQSlow(target);
                    }
                }
            }
        }
    }
}   