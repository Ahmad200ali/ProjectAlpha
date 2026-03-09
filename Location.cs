public class Location
{
    //fields

    public int ID;
    public string Name;
    public string Description;

    //constructor
    public Location(int location_id, string location_name, string location_description, int? x = null, int? y = null)
    {
        this.ID = location_id;
        this.Name = location_name;
        this.Description = location_description;
    }

    public Quest? QuestAvailableHere { get; set; }

    public Monster? MonsterLivingHere { get; set; }
    public Location? LocationToNorth { get; set; }
    public Location? LocationToEast { get; set; }
    public Location? LocationToSouth { get; set; }
    public Location? LocationToWest { get; set; }

    public string Compass()
    {
        string output = "";
        if (LocationToNorth != null)
        {
            output += $"N - {LocationToNorth.Name}\n";
        }
        if (LocationToEast != null)
        {
            output += $"E - {LocationToEast.Name}\n";
        }
        if (LocationToSouth != null)
        {
            output += $"S - {LocationToSouth.Name}\n";
        }
        if (LocationToWest != null)
        {
            output += $"W - {LocationToWest.Name}\n";
        }
        return output;
    }

    public Location? GetLocationAt(string? direction)
    {
        if (string.IsNullOrWhiteSpace(direction))
            return null;

        direction = direction.Trim().ToUpper();

        return direction switch
        {
            "N" => LocationToNorth,
            "E" => LocationToEast,
            "S" => LocationToSouth,
            "W" => LocationToWest,
            _ => null
        };
    }
}
