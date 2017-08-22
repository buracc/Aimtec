using System;

namespace XinZhao
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
            if (ObjectManager.GetLocalPlayer().ChampionName == "XinZhao")
            {
                Console.WriteLine("Xin Zhao Loaded.");
                var XinZhao = new XinZhao();
            }
        }
    }
}
