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
    public Weapon? Reward;
    public int GoldReward;
    
    public Quest(int id, string name, string description, int fightingLocationID, Monster monster, Weapon? reward = null, int goldReward = 0)
    {
        ID = id;
        Name = name;
        Description = description;
        IsCompleted = false;
        IsActive = false;
        KillCount = 0;
        FightingLocationID = fightingLocationID;
        monsterTarget = monster;
        Reward = reward;
        GoldReward = goldReward;
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
            ContinueQuest(player);
            return;
        }

        IsActive = true;

        // Bring player to fighting location
        Player.CurrentLocation = World.LocationByID(FightingLocationID);

        Console.WriteLine($"\n=== QUEST: {Name} ===");
        Console.WriteLine(Description);
        Console.WriteLine($"Your goal: Kill {RequiredKillCount} {monsterTarget.Name}(s)");
        Console.WriteLine($"Location: {Player.CurrentLocation.Location_name}\n");

        ContinueQuest(player);
    }
    
    private void ContinueQuest(Player player)
    {
        while (KillCount < RequiredKillCount && player.IsAlive())
        {
            // Create a new monster for fight
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
                Console.WriteLine("\nYou fled from the monster. Quest paused.");
                break;
            }
        }

        if (KillCount >= RequiredKillCount)
        {
            CompleteQuest(player);
        }
        else if (player.IsAlive())
        {
            Console.WriteLine("\nQuest not completed. You need more kills.");
        }
    }

    public void CompleteQuest(Player player)
    {
        IsCompleted = true;
        IsActive = false;
        World.HowManyQuestCompleted.Add(this);
        Console.WriteLine($"\n=== QUEST COMPLETED: {Name} ===");
        Console.WriteLine("Congratulations! You have completed the quest!");
        
        // Give rewards
        if (GoldReward > 0)
        {
            player.Gold += GoldReward;
            Console.WriteLine($"You received {GoldReward} gold!");
        }
        
        if (Reward != null)
        {
            Console.WriteLine($"You received a new weapon: {Reward.Name} ({Reward.MaximumDamage} damage)!");
            player.CurrentWeapon = Reward;
        }
    }
}

