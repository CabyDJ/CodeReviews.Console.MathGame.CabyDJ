using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

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