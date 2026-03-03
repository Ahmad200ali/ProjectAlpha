// this is needed for Location class to work, it is used to set the location of the player when they move
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