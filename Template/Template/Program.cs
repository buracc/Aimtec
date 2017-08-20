using System;

namespace Template
{
    using Aimtec;
    using Aimtec.SDK.Events;

    class Program
    {
        static void Main(string[] args)
        {
            GameEvents.GameStart += OnLoad;
        }

        private static void OnLoad()
        {
            if (ObjectManager.GetLocalPlayer().ChampionName == "Template")
            {
                Console.WriteLine("xx Loaded.");
                var Template = new Template();
            }
        }
    }
}
