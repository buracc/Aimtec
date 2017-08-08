using Aimtec;

namespace Karma
{
    internal partial class Karma
    {
        public void InitMethods()
        {
            Game.OnUpdate += Game_OnUpdate;
            Render.OnPresent += OnDrawings;
        }
    }
}
