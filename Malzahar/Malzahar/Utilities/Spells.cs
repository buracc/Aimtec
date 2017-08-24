using Aimtec;
using Aimtec.SDK.Prediction.Skillshots;
using Spell = Aimtec.SDK.Spell;

namespace Malzahar
{
    internal partial class Malzahar
    {

        public static Spell Q, W, E, R;

        public void InitSpells()
        {
            Q = new Spell(SpellSlot.Q, 900f);
            W = new Spell(SpellSlot.W);
            E = new Spell(SpellSlot.E, 650f);
            R = new Spell(SpellSlot.R, 700f);

            Q.SetSkillshot(1.0f, 85f, 3200f, false, SkillshotType.Circle, false, HitChance.Medium);
        }
    }
}