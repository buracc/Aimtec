using System;
using System.Linq;
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Orbwalking;
using Aimtec.SDK.Util.Cache;

namespace Karma
{
    internal partial class Karma
    {
        public void LaneClear()
        {
            bool useQ = Menu["q"]["laneq"].Enabled;
            bool spells = Menu["misc"]["spells"].Enabled;

            foreach (var minion in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(Q.Range)))
            {
                if (minion != null && spells)
                {
                    if (Q.Ready && useQ)
                    {
                        CastQ(minion);
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
            bool useRQ = Menu["r"]["hararq"].Enabled;
            bool useRW = Menu["r"]["combrw"].Enabled;
            bool smartE = Menu["e"]["smarte"].Enabled;
            int smartRange = Menu["e"]["smarte"].Value;
            int wHP = Menu["r"]["combrw"].As<MenuSliderBool>().Value;

            if (target != null)
            {
                if (useRW && Player.HealthPercent() <= wHP && Player.Distance(target) <= W.Range)
                {
                    CastR();
                    if (Player.HasBuff("KarmaMantra") && W.Ready)
                    {
                        CastW(target);
                    }
                }

                if (W.Ready && useW && !Player.HasBuff("KarmaMantra"))
                {
                    CastW(target);
                    if (E.Ready && smartE)
                    {
                        if (Player.Distance(target) >= smartRange)
                        {
                            CastE(Player);
                        }
                    }
                }

                if (Q.Ready && useQ)
                {
                    if (Player.Distance(target) <= Q.Range)
                    {
                        if (useRQ)
                        {
                            CastR();
                            if (Player.HasBuff("KarmaMantra") && Q.Ready)
                            {
                                CastQ(target);
                            }
                        }
                        CastQ(target);
                    }
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
            bool useRQ = Menu["r"]["combrq"].Enabled;
            bool useRW = Menu["r"]["combrw"].Enabled;
            bool smartE = Menu["e"]["smarte"].Enabled;
            int smartRange = Menu["e"]["smarte"].Value;
            int wHP = Menu["r"]["combrw"].As<MenuSliderBool>().Value;

            if (target != null)
            {
                if (useRW && Player.HealthPercent() <= wHP && Player.Distance(target) <= W.Range)
                {
                    CastR();
                    if (Player.HasBuff("KarmaMantra") && W.Ready)
                    {
                        CastW(target);
                    }
                }

                else if (!Q.Ready && W.Ready && useW && !Player.HasBuff("KarmaMantra"))
                {
                    CastW(target);
                    if (E.Ready && smartE)
                    {
                        if (Player.Distance(target) >= smartRange)
                        {
                            CastE(Player);
                        }
                    }
                }

                if (Q.Ready && useQ)
                {
                    if (Player.Distance(target) <= Q.Range)
                    {
                        if (useRQ)
                        {
                            CastR();
                            if (Player.HasBuff("KarmaMantra") && Q.Ready)
                            {
                                CastQ(target);
                            }
                        }
                        CastQ(target);
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
    
        public void ManualE()
        {
            bool eSelf = Menu["misc"]["eself"].Enabled;

            if (eSelf && R.Ready && E.Ready)
            {
                CastR();
                CastE(Player);
            }
        }
    }
}
