class Program
{
    public static void Main()
    {
        // Create player
        Player player = new Player("Theoberto the third", World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD), World.LocationByID(World.LOCATION_ID_HOME));

        Intro(player);
        bool game = true;

        HashSet<Location> HowManyLocationsVisited = new HashSet<Location>();
        HowManyLocationsVisited.Add(World.LocationByID(World.LOCATION_ID_HOME));

        while (game == true)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("[M]ove");
            Console.WriteLine("[Q]uests");
            Console.WriteLine("[P]layer Stats");
            Console.WriteLine("[E]xit");

            HowManyLocationsVisited.Add(Player.CurrentLocation);

            Console.Write("> ");
            string? input = Console.ReadLine()?.ToUpper();
            switch (input)
            {
                
                case "M":
                    Console.Clear();
                    Console.WriteLine("\n" + Player.CurrentLocation.Compass());
                    Console.Write("Enter direction (N/E/S/W): ");
                    string? dir = Console.ReadLine()?.ToUpper();
                    if (TryMoveTo(Player.CurrentLocation.GetLocationAt(dir), player))
                    {
                        Console.WriteLine($"\nYou arrive at {Player.CurrentLocation.Name}.\n{Player.CurrentLocation.Description}");
                        HandleMonsterEncounter(player);
                    }
                    else if (ValidInputMovement(dir))
                    {
                        Console.WriteLine("\nYou can’t go there. Turn back");
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input");
                    }
                    break;

                case "Q":
                    Console.Clear();
                    if (Player.CurrentLocation.QuestAvailableHere != null)
                    {
                        Quest questHere = Player.CurrentLocation.QuestAvailableHere;

                        if (!questHere.IsActive && !questHere.IsCompleted)
                        {
                            Console.WriteLine($"\nQuest available: {questHere.Name}");
                            Console.WriteLine(questHere.Description);
                            Console.WriteLine("Do you want to start this quest? [Y/N]");

                            Console.Write("> ");
                            string choice = Console.ReadLine()?.ToUpper();
                            if (choice == "Y")
                            {
                                questHere.StartQuest(player);
                            }
                            else
                            {
                                Console.WriteLine("\nYou decided not to start the quest now.");
                            }
                        }
                        else if (questHere.IsActive)
                        {
                            Console.WriteLine($"\nYou are already working on this quest: {questHere.Name}");
                            Console.WriteLine($"Progress: {questHere.KillCount}/{questHere.RequiredKillCount}");
                            Console.WriteLine("Continuing quest...");
                            questHere.StartQuest(player);
                        }
                        else if (questHere.IsCompleted)
                        {
                            Console.WriteLine($"\nYou have already completed this quest: {questHere.Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo quests available here.");
                    }
                    break;

                case "P":
                    Console.Clear();
                    Console.WriteLine($"\nPlayer: {player.Name}");
                    Console.WriteLine($"Health: {player.CurrentHitPoints}/{player.MaximumHitPoints}");
                    Console.WriteLine($"Gold: {player.Gold}");
                    Console.WriteLine($"Weapon: {player.CurrentWeapon.Name} ({player.CurrentWeapon.MaximumDamage} dmg)");
                    Console.WriteLine($"Locations visited: {HowManyLocationsVisited.Count}/9");
                    Console.WriteLine($"Quest completed: {World.HowManyQuestCompleted.Count}/3\n");
                    break;
                    
                case "E":
                    Console.Clear();
                    return;

                default:
                    Console.WriteLine("Invalid choice, try again.\n");
                    break;
            }

            // Check win condition
            if (HowManyLocationsVisited.Count == 9 && World.HowManyQuestCompleted.Count == 3)
            {
                break;
            }
        }

        Outro(player);
    }

    public static void Intro(Player player)
    {
        Console.WriteLine("====================================");
        Console.WriteLine("       Welcome to the Adventure!");
        Console.WriteLine("====================================\n");

        Console.WriteLine($"You are {player.Name}, a young adventurer.");
        Console.WriteLine("For years you have lived quietly in your small home,");
        Console.WriteLine("but lately rumors have spread of monsters lurking nearby,");
        Console.WriteLine("and quests that only the brave can complete.\n");

        Console.WriteLine("One morning, you wake up, pick up your rusty sword,");
        Console.WriteLine("and decide it's time to make your mark on the world.\n");

        Console.WriteLine($"You stand at {Player.CurrentLocation.Name}.");
        Console.WriteLine($"{Player.CurrentLocation.Description}\n");

        Console.WriteLine("Your journey begins here...");
    }

    public static void Outro(Player player)
    {
        Console.WriteLine($"\n{player.Name} wins the game! Thank you for playing!");
    }

    public static bool TryMoveTo(Location NewLocation, Player player)
    {
        if (NewLocation == null) { return false; }
        Player.CurrentLocation = NewLocation;
        return true;
    }

    public static bool ValidInputMovement(string input)
    {
        switch (input)
        {
            case "N":
                return true;
            case "E":
                return true;
            case "S":
                return true;
            case "W":
                return true;
            default:
                return false;
        }
    }

    static void HandleMonsterEncounter(Player player)
    {
        Monster monster = Player.CurrentLocation.MonsterLivingHere;
        if (monster == null) return;

        Console.WriteLine($"A wild {monster.Name} appears!");
  
        bool playerWon = monster.Battle(player);
        
        if (playerWon)
        {
            Console.WriteLine($"You defeated {monster.Name}!");
            // Remove monster from location after defeat
            Player.CurrentLocation.MonsterLivingHere = null;
        }
        else
        {
            Console.WriteLine($"{player.Name} died tragically fighting {monster.Name}! GAME OVER.");
        }
    }
}

