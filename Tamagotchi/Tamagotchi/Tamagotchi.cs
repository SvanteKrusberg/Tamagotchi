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
        private int level = 1;
        public int experiencePoints;
        public int requiredExp;
        private bool isAlive = true;
        public string name;

        //En metod som matar tamagotchin/pokemonen
        public void Feed()
        {
            Console.WriteLine("You feed " + name + " something to eat!");
            if(hunger <= 1)
            {
                hunger = 0;
            }
            else
            {
                hunger = hunger - 2;
            }
            
            Console.WriteLine(name + "'s hunger decreased to: " + hunger);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press enter to continue:");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadLine();
            Console.Clear();

        }

        //En metod som tränar tamagotchin/pokemonen
        public void Train()
        {
            int rExp = Utils.generator.Next(200, 400);
            hunger++;

            Console.WriteLine(name + " got " + rExp + " experince points but it's hunger increased to: " + hunger 
                + "!");

        }

        //En metod där man lagar en curry!
        public void CookCurry(string ingredient)
        {
            Curry c1 = new Curry(ingredient);

            if (c1.GetCurryRarity() == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Reduceboredom();
                Reduceboredom();
                Reduceboredom();

            }
            else if (c1.GetCurryRarity() == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Reduceboredom();
                Reduceboredom();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Reduceboredom();

            }

            Console.WriteLine("You made a " + c1.WriteCurryRarity() + " " + ingredient + " curry!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(name + "'s boredom decreased to: " + boredom);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press enter to continue:");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadLine();
            Console.Clear();
            

        }

        //En metod som körs varje gång spelaren gör ett beslut, vilket leder till att spelaren faktiskt behöver göra något
        public void Tick()
        {
            boredom++;
            hunger++;

        }

        public void PrintStats()
        {
            Console.WriteLine("Hunger: " + hunger);
            Console.WriteLine("Boredom: " + boredom);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Exp: " + experiencePoints);


            if (isAlive == true)
            {
                Console.WriteLine(name + " is alive!");

            }
            else
            {
                Console.WriteLine("Sorry, " + name + " didn't make it. " +
                    "Press enter to continue.");
                Console.ReadLine();
                Program.Gameover();

            }

        }

        private void Reduceboredom()
        {
            if (boredom <= 1)
            {
                boredom = 0;

            }
            else
            {
                boredom = boredom - 2;

            }
            

        }

        public int GetLevel()
        {
            return level;
        }

        public void LevelUp()
        {
            level++;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("LV UP!");


        }

        public bool GetAlive()
        {
            if (boredom <= 10 && hunger <= 10)
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
