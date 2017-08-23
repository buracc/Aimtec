using System.Linq;
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Util.Cache;

namespace Hecarim
{
    internal partial class Hecarim
    {

        public void LaneClear()
        {
            bool spells = Menu["misc"]["spells"].Enabled;
            bool useQ = Menu["q"]["laneq"].Enabled;
            bool useW = Menu["w"]["lanew"].Enabled;

            foreach (var minion in GetEnemyLaneMinionsTargetsInRange(1500))
            {
                if (minion != null && spells)
                {
                    if (minion != null && spells && !minion.UnitSkinName.Contains("Plant"))
                    {
                        if (!Q.Ready || Player.Mana < Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
                        {
                            return;
                        }

                        if (useQ && Player.Distance(minion) < Q.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
                        {
                            Q.Cast();
                        }
                    }

                    if (minion != null && spells && !minion.UnitSkinName.Contains("Plant"))
                    {
                        if (!W.Ready || Player.Mana < Player.SpellBook.GetSpell(SpellSlot.W).Cost)
                        {
                            return;
                        }

                        if (useW && !Player.HasBuff("KarthusDefile") && Player.Distance(minion) < W.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.W).Cost)
                        {
                            W.Cast();
                        }
                    }

                }
            }
        }

        public void Harass()
        {
            target = GetBestEnemyHeroTargetInRange(1500);

            bool useQ = Menu["q"]["harassq"].Enabled;
            bool useW = Menu["w"]["harassw"].Enabled;
            bool useE = Menu["e"]["harasse"].Enabled;

            if (target == null)
            {
                return;
            }

            if (target.IsValidTarget(Q.Range))
            {
                if (Q.Ready && useQ && Player.Distance(target) < Q.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
                {
                    Q.Cast();
                }
            }


            if (target.IsValidTarget(W.Range))
            {
                if (W.Ready && useW && Player.Distance(target) < W.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.W).Cost)
                {
                    W.Cast();
                }
            }

            if (target.IsValidTarget(E.Range))
            {
                if (E.Ready && useE && Player.Distance(target) < E.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.E).Cost)
                {
                    E.Cast();
                }
            }
        }

        public void Combo()
        {
            target = GetBestEnemyHeroTargetInRange(1500);

            bool useQ = Menu["q"]["comboq"].Enabled;
            bool useW = Menu["w"]["combow"].Enabled;
            bool useE = Menu["e"]["comboe"].Enabled;
            bool useR = Menu["r"]["combor"].Enabled;
            bool hitR = Menu["r"]["rcount"].Enabled;
            int countR = Menu["r"]["rcount"].Value;

            if (target == null)
            {
                return;
            }

            if (target.IsValidTarget(Q.Range))
            {
                if (Q.Ready && useQ && Player.Distance(target) < Q.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
                {
                    Q.Cast();
                }
            }


            if (target.IsValidTarget(W.Range))
            {
                if (W.Ready && useW && Player.Distance(target) < W.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.W).Cost)
                {
                    W.Cast();
                }
            }

            if (target.IsValidTarget(E.Range))
            {
                if (E.Ready && useE && Player.Distance(target) < E.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.E).Cost)
                {
                    E.Cast();
                }
            }

            if (target.IsValidTarget(R.Range))
            {
                if (R.Ready && useR && Player.Distance(target) < R.Range && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.R).Cost)
                {
                    if (hitR)
                    {
                        R.CastIfWillHit(target, countR);
                    }
                    R.Cast(target);
                }
            }
        }
    }
}