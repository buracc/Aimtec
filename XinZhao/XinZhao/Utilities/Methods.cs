using Aimtec;

namespace XinZhao
{
    internal partial class XinZhao
    {
        public void InitMethods()
        {
            Game.OnUpdate += Game_OnUpdate;
            Render.OnPresent += OnDrawings;
        }
    }
}