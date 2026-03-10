public class Location
{
    //fields

    public int ID;
    public string Location_name;
    public string Location_description;
    public int? X;
    public int? Y;

    //constructor
    public Location(int location_id, string location_name, string location_description, int? x, int? y)
    {
        this.ID = location_id;
        this.Location_name = location_name;
        this.Location_description = location_description;
        this.X = x;
        this.Y = y;
    }

    public Quest? QuestAvailableHere { get; set; }

    public Monster? MonsterLivingHere { get; set; }

    public Location? LocationToNorth { get; set; }
    public Location? LocationToEast { get; set; }
    public Location? LocationToSouth { get; set; }
    public Location? LocationToWest { get; set; }

    public void MoveLocation(string loc)
    {
        // Move location menu
        Console.WriteLine("Where would you like to go?");
        Console.WriteLine($"You are at {Location_name}. From here you can go:");

        // check if location to direction excists
        if (LocationToNorth != null)
        {
            Console.WriteLine($"N. {LocationToNorth.Location_name}");
        }
        if (LocationToEast != null)
        {
            Console.WriteLine($"E. {LocationToEast.Location_name}");
        }
        if (LocationToSouth != null)
        {
            Console.WriteLine($"S. {LocationToSouth.Location_name}");
        }
        if (LocationToWest != null)
        {
            Console.WriteLine($"W. {LocationToWest.Location_name}");
        }

        string? movedirection = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(movedirection))
        {
            movedirection = movedirection.Trim().ToUpper();
            Location? destination = null;

            if (movedirection == "N" && LocationToNorth != null)
            {
                destination = LocationToNorth;
            }
            else if (movedirection == "E" && LocationToEast != null)
            {
                destination = LocationToEast;
            }
            else if (movedirection == "S" && LocationToSouth != null)
            {
                destination = LocationToSouth;
            }
            else if (movedirection == "W" && LocationToWest != null)
            {
                destination = LocationToWest;
            }

            if (destination != null)
            {
                Player.SetLocation(destination);
                Console.WriteLine($"you moved to: {destination.Location_name}, {destination.Location_description}");
            }
            else
            {
                Console.WriteLine("Invalid direction, try again.");
            }
        }
    }
}