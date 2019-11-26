using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    class Tamagotchi
    {
        private int hunger;
        private int boredom;
        private bool isAlive = true;
        public string name;

        public void Feed()
        {
            Console.WriteLine("You feed " + name + " something to eat!");
            Console.WriteLine("It's hunger decreased to: " + hunger);
            hunger = hunger - 2;
            
        }

        public void Train()
        {
            Reduceboredom();
            Console.WriteLine(name + "'s boredom decreased to: " + boredom);

        }

        public void CookCurry(string ingredient)
        {
            string rarity = " ";
            int r = Utils.generator.Next(10);

            if(r == 0)
            {
                rarity = "Legenday";
                Console.ForegroundColor = ConsoleColor.Yellow;

            }
            else if(r > 0 && r < 4)
            {
                rarity = "Rare";
                Console.ForegroundColor = ConsoleColor.Blue;

            }
            else
            {
                rarity = "Common";
                Console.ForegroundColor = ConsoleColor.White;

            }

            Console.WriteLine("You made a " + rarity + " " +  ingredient + " curry!" );
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void Tick()
        {
            boredom++;
            hunger++;

        }

        public void PrintStats()
        {
            Console.WriteLine("Hunger: " + hunger);
            Console.WriteLine("Boredom: " + boredom);

            if(isAlive == true)
            {
                Console.WriteLine(name + " is alive!");

            }
            else {
                Console.WriteLine("Sorry, " + name + " didn't make it. " +
                    "Press enter to continue.");
                Console.ReadLine();
                Program.Gameover();
                
            }

        }

        private void Reduceboredom()
        {

            boredom = boredom - 2;

        }

        public bool GetAlive()
        {
            if(boredom <= 10 && hunger <= 10)
            {
                isAlive = true;
                return true;

            }
            else
            {
                isAlive = false;
                return false;

            }

        }

    }
}
