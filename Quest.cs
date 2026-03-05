public class Quest
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public bool IsCompleted { get; set; }

    public Quest(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;
        IsCompleted = false;
    }

    public void CompleteQuest()
    {
        IsCompleted = true;
    }
}