using System;

class SimpleRoguelike
{
    static Random random = new Random();
    class Player
    {
        public int HP = 100;
        public int Attack = 10;
        public int Defense = 5;
        public bool Frozen = false;
    }
    class Enemy
    {
        public string Name;
        public int HP;
        public int Attack;
        public string Type;
    }

    static void Main()
    {

        Console.WriteLine("0-0-0-0-0 Roguelike RUSSIA 0-0-0-0-0");
        Player player = new Player();
        int turn = 0;

        while (player.HP > 0)
        {

        }

    }

}