using System;


namespace Karma
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
            if (ObjectManager.GetLocalPlayer().ChampionName == "Karma")
            {
                Console.WriteLine("Karma Loaded.");
                var Karma = new Karma();
            }
        }
    }
}