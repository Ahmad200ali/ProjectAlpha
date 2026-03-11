public class Player
{
    public string Name;
    public int CurrentHitPoints;
    public int MaximumHitPoints;
    public int Gold;

    public Weapon CurrentWeapon;

    public static Location CurrentLocation;

    public Player(string name, Weapon currentweapon, Location currentlocation)
    {
        Name = name;
        CurrentHitPoints = 100;
        MaximumHitPoints = 100;
        Gold = 0;
        CurrentLocation = currentlocation;
        CurrentWeapon = currentweapon;
    }

    public bool IsAlive()
    {
        if (this.CurrentHitPoints <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHitPoints -= damage;
    }

    public void HealHP(int amount)
    {
        CurrentHitPoints += amount;
        if (CurrentHitPoints > MaximumHitPoints)
        {
            CurrentHitPoints = MaximumHitPoints;
        }
    }
    public static void SetLocation(Location newLocation)
    {
        CurrentLocation = newLocation;
        
    }
}

