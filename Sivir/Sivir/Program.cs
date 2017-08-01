using System;
using Aimtec;
using Aimtec.SDK.Events;

namespace Sivir
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEvents.GameStart += OnLoad;
        }
        private static void OnLoad()
        {
            if (ObjectManager.GetLocalPlayer().ChampionName == "Sivir")
            {
                Console.WriteLine("Sivir Loaded.");
                var Sivir = new Sivir();
            }
        }
    }
}