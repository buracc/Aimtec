using Aimtec;
using Aimtec.SDK.Extensions;

namespace Illaoi
{
    internal partial class Illaoi
    {
        public void CastQ(Obj_AI_Base unit)
        {
            if (!Q.Ready || Player.Mana < Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
            {
                return;
            }

            if (Player.Distance(unit) < Q.Range)
            {
                Q.Cast(unit);
            }
        }

        public void CastQSlow(Obj_AI_Base unit)
        {
            if (!Q.Ready || Player.Mana < Player.SpellBook.GetSpell(SpellSlot.Q).Cost)
            {
                return;
            }

            if (Player.Distance(unit) <= Q.Range - 100)
            {
                Q.Cast(unit);
            }
        }

        public void CastW(Obj_AI_Base unit)
        {
            if (!W.Ready || Player.Mana < Player.SpellBook.GetSpell(SpellSlot.W).Cost)
            {
                return;
            }

            if (Player.Distance(unit) < W.Range)
            {
                W.Cast();
            }
        }

        public void CastE(Obj_AI_Base unit)
        {
            if (!E.Ready || Player.Mana < Player.SpellBook.GetSpell(SpellSlot.E).Cost)
            {
                return;
            }

            if (Player.Distance(unit) < E.Range)
            {
                E.Cast();
            }
        }

        public void CastR(Obj_AI_Base unit)
        {
            if (!R.Ready || Player.Mana < Player.SpellBook.GetSpell(SpellSlot.R).Cost)
            {
                return;
            }

            if (Player.Distance(unit) < R.Range)
            {
                R.Cast();
            }
        }
    }
}
