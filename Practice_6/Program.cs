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

    static void Fight(Player player, Enemy enemy)
    {
        while (enemy.HP > 0 && player.HP > 0)
        {
            Console.Write("\nДля атаки [1] \nДля защиты [2]\n");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                enemy.HP -= player.Attack;
                Console.WriteLine($"\nВы нанесли {player.Attack} урона");
            }
            else if (choice == "2")
            {
                if (random.Next(100) < 40)
                {
                    Console.WriteLine("\nУклонение! Враг промахнулся");
                    continue;
                }
                else
                {
                    int block = player.Defense * random.Next(70, 101) / 100;
                    Console.WriteLine($"\nБлокировано {block} урона");
                }
            }

            if (enemy.HP <= 0)
            {
                Console.WriteLine($"{enemy.Name} побежден!");
                break;
            }

            int damage = enemy.Attack;

            if (enemy.Type == "Гоблин")
            {
                if (enemy.Name == "ВВГ")
                {
                    if (random.Next(100) < 30)
                    {
                        damage *= 2;
                        Console.WriteLine("Критический урон!");
                    }
                }
                else if (enemy.Type == "Гоблин")
                {
                    if (random.Next(100) < 20)
                    {
                        damage *= 2;
                        Console.WriteLine("Критический урон!");
                    }
                }
            }

            else if (enemy.Type == "Скелет")
            {
                Console.WriteLine("Враг игнорирует защиту!");
            }

            else if (enemy.Type == "Маг")
            {
                if (enemy.Name == "Архимаг C++" && random.Next(100) < 35)
                {
                    player.Frozen = true;
                    Console.WriteLine("Заморозка!");
                }

                else if (enemy.Name == "Пестов С--" && random.Next(100) < 40)
                {
                    player.Frozen = true;
                    Console.WriteLine("Заморозка!");
                }

                else if (random.Next(100) < 25)
                {
                    player.Frozen = true;
                    Console.WriteLine("Заморозка!");
                }
            }

            if (enemy.Type != "Скелет" && !(enemy.Type == "Гоблин" && damage > enemy.Attack))
            {
                damage = Math.Max(1, damage - player.Defense);
            }

            player.HP -= damage;
            Console.WriteLine($"{enemy.Name} наносит {damage} урона");

        }
    }
    static void FightEnemy(Player player)
    {
        Enemy enemy = CreateEnemy();
        Console.WriteLine($"{enemy.Name} (HP: {enemy.HP}, Атака: {enemy.Attack})");
        Fight(player, enemy);
    }



}