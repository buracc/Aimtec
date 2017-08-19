using Aimtec;
using Aimtec.SDK.Prediction.Skillshots;
using Spell = Aimtec.SDK.Spell;

namespace Karma
{
    internal partial class Karma
    {
        public static Spell Q, W, E, R;

        public void InitSpells()
        {
            Q = new Spell(SpellSlot.Q, 950);
            W = new Spell(SpellSlot.W, 675);
            E = new Spell(SpellSlot.E, 800);
            R = new Spell(SpellSlot.R, 0);

            Q.SetSkillshot(0.25f, 60, 1700, true, SkillshotType.Line);
        }
    }
}
