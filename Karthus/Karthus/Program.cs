using System;

namespace Karthus
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
            if (ObjectManager.GetLocalPlayer().ChampionName == "Karthus")
            {
                Console.WriteLine("Karthus Loaded.");
                var Karthus = new Karthus();
            }
        }
    }
}
