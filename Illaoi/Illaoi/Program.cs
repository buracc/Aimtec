using System;


namespace Illaoi
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
            if (ObjectManager.GetLocalPlayer().ChampionName == "Illaoi")
            {
                Console.WriteLine("Illaoi Loaded.");
                var Illaoi = new Illaoi();
            }
        }
    }
}