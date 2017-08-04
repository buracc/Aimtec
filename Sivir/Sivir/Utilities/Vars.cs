using Aimtec;
using Aimtec.SDK.TargetSelector;

namespace Sivir
{
    internal partial class Sivir
    {
        public static Obj_AI_Hero Player => ObjectManager.GetLocalPlayer();
        public Obj_AI_Hero target = TargetSelector.GetTarget(1500);
    }
}
