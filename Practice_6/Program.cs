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
            turn++;
            Console.WriteLine($"\n--- Ход {turn} ---");
            Console.WriteLine($"HP: {player.HP}, Атака: {player.Attack}, Защита: {player.Defense}\n");

            if (player.Frozen)
            {
                Console.WriteLine("Вы заморожены и пропускаете ход!\n");
                player.Frozen = false;
                continue;
            }

            // Каждые 10 ходов - босс
            if (turn % 10 == 0)
            {
                Console.WriteLine("ПОЯВИЛСЯ БОСС\n");
                FightBoss(player);
            }
            // 50% шанс сундук или враг
            else if (random.Next(2) == 0)
            {
                Console.WriteLine("Вы нашли сундук!\n");
                OpenChest(player);
            }
            else
            {
                Console.WriteLine("Появился враг!\n");
                FightEnemy(player);
            }
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
    static void FightBoss(Player player)
    {
        Enemy boss = CreateBoss();
        Console.WriteLine($"БОСС {boss.Name} (HP: {boss.HP}, Атака: {boss.Attack})");
        Fight(player, boss);
    }

    static void OpenChest(Player player)
    {
        int itemType = random.Next(3);

        if (itemType == 0)
        {
            player.HP = 100;
            Console.WriteLine($"Зелье лечения! HP восстановлено \n HP: {player.HP}");
        }

        else if (itemType == 1)
        {
            int newAttack = random.Next(8, 16);

            Console.WriteLine($"Найдено оружие! Атака: {newAttack} (текущая: {player.Attack})");
            Console.Write("Взять? ('д' - Взять): ");
            if (Console.ReadLine() == "д")
            {
                player.Attack = newAttack;
                Console.WriteLine($"Оружие заменено! Новый параметр аттаки: {player.Attack}");
            }
            else
            {
                Console.WriteLine($"Парметр атаки не затронут! Активный параметр атаки: {player.Attack}");
            }


        }

        else
        {
            int newDefense = random.Next(4, 11);
            Console.WriteLine($"Найдена броня! Защита: {newDefense} (текущая: {player.Defense})");
            Console.Write("Взять? ('д' - Взять): ");
            if (Console.ReadLine() == "д")
            {
                player.Defense = newDefense;
                Console.WriteLine($"Броня заменена! Новый параметр брони: {player.Defense}");
            }
            else
            {
                Console.WriteLine($"Параметр брони не затронут! Активный параметр брони: {player.Defense}");
            }
        }
    }



}