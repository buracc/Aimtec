using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Util.Cache;

namespace Illaoi
{
    internal partial class Illaoi
    {
        public void Combo()
        {
            target = GetBestEnemyHeroTargetInRange(1500);

            if (target == null)
            {
                return;
            }

            bool useQ = Menu["q"]["comboq"].Enabled;
            bool useW = Menu["w"]["combow"].Enabled;
            bool useE = Menu["e"]["comboe"].Enabled;
            bool useR = Menu["r"]["combor"].Enabled;
            bool countR = Menu["r"]["rcount"].Enabled;
            int minR = Menu["r"]["rcount"].Value;

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

                if (E.Ready && useE)
                {
                    CastE(target);
                }

                if (R.Ready && useR && !countR)
                {
                    CastR(target);
                }

                if (R.Ready && useR && countR)
                {
                    if (minR >= Player.CountEnemyHeroesInRange(R.Range))
                    {
                        CastR(target);
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

        private void LastHit()
        {
            //last hit logic
        }

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
