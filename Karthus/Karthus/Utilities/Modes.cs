using System;
using System.Linq;
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.TargetSelector;
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

            if (CountMinionsInRange(E.Range) < 1 && Player.HasBuff("KarthusDefile"))
            {
                E.Cast();
            }

            foreach (var minion in GetEnemyLaneMinionsTargetsInRange(Q.Range))
            {
                if (minion != null && spells && !minion.UnitSkinName.Contains("Plant"))
                {
                    if (!Q.Ready || Player.Mana < Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
                    {
                        return;
                    }

                    if (useQ && Player.Distance(minion) < Q.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
                    {
                        Q.Cast(minion);
                    }
                }
                
                switch (Menu["e"]["emode"].Value)
                {
                    case 0:

                        if (minion != null && spells && !minion.UnitSkinName.Contains("Plant"))
                        {
                            if (!E.Ready || Player.Mana < Player.SpellBook.GetSpell(SpellSlot.E).Cost)
                            {
                                return;
                            }

                            if (useE && !Player.HasBuff("KarthusDefile") && Player.Distance(minion) < E.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.E).Cost)
                            {
                                E.Cast(minion);
                            }
                        }
                        break;

                    case 1:

                        if (minion != null && spells && !minion.UnitSkinName.Contains("Plant"))
                        {
                            double dmg = Player.GetSpellDamage(minion, SpellSlot.E);

                            if (!E.Ready || Player.Mana < Player.SpellBook.GetSpell(SpellSlot.E).Cost)
                            {
                                return;
                            }

                            if (useE && !Player.HasBuff("KarthusDefile") && minion.Health <= dmg && Player.Distance(minion) < E.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.E).Cost)
                            {
                                E.Cast(minion);
                            }
                        }
                        break;
                }
            }
        }
       
        public void Harass()
        {
            target = GetBestEnemyHeroTargetInRange(1500);

            if (Player.CountEnemyHeroesInRange(E.Range) < 1 && Player.HasBuff("KarthusDefile"))
            {
                E.Cast();
            }

            if (!target.IsValidTarget())
            {
                return;
            }

            bool useQ = Menu["q"]["harassq"].Enabled;
            bool useW = Menu["w"]["harassw"].Enabled;
            bool useE = Menu["e"]["harasse"].Enabled;
            
            if (target.IsValidTarget(Q.Range))
            {
                if (Q.Ready && useQ && Player.Distance(target) < Q.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
                {
                    Q.Cast(target);
                }
            }


            if (target.IsValidTarget(W.Range))
            {
                if (W.Ready && useW && Player.Distance(target) < W.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.W).Cost)
                {
                    W.Cast(target);
                }
            }

            if (target.IsValidTarget(E.Range))
            {
                if (E.Ready && useE && !Player.HasBuff("KarthusDefile") && Player.Distance(target) < E.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.E).Cost)
                {
                    E.Cast();
                }
            }

        }

        public void Combo()
        {
            target = GetBestEnemyHeroTargetInRange(1500);

            if (Player.CountEnemyHeroesInRange(E.Range) == 0 && Player.HasBuff("KarthusDefile"))
            {
                E.Cast();
            }

            if (!target.IsValidTarget())
            {
                return;
            }

            bool useQ = Menu["q"]["comboq"].Enabled;
            bool useW = Menu["w"]["combow"].Enabled;
            bool useE = Menu["e"]["comboe"].Enabled;

            
            
            if (target.IsValidTarget(Q.Range))
            {
                if (Q.Ready && useQ && Player.Distance(target) < Q.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
                {
                    Q.Cast(target);
                }
            }
            

            if (target.IsValidTarget(W.Range))
            {
                if (W.Ready && useW && Player.Distance(target) < W.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.W).Cost)
                {
                    W.Cast(target);
                }
            }

            if (target.IsValidTarget(E.Range))
            {
                if (E.Ready && useE && !Player.HasBuff("KarthusDefile") && Player.Distance(target) < E.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.E).Cost)
                {
                    E.Cast();
                }
            }   
        }
       
        public void LastHit()
        {
            bool spells = Menu["misc"]["spells"].Enabled;
            bool useQ = Menu["q"]["lastq"].Enabled;

            if (CountMinionsInRange(E.Range) < 1 && Player.HasBuff("KarthusDefile"))
            {
                E.Cast();
            }

            foreach (var minion in GetEnemyLaneMinionsTargetsInRange(Q.Range))
            {
                double dmg = Player.GetSpellDamage(minion, SpellSlot.Q);
                if (minion != null && spells && minion.IsMinion)
                {
                    if (!Q.Ready || Player.Mana < Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
                    {
                        return;
                    }

                    if (Q.Ready && useQ && minion.Health <= dmg && !minion.UnitSkinName.Contains("Plant") && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
                    {
                        Q.Cast(minion);
                    }
                }
            }
        }

        public void AutoR()
        {
            target = GetBestEnemyHeroTargetInRange(R.Range);

            if (target == null)
            {
                return;
            }

            bool useR = Menu["r"]["user"].Enabled;
            bool deadR = Menu["r"]["deadr"].Enabled;
            double dmg = Player.GetSpellDamage(target, SpellSlot.R) - 50;

            if (useR && !deadR)
            {
                switch (Menu["r"]["rmode"].Value)
                {
                    case 0:
                        if (!R.Ready || Player.Mana < Player.SpellBook.GetSpell(SpellSlot.R).Cost)
                        {
                            return;
                        }

                        if (R.Ready && target.Health < dmg && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.R).Cost)
                        {
                            R.Cast();
                        }
                        break;

                    case 1:
                        if (target.Health < dmg)
                        {
                            killableTarg = target.ChampionName;
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
                            if (!R.Ready || Player.Mana < Player.SpellBook.GetSpell(SpellSlot.R).Cost)
                            {
                                return;
                            }

                            if (R.Ready && target.Health < dmg && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.R).Cost)
                            {
                                R.Cast();
                            }
                            break;

                        case 1:
                            if (target.Health < dmg)
                            {
                                killableTarg = target.ChampionName;
                                killableTargBool = true;
                            }
                            break;
                    }
                }
            }
        }
    }
}