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
            hunger = hunger - 1;
            
        }

        public void Train()
        {
            Reduceboredom();
            Console.WriteLine(name + "'s boredom decreased to: " + boredom);

        }

        public void CookCurry(string ingredient)
        {
            Curry c1 = new Curry(ingredient);

            if (c1.GetCurryRarity() == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

            }
            else if(c1.GetCurryRarity() == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;

            }

            Console.WriteLine("You made a " + c1.WriteCurryRarity() + " " +  ingredient + " curry!" );
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
