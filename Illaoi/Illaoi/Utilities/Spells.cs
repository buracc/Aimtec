using Aimtec;
using Aimtec.SDK.Prediction.Skillshots;
using Spell = Aimtec.SDK.Spell;


namespace Illaoi
{
    internal partial class Illaoi
    {
        public static Spell Q, W, E, R;

        public void InitSpells()
        { 
            Q = new Spell(SpellSlot.Q, 850f);
            W = new Spell(SpellSlot.W, 350f);
            E = new Spell(SpellSlot.E, 900f);
            R = new Spell(SpellSlot.R, 450f);

            Q.SetSkillshot(0.25f, 90f, 850f, false, SkillshotType.Line);
            E.SetSkillshot(0.25f, 50f, 900f, true, SkillshotType.Line);
        }
    }
}
