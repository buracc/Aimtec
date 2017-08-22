using Aimtec;
using Aimtec.SDK.Prediction.Skillshots;
using Spell = Aimtec.SDK.Spell;

namespace Karthus
{
    internal partial class Karthus
    {

        public static Spell Q, W, E, R;

        public void InitSpells()
        {
            Q = new Spell(SpellSlot.Q, 875f);
            W = new Spell(SpellSlot.W, 1000f);
            E = new Spell(SpellSlot.E, 550f);
            R = new Spell(SpellSlot.R, 10000f);

            Q.SetSkillshot(0.625f, 160f, 1000f, false, SkillshotType.Circle, false, HitChance.Medium);
            W.SetSkillshot(0.25f, 100f, 1000f, false, SkillshotType.Circle, false, HitChance.None);
        }
    }
}