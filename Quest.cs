public class Quest
{
    public int ID;
    public string? Name;
    public string? Description;
    public bool isAlive;
   // public Monster monster;
   public bool isCompleted;
   public int KillCount = 0;
   public int FightLocationID;

    public Quest(int id,string name,string description)
    {
        ID =id;
        Name = name;
        Description =description;   
    }
    public void StartQuest()
    {
        
    }
    public void CompletQuest()
    {
        
    }



}