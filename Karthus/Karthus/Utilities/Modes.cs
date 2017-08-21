using System;
using System.Linq;
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Util.Cache;

namespace Karthus
{
    internal partial class Karthus
    {
        private static string killableTarg;
        private static bool killableTargBool = false;

        public void LaneClear()
        {
            bool spells = Menu["misc"]["spells"].Enabled;
            bool useQ = Menu["q"]["laneq"].Enabled;
            bool useE = Menu["e"]["lanee"].Enabled;

            if (CountMinionsInRange(1000) < 1 && Player.HasBuff("KarthusDefile"))
            {
                E.Cast();
            }

            foreach (var minion in GetEnemyLaneMinionsTargetsInRange(Q.Range))
            {
                if (minion != null && spells && !minion.UnitSkinName.Contains("Plant"))
                {
                    if (useQ)
                    {
                        CastQ(minion);
                    }
                }
                
                switch (Menu["e"]["emode"].Value)
                {
                    case 0:

                        if (minion != null && spells && !minion.UnitSkinName.Contains("Plant"))
                        {
                            if (useE && !Player.HasBuff("KarthusDefile"))
                            {
                                CastE(minion);
                            }
                        }
                        break;

                    case 1:

                        if (minion != null && spells && !minion.UnitSkinName.Contains("Plant"))
                        {
                            double dmg = Player.GetSpellDamage(minion, SpellSlot.E);
                            if (useE && !Player.HasBuff("KarthusDefile") && minion.Health <= dmg)
                            {
                                CastE(minion);
                            }
                        }
                        break;
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

            if (Player.CountEnemyHeroesInRange(E.Range) < 1 && Player.HasBuff("KarthusDefile"))
            {
                E.Cast();
            }

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

                if (E.Ready && useE && !Player.HasBuff("KarthusDefile") && Player.Distance(target) < E.Range)
                {
                    CastE(target);
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
            bool useE = Menu["e"]["comboe"].Enabled;

            if (Player.CountEnemyHeroesInRange(E.Range) < 1 && Player.HasBuff("KarthusDefile"))
            {
                E.Cast();
            }

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
            
                if (E.Ready && useE && !Player.HasBuff("KarthusDefile") && Player.Distance(target) < E.Range)
                {
                    CastE(target);
                }
            }
        }

        public void LastHit()
        {
            bool spells = Menu["misc"]["spells"].Enabled;
            bool useQ = Menu["q"]["lastq"].Enabled;
            
            foreach (var minion in GetEnemyLaneMinionsTargetsInRange(Q.Range))
            {
                double dmg = Player.GetSpellDamage(minion, SpellSlot.Q);
                if (minion != null && spells && minion.IsMinion)
                {
                    if (useQ && minion.Health <= dmg && !minion.UnitSkinName.Contains("Plant"))
                    {
                        CastQ(minion);
                    }
                }
            }
        }

        public void AutoR()
        {
            target = GetBestEnemyHeroTargetInRange(10000);

            if (target == null)
            {
                return;
            }

            bool useR = Menu["r"]["user"].Enabled;
            bool deadR = Menu["r"]["deadr"].Enabled;
            double dmg = Player.GetSpellDamage(target, SpellSlot.R);

            if (useR && !deadR)
            {
                switch (Menu["r"]["rmode"].Value)
                {
                    case 0:
                        if (target.Health <= dmg)
                        {
                            CastR(target);
                        }
                        break;

                    case 1:
                        if (target.Health <= dmg)
                        {
                            killableTarg = target.Name;
                            killableTargBool = true;
                        }
                        break;
                }
            }

            if (useR && deadR)
            {
                if (Player.HasBuff("KarthusDeathDefiedBuff"))
                {
                    switch (Menu["r"]["rmode"].Value)
                    {
                        case 0:
                            if (target.Health <= dmg)
                            {
                                CastR(target);
                            }
                            break;

                        case 1:
                            if (target.Health <= dmg)
                            {
                                killableTarg = target.Name;
                                killableTargBool = true;
                            }
                            break;
                    }
                }
            }
        }
    }
}