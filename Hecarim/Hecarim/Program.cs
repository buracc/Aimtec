using System;

namespace Hecarim
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
            if (ObjectManager.GetLocalPlayer().ChampionName == "Hecarim")
            {
                Console.WriteLine("Hecarim Loaded.");
                var Hecarim = new Hecarim();
            }
        }
    }
}
