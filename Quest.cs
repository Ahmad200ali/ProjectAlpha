public class Quest
{
    public int ID;
    public string? Name;
    public string? Description;
    public bool IsAlive;
   // public Monster monster;
   public bool IsCompleted;
   public int KillCount = 0;
   public int FightLocationID;

    public Quest(int id,string name,string description,int fightLocationID , Monster monster)
    {
        ID =id;
        Name = name;
        Description = description;
        FightLocationID = fightLocationID;
        IsAlive = false;
        KillCount = 0;
           
    }
    public void StartQuest()
    {
        
    }
    public void CompletQuest()
    {
        
    }



}