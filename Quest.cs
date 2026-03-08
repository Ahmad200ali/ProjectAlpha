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

        
        while (KillCount < RequiredKillCount && player.IsAlive())
        {
            // Maak een nieuw monster aan voor elke gevecht (reset health)
            Monster enemy = new Monster(
                monsterTarget.ID,
                monsterTarget.Name,
                monsterTarget.Damage,
                monsterTarget.Max_health,
                monsterTarget.Max_health,
                player
            );

            Console.WriteLine($"\nA wild {enemy.Name} appears!");
            
           
            bool playerWon = true;

            if (playerWon)
            {
                KillCount++;
                Console.WriteLine($"\n[{enemy.Name} killed: {KillCount}/{RequiredKillCount}]");
                
                if (player.CurrentHitPoints < player.MaximumHitPoints / 2)
                {
                    Console.WriteLine($"Warning: You have {player.CurrentHitPoints} HP remaining!");
                }
            }
            else
            {
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

    public void CompleteQuest(Player player)
    {
        IsCompleted = true;
        Console.WriteLine($"\n=== QUEST COMPLETED: {Name} ===");
        Console.WriteLine("Congratulations! You have completed the quest!");
    }
}

