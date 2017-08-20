using Aimtec;

namespace Template
{
    internal partial class Template
    {
        public void InitMethods()
        {
            Game.OnUpdate += Game_OnUpdate;
            Render.OnPresent += OnDrawings;
        }
    }
}