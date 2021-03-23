using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            World world = new World();
            bool running = true;
            while (running)
            {
                
                world.DrawWorld();
                
                switch (SelectMenu("Beschikbaare Opties",world))
                {
                    case "Move Up": world.MoveUp();
                        break;
                    case "Move Down":world.MoveDown();
                        break;
                    case "Move Left":world.MoveLeft();
                        break;
                    case "Move Right":world.MoveRight();
                        break;

                    default:
                        break;

                }
                
            }
            
        }
        static string SelectMenu(string message, World world)
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
           
            string[] opties = new string[AmountOptions(world)];
            
            if (world.CanMoveUp())
            {
                for (int i = 0; i < opties.Length; i++)
                {
                    if (opties[i] == null)
                    {
                        opties[i] = "Move Up";
                        break;
                    }
                }
            }
            if (world.CanMoveDown())
            {
                for (int i = 0; i < opties.Length; i++)
                {
                    if (opties[i] == null)
                    {
                        opties[i] = "Move Down";
                        break;
                    }
                }
            }
            if (world.CanMoveLeft())
            {
                for (int i = 0; i < opties.Length; i++)
                {
                    if (opties[i] == null)
                    {
                        opties[i] = "Move Left";
                        break;
                    }
                }
            }
            if (world.CanMoveRight())
            {
                for (int i = 0; i < opties.Length; i++)
                {
                    if (opties[i] == null)
                    {
                        opties[i] = "Move Right";
                        break;
                    }
                }
            }

            int selection = 1;
            bool selected = false;
            ConsoleColor selectionForeground = Console.BackgroundColor;
            ConsoleColor selectionBackground = Console.ForegroundColor;

            while (!selected)
            {
                Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, 11);
                Console.WriteLine(message);
                //write Opties
                for (int i = 0; i < opties.Length; i++)
                {
                    if (selection == i + 1)
                    {
                        Console.ForegroundColor = selectionForeground;
                        Console.BackgroundColor = selectionBackground;
                    }
                    Console.SetCursorPosition((Console.WindowWidth - opties[i].Length) / 2, Console.CursorTop);
                    Console.WriteLine((opties[i]));
                    Console.ResetColor();
                }
                

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selection--;
                        break;
                    case ConsoleKey.DownArrow:
                        selection++;
                        break;
                    case ConsoleKey.Enter:
                        selected = true;
                        break;
                }

                selection = Math.Min(Math.Max(selection, 1), opties.Length);
                
                
            }

            
            Console.CursorVisible = true;
            Console.Clear();
            return opties[selection - 1];
        }
        static int AmountOptions(World world)
        {
            int counter = 0;
            if (world.CanMoveUp())
            {
                counter++;
            }
            if (world.CanMoveDown())
            {
                counter++;
            }
            if (world.CanMoveLeft())
            {
                counter++;
            }
            if (world.CanMoveRight())
            {
                counter++;
            }
            return counter;
        }
    }
}
