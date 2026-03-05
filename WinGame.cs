public class WinGame
{
    public int QuestCounter;
    public int CurrentLocation;
    public bool FinalQuestStarted;

    private int finalAreaID = 9; // spider forest

    public WinGame(int questCounter, int currentLocation)
    {
        QuestCounter = questCounter;
        CurrentLocation = currentLocation;
        FinalQuestStarted = false;
    }

    public void CheckRequirements()
    {
        // laat prompt zien als:
        // 1. Player moet 3 quests gedaan hebben
        // 2. Player in het laatste gebied is
        // 3. Player de laatste quest nog niet geactiveerd heeft
        if (QuestCounter >= 3 && CurrentLocation == finalAreaID && FinalQuestStarted == false)
        {
            GiveFinalQuestPrompt();
        }
    }

    private void GiveFinalQuestPrompt()
    {
        Console.WriteLine("You have reached the final area. Do you want to start the final quest? (yes/no)");

        string answer = Console.ReadLine();

        if (answer == "yes")
        {
            StartFinalQuest();
        }
        else
        {
            Console.WriteLine("You decide to wait and get stronger.");
        }
    }

    private void StartFinalQuest()
    {
        FinalQuestStarted = true;
        Console.WriteLine("The final quest begins!");
        // rest van de final quest logic moet hier
    }
}
