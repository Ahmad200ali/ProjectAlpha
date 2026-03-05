public class Player
{
    public string Name;
    public int CurrentHitPoints;
    public int MaximumHitPoints;

    //public Weapon CurrentWeapon;

    public Location CurrentLocation;

    public Player(string name, int currentweapon, Location currentlocation)
    {
        Name = name;
        CurrentHitPoints = 100;
        MaximumHitPoints = 100;
        CurrentLocation = currentlocation;
        currentweapon = 0;
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

}