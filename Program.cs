using System;

namespace consoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Welcom to the Game");
            Console.SetCursorPosition(25, 1);
            Console.WriteLine("Collect all '+' in your backpack to win.");

            Console.CursorVisible = false;
            char[,] map =
            {
                {'_','_', '_','_','_', '_','_', '_','_','_','_','_', '_','_','_','_','_', '_','_','_','_','_' },
                {'|',' ', ' ',' ',' ', '|',' ',' ','|',' ', ' ',' ',' ', '|',' ',' ','|',' ', ' ',' ',' ', '|' },
                {'|','+', ' ',' ',' ', '|',' ',' ',' ',' ', ' ',' ','+', '|',' ','+',' ',' ', ' ',' ',' ', '|'},
                {'|',' ', ' ',' ',' ', '|','+',' ','|',' ', ' ','_','_', '|','_','_','|',' ', '+',' ',' ', '|'},
                {'|',' ', ' ',' ',' ', '|','_','_','|',' ', ' ',' ',' ', '|',' ',' ','|',' ', ' ',' ',' ', '|' },
                {'|',' ', ' ',' ',' ', ' ',' ',' ','|',' ', ' ',' ',' ', ' ',' ',' ','|',' ', ' ',' ',' ', '|' },
                {'|','_', '_',' ',' ', ' ',' ',' ',' ',' ', ' ',' ',' ', '|',' ',' ','|','_', ' ',' ','_', '|' },
                {'|','+', ' ',' ',' ', '_','_','_','|',' ', ' ',' ',' ', '|',' ',' ',' ',' ', ' ',' ',' ', '|' },
                {'|',' ', ' ',' ',' ', '|',' ',' ','|',' ', ' ',' ',' ', '|',' ',' ',' ',' ', ' ',' ',' ', '|' },
                {'|',' ', ' ',' ',' ', ' ',' ','+','|',' ', ' ',' ',' ', '|',' ',' ',' ',' ', '+',' ',' ', '|' },
                {'|','_', '_','_','_', '|','_','_','|','_','_','_', '_', '|','_','_','_', '_','_','_','_', '|' },
            };

            int userX = 6, userY = 10;
            char[] backpack = new char[1];

            while (true)
            {
                Console.SetCursorPosition(25, 5);
                Console.Write("Backpack - ");
                for (int i = 0; i < backpack.Length; i++)
                    Console.Write(backpack[i] + " ");
               

                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.SetCursorPosition(userY, userX);
                Console.Write('*');
                ConsoleKeyInfo charKey = Console.ReadKey();
                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[userX - 1, userY - 1] != '_' && map[userX - 1, userY - 1] != '|')
                            userX--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[userX + 1, userY + 1] != '_' && map[userX + 1, userY + 1] != '|')
                            userX++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map[userX, userY - 1] != '_' && map[userX, userY - 1] != '|')
                            userY--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[userX, userY + 1] != '_' && map[userX, userY + 1] != '|')
                            userY++;
                        break;
                }
                if (map[userX, userY] == '+')
                {
                    map[userX, userY] = ' ';
                    char[] tempBackpack = new char[backpack.Length + 1];
                    for (int i = 0; i < backpack.Length; i++)
                    {
                        backpack[i] = tempBackpack[i];
                        tempBackpack[i] = '+';
                    }
                    backpack = tempBackpack;
                }
                if (backpack.Length >= 9)
                {
                    Console.SetCursorPosition(25, 10);
                    Console.WriteLine("Game over :)");
                    Console.SetCursorPosition(0, 15);
                    return;
                }
            }
        }
    }
}