using System;
using System.Timers;

Menu menu = new Menu(); 
GameController gameController = new GameController();

do
{
    menu.OpenMainMenu();

    char input = Console.ReadKey().KeyChar;
    Console.Clear();

    gameController.StartOperation(input);
}
while (true);