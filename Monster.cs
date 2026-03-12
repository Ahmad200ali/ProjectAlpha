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

    public bool Fight(){
        Console.WriteLine($"You are fighting a {Name}. It has {Current_health} health points");
        Console.WriteLine("Pick an option:");
        Console.WriteLine("(1) attack");
        Console.WriteLine("(2) flee");
        string? choice = Console.ReadLine();

        if(choice is "1" || choice is "attack")
        {
            playerAttack();
            return true;
        }
        else if(choice is "2" || choice is "flee")
        {
            flee();
            return false;
        }
        Console.WriteLine("You didn't pick a correct option!");
        return Fight();
    }

    public void flee()
    {
        Console.WriteLine($"You flee the {Name}");
    }

    public void playerAttack()
    {
        int weapon_damage = player.CurrentWeapon.MaximumDamage;
        Current_health -= weapon_damage;
        Console.WriteLine($"The monster now has {Current_health} health points");
        if(Current_health < 1)
        {
            death();
        }
        else
        {
            monsterAttack();
        }
    }

    public void monsterAttack()
    {
        if (player == null)
        {
            Console.WriteLine("No player to attack!");
            return;
        }
        
        player.TakeDamage(this.Damage);
        
        if (player.IsAlive())
        {    
            Console.WriteLine($"The monster hits you and deals {Damage} damage! You now have {player.CurrentHitPoints} health points.");
            Fight();        
        }
        else
        {
            Console.WriteLine($"The monster hits you and deals {Damage} damage! You have no health left. You are dead.");
        }
    }

    public void death()
    {
        Console.WriteLine($"you defeat the {Name}");
        //TODO: trigger quest kill counter
    }
}
