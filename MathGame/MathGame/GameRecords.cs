
public class GameRecords
{
    List<string> records = new List<string>();

    public void AddScore(string score)
    {
        records.Add(score);
    }

    public void PrintScores()
    {
        Console.WriteLine("\nYour previous scores:\n");

        if (records.Count > 0)
        {
            foreach (var score in records)
            {
                Console.WriteLine($"- {score}");
            }
        }
        else
        {
            Console.WriteLine($"No previous game score has been recorded yet.");
        }

    }
}