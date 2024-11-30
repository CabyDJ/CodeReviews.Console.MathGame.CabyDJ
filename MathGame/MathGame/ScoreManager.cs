using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
public class ScoreManager
{
    private static System.Timers.Timer? bonusTimer;
    private int currentPoints = 0;
    private bool hasBonus = false;

    public void AddScore(int points)
    {
        currentPoints += points;
    }

    public void StartBonusTimer(int timeSeconds)
    {
        hasBonus = true;
        int timeMs = timeSeconds * 1000;

        bonusTimer = new System.Timers.Timer(timeMs);
        bonusTimer.Elapsed += CancelBonus;
        bonusTimer.AutoReset = false;
        bonusTimer.Enabled = true;
    }

    public void StopBonusTime()
    {
        if (bonusTimer != null)
            bonusTimer.Enabled = false;
    }

    private void CancelBonus(Object source, ElapsedEventArgs e)
    {
        //Console.WriteLine("\ntoo slow... no bonus for you");
        hasBonus = false;
    }

    public int GetFinalScore()
    {
        return currentPoints;
    }

    public bool GetHasBonus()
    {
        return hasBonus;
    }

}