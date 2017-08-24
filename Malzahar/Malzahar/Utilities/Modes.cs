using System.Linq;
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Util.Cache;

namespace Malzahar
{
    internal partial class Malzahar
    {

        public void LaneClear()
        {
            bool spells = Menu["misc"]["spells"].Enabled;
            bool useQ = Menu["q"]["laneq"].Enabled;
            bool useW = Menu["w"]["lanew"].Enabled;
            bool useE = Menu["e"]["lanee"].Enabled;
            bool lastE = Menu["e"]["laste"].Enabled;

            foreach (var minion in GetEnemyLaneMinionsTargetsInRange(Q.Range))
            {
                if (minion != null && spells)
                {
                    if (useQ && Q.Ready && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
                    {
                        Q.Cast(minion);
                    }

                    if (useW && W.Ready && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.W).Cost)
                    {
                        W.Cast();
                    }

                    if (!lastE && useE && E.Ready && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.E).Cost)
                    {
                        E.CastOnUnit(minion);
                    }

                    if (lastE && useE && E.Ready && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.E).Cost)
                    {
                        foreach (var creep in GameObjects.EnemyMinions.Where(
                            t => t.Health <= Player.GetSpellDamage(t, SpellSlot.E)))
                        {
                            if (creep.IsValidTarget())
                            {
                                E.CastOnUnit(creep);
                            }
                        }
                    }
                }
            }
        }

        public void Combo()
        {
            target = GetBestEnemyHeroTargetInRange(Q.Range);

            bool useQ = Menu["q"]["comboq"].Enabled;
            bool useW = Menu["w"]["combow"].Enabled;
            bool useE = Menu["e"]["comboe"].Enabled;
            bool useR = Menu["r"]["combor"].Enabled;
            bool wlR = Menu["rwl"][target.ChampionName.ToLower()].Enabled;

            if (target == null)
            {
                return;
            }

            if (useQ && Q.Ready && Player.Distance(target) < Q.Range &&
                Player.Mana > Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
            {
                if (target.IsValidTarget(Q.Range))
                {
                    Q.Cast(target);
                }
            }

            if (useW && W.Ready && Player.Distance(target) < W.Range &&
                Player.Mana > Player.SpellBook.GetSpell(SpellSlot.W).Cost)
            {
                if (target.IsValidTarget(Q.Range))
                {
                    W.Cast();
                }
            }

            if (useE && E.Ready && Player.Distance(target) < E.Range &&
                Player.Mana > Player.SpellBook.GetSpell(SpellSlot.E).Cost)
            {
                if (target.IsValidTarget(E.Range))
                {
                    E.CastOnUnit(target);
                }
            }

            if (!E.Ready && useR && R.Ready && Player.Distance(target) < R.Range &&
                Player.Mana > Player.SpellBook.GetSpell(SpellSlot.R).Cost)
            {
                if (wlR && target.IsValidTarget(R.Range))
                {
                    R.CastOnUnit(target);
                }
            }
        }

        public void Harass()
        {
            target = GetBestEnemyHeroTargetInRange(Q.Range);

            if (target == null)
            {
                return;
            }

            bool useQ = Menu["q"]["harassq"].Enabled;
            bool useW = Menu["w"]["harassw"].Enabled;
            bool useE = Menu["e"]["harasse"].Enabled;

            target = GetBestEnemyHeroTargetInRange(Q.Range);

            if (target == null)
            {
                return;
            }

            if (useQ && Q.Ready && Player.Distance(target) < Q.Range &&
                Player.Mana > Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
            {
                if (target.IsValidTarget(Q.Range))
                {
                    Q.Cast(target);
                }
            }

            if (useW && W.Ready && Player.Distance(target) < W.Range &&
                Player.Mana > Player.SpellBook.GetSpell(SpellSlot.W).Cost)
            {
                if (target.IsValidTarget(Q.Range))
                {
                    W.Cast();
                }
            }

            if (useE && E.Ready && Player.Distance(target) < E.Range &&
                Player.Mana > Player.SpellBook.GetSpell(SpellSlot.E).Cost)
            {
                if (target.IsValidTarget(E.Range))
                {
                    E.CastOnUnit(target);
                }
            }

        }
    }
}