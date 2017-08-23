using Aimtec;
using Aimtec.SDK.Prediction.Skillshots;
using Spell = Aimtec.SDK.Spell;

namespace Hecarim
{
    internal partial class Hecarim
    {

        public static Spell Q, W, E, R;

        public void InitSpells()
        {
            Q = new Spell(SpellSlot.Q, 350f);
            W = new Spell(SpellSlot.W, 575f);
            E = new Spell(SpellSlot.E);
            R = new Spell(SpellSlot.R, 1000f);

            R.SetSkillshot(0.25f, 160f, 1000f, false, SkillshotType.Circle, false, HitChance.Medium);
        }
    }
}