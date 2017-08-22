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
            bool blockQ = Menu["r"]["blockq"].Enabled;
            bool blockE = Menu["r"]["blocke"].Enabled;
            bool countR = Menu["r"]["rcount"].Enabled;
            bool countSpirit = Menu["r"]["addspirit"].Enabled;
            int minR = Menu["r"]["rcount"].Value;

            bool pulled = false;
            bool hitSpirit = false;
            

            if (target != null)
            {
                foreach (var spirit in GetEnemyLaneMinionsTargetsInRange(Q.Range))
                {
                    if (spirit.UnitSkinName == target.UnitSkinName)
                    {
                        pulled = true;
                        switch (Menu["e"]["emode"].Value)
                        {
                            case 0:
                                if (Player.Distance(target) > (Q.Range + W.Range) && Player.Distance(spirit) < Q.Range)
                                {
                                    hitSpirit = true;
                                }
                                break;
                            case 1:
                                hitSpirit = true;
                                break;
                            case 2:
                                hitSpirit = false;
                                break;
                        }
                    }
                }

                if (R.Ready && useR && !countR && Player.Distance(target) < R.Range)
                {
                    CastR(target);
                }

                if (R.Ready && useR && countR && Player.Distance(target) < R.Range)
                {
                    if (countSpirit)
                    {
                        if (pulled)
                        {
                            if (minR >= Player.CountEnemyHeroesInRange(R.Range) + 1)
                            {
                                CastR(target);
                            }
                        } 
                    }

                    if (minR >= Player.CountEnemyHeroesInRange(R.Range))
                    {
                        CastR(target);
                    }
                }

                if (E.Ready && useE && Player.Distance(target) < E.Range)
                {
                    if (Player.HasBuff("IllaoiR"))
                    {
                        if (blockE)
                        {
                            return;
                        }
                    }

                    if (!Player.HasBuff("IllaoiR"))
                    {
                        CastE(target);
                    }
                }

                if (W.Ready && useW && Player.Distance(target) < W.Range)
                {
                    if (hitSpirit)
                    {
                        foreach (var spirit in GetEnemyLaneMinionsTargetsInRange(W.Range))
                        {
                            if (spirit.UnitSkinName == target.UnitSkinName)
                            {
                                if (Player.Distance(spirit) < W.Range)
                                {
                                    CastW(spirit);
                                }
                            }
                        }
                    }
                    CastW(target);
                }

                if (Q.Ready && useQ && Player.Distance(target) < Q.Range)
                {
                    if (Player.HasBuff("IllaoiR"))
                    {
                        if (blockQ)
                        {
                            return;
                        }
                    }

                    if (!Player.HasBuff("IllaoiR"))
                    {
                        if (hitSpirit)
                        {
                            foreach (var spirit in GetEnemyLaneMinionsTargetsInRange(Q.Range))
                            {
                                if (spirit.UnitSkinName == target.UnitSkinName)
                                {
                                    if (Player.Distance(spirit) < Q.Range)
                                    {
                                        CastQ(spirit);
                                    }
                                }
                            }
                        }
                        CastQ(target);
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

            bool useQ = Menu["q"]["harassq"].Enabled;
            bool useW = Menu["w"]["harassw"].Enabled;
            bool useE = Menu["e"]["harasse"].Enabled;

            if (target != null)
            {
                if (Q.Ready && useQ && Player.Distance(target) < Q.Range)
                {
                    CastQ(target);
                }

                if (W.Ready && useW && Player.Distance(target) < W.Range)
                {
                    CastW(target);
                }

                if (E.Ready && useE && Player.Distance(target) < E.Range)
                {
                    CastE(target);
                }
            }
        }

        private void LastHit()
        {
            bool useW = Menu["w"]["lastw"].Enabled;
            bool spells = Menu["misc"]["spells"].Enabled;

            foreach (var minion in GetEnemyLaneMinionsTargetsInRange(W.Range))
            {
                if (minion != null && spells)
                {
                    if (W.Ready && useW && Player.Distance(minion) < W.Range)
                    {
                        CastW(minion);
                    }
                }
            }
        }

        public void LaneClear()
        {
            bool useQ = Menu["q"]["laneq"].Enabled;
            bool useW = Menu["w"]["lanew"].Enabled;
            bool spells = Menu["misc"]["spells"].Enabled;

            foreach (var minion in GetEnemyLaneMinionsTargetsInRange(Q.Range))
            {
                if (minion != null && spells)
                {
                    if (W.Ready && useW && Player.Distance(minion) < W.Range)
                    {
                        CastW(minion);
                    }

                    if (Q.Ready && useQ && Player.Distance(minion) < Q.Range)
                    {
                        CastQ(minion);
                    }
                }
            }
        }
    }
}
