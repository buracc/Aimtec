using System;

namespace Malzahar
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
            if (ObjectManager.GetLocalPlayer().ChampionName == "Malzahar")
            {
                Console.WriteLine("xx Loaded.");
                var Malzahar = new Malzahar();
            }
        }
    }
}
