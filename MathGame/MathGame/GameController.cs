using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class GameController
{
    int bonusTime = 6;
    GameRecords gameRecords = new GameRecords();

    public void StartOperation(char operation)
    {
        switch (operation)
        {
            case '1':
                Console.WriteLine("\nAddition Game!");
                GenerateOperation('+', "Addition");
                break;
            case '2':
                Console.WriteLine("\nSubtraction Game!");
                GenerateOperation('-', "Subtraction");
                break;
            case '3':
                Console.WriteLine("\nMultiplication Game!");
                GenerateOperation('*', "Multiplication");
                break;
            case '4':
                Console.WriteLine("\nDivision Game!");
                GenerateOperation('/', "Division");
                break;
            case '5':
                ViewScoreHistory();
                break;
            case '6':
                Environment.Exit(0);
                break;
        }
    }

    private void GenerateOperation(char operationChar, string operationName)
    {
        ScoreManager scoreManager = new ScoreManager();
        Console.WriteLine($"Each correct answer adds 1 point to the final score. +1 bonus point if you get the answer faster than {bonusTime} seconds.\nPress ENTER to begin the game!\n");
        Console.ReadLine();

        GenerateGameLoop(operationChar, scoreManager);

        int finalScore = scoreManager.GetFinalScore();

        gameRecords.AddScore($"{operationName} game. Score: {finalScore}");

        Console.WriteLine($"Your final score: {finalScore}\n\nPress any key to go back to main menu...");
        Console.ReadKey();
        Console.Clear();
    }

    private void GenerateGameLoop(char operation, ScoreManager scoreManager)
    {

        for (int i = 0; i < 5; i++)
        {
            int operand1 = 0;
            int operand2 = 0;

            int result = 0;

            switch (operation)
            {
                case '+':
                    operand1 = new Random().Next(1, 100);
                    operand2 = new Random().Next(1, 100);
                    result = operand1 + operand2;
                    break;
                case '-':
                    operand1 = new Random().Next(1, 100);
                    operand2 = new Random().Next(1, operand1);
                    result = operand1 - operand2;
                    break;
                case '*':
                    operand1 = new Random().Next(1, 10);
                    operand2 = new Random().Next(1, 10);
                    result = operand1 * operand2;
                    break;
                case '/':
                    operand1 = new Random().Next(1, 100);
                    List<int> factors = new List<int>();

                    for (int j = 1; j <= operand1; j++)
                    {
                        if (operand1 % j == 0)
                            factors.Add(j);
                    }
                    int factorRandom = new Random().Next(0, factors.Count);

                    operand2 = factors[factorRandom];
                    result = operand1 / operand2;
                    break;
            }


            Console.Write($"{operand1} {operation} {operand2} = ");

            scoreManager.StartBonusTimer(bonusTime);

            if (Console.ReadLine() == result.ToString())
            {
                int score = 1;
                string bonusText = "";

                if (scoreManager.GetHasBonus())
                {
                    score++;
                    bonusText = "+1 speed bonus point!";
                }

                Console.WriteLine($"Correct! {bonusText} \n");
                scoreManager.AddScore(score);
            }
            else
            {
                Console.WriteLine($"Incorrect. The answer was {result}\n");
            }

            scoreManager.StopBonusTime();
        }
    }

    private void ViewScoreHistory()
    {
        gameRecords.PrintScores();

        Console.WriteLine($"\nPress any key to go back to the menu");
        Console.ReadKey();
        Console.Clear();
    }
}
