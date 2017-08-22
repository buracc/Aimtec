using System.Linq;
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Util.Cache;

namespace XinZhao
{
    internal partial class XinZhao
    {

        public void LaneClear()
        {
            bool spells = Menu["misc"]["spells"].Enabled;
            bool useQ = Menu["q"]["laneq"].Enabled;
            bool useW = Menu["w"]["lanew"].Enabled;

            foreach (var minion in GetEnemyLaneMinionsTargetsInRange(E.Range))
            {
                if (minion != null && spells)
                {
                    if (useQ && Q.Ready && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
                    {
                        Q.Cast();
                    }

                    if (useW && W.Ready && Player.Mana > Player.SpellBook.GetSpell(SpellSlot.W).Cost)
                    {
                        W.Cast();
                    }
                }
            }
        }

        public void Harass()
        {
            target = GetBestEnemyHeroTargetInRange(E.Range);

            if (target == null)
            {
                return;
            }

            bool useQ = Menu["q"]["harassq"].Enabled;
            bool useW = Menu["w"]["harassw"].Enabled;
            bool useE = Menu["e"]["harasse"].Enabled;

            if (useE && E.Ready)
            {
                if (target.IsValidTarget() && Player.Distance(target) < E.Range &&
                    Player.Mana > Player.SpellBook.GetSpell(SpellSlot.E).Cost)
                {
                    E.CastOnUnit(target);
                }
            }

            if (useQ && Q.Ready)
            {
                if (target.IsValidTarget() && Player.Distance(target) < Player.AttackRange &&
                    Player.Mana > Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
                {
                    Q.Cast();
                }
            }

            if (useW && W.Ready)
            {
                if (target.IsValidTarget() && Player.Distance(target) < Player.AttackRange &&
                    Player.Mana > Player.SpellBook.GetSpell(SpellSlot.W).Cost)
                {
                    W.Cast();
                }
            }
        }

        public void Combo()
        {
            target = GetBestEnemyHeroTargetInRange(E.Range);

            if (target == null)
            {
                return;
            }

            bool useQ = Menu["q"]["comboq"].Enabled;
            bool useW = Menu["w"]["combow"].Enabled;
            bool useE = Menu["e"]["comboe"].Enabled;
            bool useR = Menu["r"]["combor"].Enabled;

            if (useE && E.Ready)
            {
                if (target.IsValidTarget() && Player.Distance(target) < E.Range &&
                    Player.Mana > Player.SpellBook.GetSpell(SpellSlot.E).Cost)
                {
                    E.CastOnUnit(target);
                }
            }

            if (useQ && Q.Ready)
            {
                if (target.IsValidTarget() && Player.Distance(target) < Player.AttackRange &&
                    Player.Mana > Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
                {
                    Q.Cast();
                }
            }

            if (useW && W.Ready)
            {
                if (target.IsValidTarget() && Player.Distance(target) < Player.AttackRange &&
                    Player.Mana > Player.SpellBook.GetSpell(SpellSlot.W).Cost)
                {
                    W.Cast();
                }
            }

            if (useR && R.Ready)
            {
                if (target.IsValidTarget() && Player.Distance(target) < R.Range &&
                    Player.Mana > Player.SpellBook.GetSpell(SpellSlot.R).Cost)
                {
                    R.Cast();
                }
            }
        }
    }
}