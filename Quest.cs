public class Quest
{
    public int ID;
    public Monster monsterTarget;
    public string Name;
    public string Description;
    public bool IsCompleted;
    public bool IsActive;
    public int KillCount = 0;
    public int RequiredKillCount = 3;
    public int FightingLocationID;
    
    public Quest(int id, string name, string description, int fightingLocationID, Monster monster)
    {
        ID = id;
        Name = name;
        Description = description;
        IsCompleted = false;
        IsActive = false;
        KillCount = 0;
        FightingLocationID = fightingLocationID;
        monsterTarget = monster;
    }
    
    public void StartQuest(Player player)
    {
        if (IsCompleted)
        {
            Console.WriteLine("This quest has already been completed!");
            return;
        }

        if (IsActive)
        {
            Console.WriteLine("You are already working on this quest.");
            return;
        }

        IsActive = true;

        // Breng speler naar vechtlocatie
        Player.CurrentLocation = World.LocationByID(FightingLocationID);

        Console.WriteLine($"\n=== QUEST: {Name} ===");
        Console.WriteLine(Description);
        Console.WriteLine($"Your goal: Kill {RequiredKillCount} {monsterTarget.Name}(s)");
        Console.WriteLine($"Location: {Player.CurrentLocation.Location_name}\n");

        // Vecht totdat je RequiredKillCount monsters hebt verslagen of speler dood gaat
        while (KillCount < RequiredKillCount && player.IsAlive())
        {
            // Maak een nieuw monster aan voor elke gevecht (reset health)
            Monster enemy = new Monster(
                monsterTarget.ID,
                monsterTarget.Name,
                monsterTarget.Damage,
                monsterTarget.Max_health,
                monsterTarget.Max_health
            );

            Console.WriteLine($"\nA wild {enemy.Name} appears!");
            
            // Start gevecht met het monster
            bool playerWon = FightMonster(player, enemy);

            if (playerWon)
            {
                KillCount++;
                Console.WriteLine($"\n[{enemy.Name} killed: {KillCount}/{RequiredKillCount}]");
                
                // Check of speler health heeft recovery nodig tussen gevechten
                if (player.CurrentHitPoints < player.MaximumHitPoints / 2)
                {
                    Console.WriteLine($"Warning: You have {player.CurrentHitPoints} HP remaining!");
                }
            }
            else
            {
                // Speler is gevlucht of verloren
                Console.WriteLine("\nQuest paused. You can try again when you're stronger.");
                break;
            }
        }

        if (KillCount >= RequiredKillCount)
        {
            CompleteQuest(player);
        }
        else
        {
            Console.WriteLine("\nQuest not completed. You need more kills.");
        }
    }

    private bool FightMonster(Player player, Monster enemy)
    {
        while (enemy.Current_health > 0 && player.IsAlive())
        {
            Console.WriteLine($"\n{player.Name}: {player.CurrentHitPoints} HP | {enemy.Name}: {enemy.Current_health} HP");
            Console.WriteLine("Choose action:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Flee");
            
            string? choice = Console.ReadLine();

            if (choice == "1" || choice?.ToLower() == "attack")
            {
                // Speler valt aan
                int damage = player.CurrentWeapon.MaximumDamage;
                enemy.Current_health -= damage;
                Console.WriteLine($"You attack with your {player.CurrentWeapon.Name} for {damage} damage!");

                if (enemy.Current_health <= 0)
                {
                    Console.WriteLine($"You defeated the {enemy.Name}!");
                    return true;
                }

                // Monster valt aan
                player.TakeDamage(enemy.Damage);
                Console.WriteLine($"The {enemy.Name} attacks you for {enemy.Damage} damage!");
            }
            else if (choice == "2" || choice?.ToLower() == "flee")
            {
                Console.WriteLine($"You fled from the {enemy.Name}.");
                return false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }

        if (!player.IsAlive())
        {
            Console.WriteLine("You were defeated! Game Over.");
            return false;
        }

        return true;
    }

    public void CompleteQuest(Player player)
    {
        IsCompleted = true;
        Console.WriteLine($"\n=== QUEST COMPLETED: {Name} ===");
        Console.WriteLine("Congratulations! You have completed the quest!");
    }
}

