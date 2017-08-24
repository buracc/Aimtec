using Aimtec;

namespace Malzahar
{
    internal partial class Malzahar
    {
        public void InitMethods()
        {
            Game.OnUpdate += Game_OnUpdate;
            Render.OnPresent += OnDrawings;
        }
    }
}