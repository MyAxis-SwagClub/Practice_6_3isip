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
    static Enemy CreateEnemy()
    {
        int type = random.Next(3);
        if (type == 0)
        {
            return new Enemy { Name = "Гоблин", HP = 30, Attack = 8, Type = "Гоблин" };
        }
        if (type == 1)
        {
            return new Enemy { Name = "Скелет", HP = 25, Attack = 10, Type = "Скелет" };
        }
        else
        {
            return new Enemy { Name = "Маг", HP = 20, Attack = 7, Type = "Маг" };
        }
    }
    static Enemy CreateBoss()
    {
        int type = random.Next(4);
        if (type == 0)
        {
            return new Enemy { Name = "ВВГ", HP = 60, Attack = 12, Type = "Гоблин" };
        }
        if (type == 1)
        {
            return new Enemy { Name = "Ковальский", HP = 63, Attack = 13, Type = "Скелет" };
        }
        if (type == 2)
        {
            return new Enemy { Name = "Архимаг C++", HP = 36, Attack = 11, Type = "Маг" };
        }
        else
        {
            return new Enemy { Name = "Пестов С--", HP = 26, Attack = 14, Type = "Скелет" };
        }
    }



}