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
            Q = new Spell(SpellSlot.Q, 950f);
            W = new Spell(SpellSlot.W, 675f);
            E = new Spell(SpellSlot.E, 800f);
            R = new Spell(SpellSlot.R);

            Q.SetSkillshot(0.25f, 90f, 950f, false, SkillshotType.Line);
        }
    }
}
