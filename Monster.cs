using Microsoft.Win32.SafeHandles;

public class Monster
{
    public int ID;
    public string? Name;
    public int Damage;
    public int Max_health;
    public int Current_health;
    public Monster(int id, string name, int damage, int max_health, int current_health)
    {
       ID = id;
       Name = name;
       Damage = damage;
       Max_health = max_health;
       Current_health = current_health;
    }

    public void fight(){
        Console.WriteLine($"You are fighting a {Name}. It has {Current_health} health points");
        Console.WriteLine("Pick an option:");
        Console.WriteLine("(1) attack");
        Console.WriteLine("(2) flee");
        string? choice = Console.ReadLine();

        if(choice is "1" || choice is "attack")
        {
            attack();
        }
        else if(choice is "2" || choice is "flee")
        {
            flee();
        }

        //add logic where the monster attacks the player
    }

    public void flee()
    {
        Console.WriteLine($"You flee the {Name}");
    }

    public void attack()
    {
        //do damage of player weapon to monster
        Console.WriteLine($"The monster now has {Current_health}");
        if(Max_health < 1)
        {
            death();
        }
        else
        {
            fight();
        }
    }

    public void death()
    {
        Console.WriteLine($"you defeat the {Name}");
        //somehow trigger quest kill counter
    }
}