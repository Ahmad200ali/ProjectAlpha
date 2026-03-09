public class Monster
{
    public Player player;
    public int ID;
    public string? Name;
    public int Damage;
    public int Max_health;
    public int Current_health;

    public Monster(int id, string name, int damage, int max_health, int current_health, Player? player = null)
    {
        ID = id;
        Name = name;
        Damage = damage;
        Max_health = max_health;
        Current_health = current_health;
        this.player = player;
    }

    public bool Battle(Player player)
    {
        this.player = player;
        
        while (this.Current_health > 0 && player.IsAlive())
        {
            Console.WriteLine($"\nYOUR HP: {player.CurrentHitPoints}/{player.MaximumHitPoints}");
            Console.WriteLine($"MONSTER HP: {this.Current_health}");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Flee");
            Console.Write("Choice: ");
            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                // Player attacks
                int damage = player.CurrentWeapon.MaximumDamage;
                this.Current_health -= damage;
                Console.WriteLine($"\nYou attack with your {player.CurrentWeapon.Name}!");
                Console.WriteLine($"You deal {damage} damage!");

                if (this.Current_health <= 0)
                {
                    Console.WriteLine($"\nYou defeated the {this.Name}!");
                    return true; // Player wins
                }

                // Monster attacks
                Console.WriteLine($"\nThe {this.Name} attacks you!");
                player.TakeDamage(this.Damage);
                Console.WriteLine($"The monster deals {this.Damage} damage!");
                Console.WriteLine($"You now have {player.CurrentHitPoints} HP.");
            }
            else if (choice == "2")
            {
                Console.WriteLine($"\nYou flee from the {this.Name}!");
                return false;
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }

        return player.IsAlive();
    }
}

