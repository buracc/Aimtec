using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;

namespace Sivir
{
    internal partial class Sivir
    {
        
        public void LaneClear()
        {
            bool useQ = Menu["lane"]["useq"].Enabled;
            bool useW = Menu["lane"]["usew"].Enabled;

            foreach (var minion in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(Q.Range)))
            {
                if (minion != null)
                {
                    if (Q.Ready && useQ)
                    {
                        CastQ(minion);
                    }

                    if (W.Ready && useW)
                    {
                        CastW(minion);
                    }
                }
            }
        }

        public void Harass()
        {
            bool useQ = Menu["harass"]["useq"].Enabled;
            bool useW = Menu["harass"]["usew"].Enabled;

            if(target != null)
            {
                if (Q.Ready && useQ)
                {
                    CastQ(target);
                }

                if (W.Ready && useW)
                {
                    CastW(target);
                }
            }
        }

        public void Combo()
        {
            bool useQ = Menu["combo"]["useq"].Enabled;
            bool useW = Menu["combo"]["usew"].Enabled;

            if (target != null)
            {
                if (Q.Ready && useQ)
                {
                    CastQ(target);
                }

                if (W.Ready && useW)
                {
                    CastW(target);
                }
            }
            
        }
        
        public void LastHit()
        {
            bool useW = Menu["last"]["usew"].Enabled;

            foreach (var minion in GameObjects.EnemyMinions.Where(m => m.IsValidTarget(Q.Range)))
            {
                if (minion != null)
                {
                    double dmg = Player.GetSpellDamage(minion, SpellSlot.W);
                    if (W.Ready && useW && dmg > minion.Health)
                    {
                        CastW(minion);
                    }
                }
            }
        }

        public void Misc()
        {
            bool ksQ = Menu["misc"]["qks"].Enabled;
            bool ccQ = Menu["misc"]["qcc"].Enabled;
            
            if (target != null)
            {
                double dmg = Player.GetSpellDamage(target, SpellSlot.Q);
                if (Q.Ready && ksQ && target.Health <= dmg)
                {
                    CastQ(target);
                }

                if (Q.Ready && ccQ)
                {
                    if (target.HasBuffOfType(BuffType.Snare | BuffType.Stun))
                    {
                        //check for special debuffs like malz R
                        CastQ(target);
                    }
                }
            }
            
        }

        
    }
}   