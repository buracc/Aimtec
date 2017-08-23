using Aimtec;

namespace Hecarim
{
    internal partial class Hecarim
    {
        public void InitMethods()
        {
            Game.OnUpdate += Game_OnUpdate;
            Render.OnPresent += OnDrawings;
        }
    }
}