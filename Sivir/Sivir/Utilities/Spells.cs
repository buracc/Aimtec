using Aimtec;
using Aimtec.SDK.Prediction.Skillshots;
using Spell = Aimtec.SDK.Spell;

namespace Sivir
{
    internal partial class Sivir
    {

        public static Spell Q, W, E, R;

        public void InitSpells()
        {
            Q = new Spell(SpellSlot.Q, 1200f);
            W = new Spell(SpellSlot.W, Player.AttackRange + Player.BoundingRadius);
            E = new Spell(SpellSlot.E);
            R = new Spell(SpellSlot.R);

            Q.SetSkillshot(0.25f, 90f, 1200f, false, SkillshotType.Line);

        }
    }
}