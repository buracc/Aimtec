using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;

namespace Sivir
{
    internal partial class Sivir
    {

        public void LaneClear()
        {

        }

        public void Harass()
        {

        }

        public void Combo()
        {
            bool useQ = Menu["combo"]["useq"].As<MenuBool>().Enabled;
            bool useW = Menu["combo"]["usew"].As<MenuBool>().Enabled;

            if (useQ)
            {
                CastQ(target);
            }
        }
    }
}