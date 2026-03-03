public class Player
{
    public static Location? PlayerLocation;

    public Player(Location startingLocation)
    {
        PlayerLocation = startingLocation;
    }

    public static void SetLocation(Location newLocation)
    {
        PlayerLocation = newLocation;
    }
}