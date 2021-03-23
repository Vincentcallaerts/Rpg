using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class World
    {
        private Entity[,] map = new Entity[10,10];
        private Entity heroMovedOntop;
        private Hero myHero;

        public Hero MyHero
        {
            get { return myHero; }
            set { myHero = value; }
        }

        public Random Random { get; set; }

        public World()
        {
            Random = new Random();
            myHero = new Hero();
            FillSidesWithRocks();
            FillSidesWithTrees();
            DropHero();
        }
        public Entity PlayerMovedOntop
        {
            get { return heroMovedOntop; }
            set { heroMovedOntop = value; }
        }

        public Entity[,] Map
        {
            get { return map; }
            set { map = value; }
        }
        public void DropHero() 
        {
            int x = Random.Next(1, 9);
            int y = Random.Next(1, 9);
            heroMovedOntop = map[x, y];
            map[x, y] = myHero;
            myHero.X = x;
            myHero.Y = y;
        }
        public void FillSidesWithTrees()
        {
            //bovenste rij stenen maken
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i != 0 && j != 0 && i != 9 && j != 9 )
                    {
                        map[i, j] = new Tree();
                    }
                }
            }
        }
        public void FillSidesWithRocks()
        {
            //bovenste rij stenen maken
            for (int i = 0; i < 10; i++)
            {
                map[0, i] = new Rock("▼");
            }
            //zijkanten
            for (int i = 0; i < 10; i++)
            {
                map[i, 0] = new Rock("►");
                map[i, 9] = new Rock("◄");
            }
            //onderste rij stenen maken
            for (int i = 0; i < 10; i++)
            {
                map[9, i] = new Rock("▲");
            }
        }
        public bool CanMoveUp()
        {
            return (map[myHero.X-1,myHero.Y].Naam != "Steen");
        }
        public bool CanMoveDown()
        {
            return (map[myHero.X + 1, myHero.Y].Naam != "Steen");
        }
        public bool CanMoveLeft()
        {
            return (map[myHero.X, myHero.Y -1].Naam != "Steen");
        }
        public bool CanMoveRight()
        {
            return (map[myHero.X, myHero.Y + 1].Naam != "Steen");
        }
        public void CanMoveHere()
        {
            Console.WriteLine("Omhoog bewegen: " + CanMoveUp());
            Console.WriteLine("Naar beneden bewegen: " + CanMoveDown());
            Console.WriteLine("Naar links bewegen: " + CanMoveLeft());
            Console.WriteLine("Naar rechts bewegen: " + CanMoveRight());
        }
        public void MoveUp()
        {       
            map[myHero.X, myHero.Y] = heroMovedOntop;
            myHero.X -= 1;
            map[myHero.X, myHero.Y] = myHero;            
        }
        public void MoveDown()
        {
            
            map[myHero.X, myHero.Y] = heroMovedOntop;
            myHero.X += 1;
            map[myHero.X, myHero.Y] = myHero;
            
        }
        public void MoveLeft()
        {
            
            map[myHero.X, myHero.Y] = heroMovedOntop;
            myHero.Y -= 1;
            map[myHero.X, myHero.Y] = myHero;
            
        }
        public void MoveRight()
        {
           
            map[myHero.X, myHero.Y] = heroMovedOntop;
            myHero.Y += 1;
            heroMovedOntop = map[myHero.X, myHero.Y];
            map[myHero.X, myHero.Y] = myHero;
            
        }
        public void DrawWorld()
        {
            
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - 30) / 2, i);
                for (int j = 0; j < 10; j++)
                {
                    
                    Console.Write((" "));
                    //ColorCode
                    switch (map[i, j].Teken)
                    {
                        case "♀":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case "►":                                                       
                        case "◄":
                        case "▲":
                        case "▼":
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            break;
                        case "♣":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        default:
                            break;
                    }
                    Console.Write(($"{map[i, j].Teken}"));
                    Console.Write((" "));
                    Console.ResetColor();
                }
                Console.WriteLine();
            }   
            
        }
    }
}
