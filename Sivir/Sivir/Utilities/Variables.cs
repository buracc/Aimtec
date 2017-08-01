using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aimtec;
using Aimtec.SDK.TargetSelector;

namespace Sivir
{
    internal partial class Sivir
    {
        public static Obj_AI_Hero Player => ObjectManager.GetLocalPlayer();
        public Obj_AI_Hero target;
        public Vector3 pos = Player.ServerPosition;
    }
}
