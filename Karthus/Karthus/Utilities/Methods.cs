using Aimtec;

namespace Karthus
{
    internal partial class Karthus
    {
        public void InitMethods()
        {
            Game.OnUpdate += Game_OnUpdate;
            Render.OnPresent += OnDrawings;
        }
    }
}