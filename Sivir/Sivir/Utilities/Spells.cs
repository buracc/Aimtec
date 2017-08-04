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
            Spell Q = new Spell(SpellSlot.Q, 1200f);
            Spell W = new Spell(SpellSlot.W);
            Spell E = new Spell(SpellSlot.E);
            Spell R = new Spell(SpellSlot.R);

            Q.SetSkillshot(0.25f, 90f, 1200f, false, SkillshotType.Line);

        }
    }
}