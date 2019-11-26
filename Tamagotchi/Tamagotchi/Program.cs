using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using RestSharp;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            RestClient client = new RestClient("https://pokeapi.co/api/v2/");

            string userinput;
            List<Curry> currys;
            Tamagotchi tamagotchi1 = new Tamagotchi();            
            Console.WriteLine("Welcome to Pokemon x Tamagotchi 2019! " +
                "Which starter do you want?");

            Console.WriteLine("A: Chikorita");
            Console.WriteLine("B: Cyndaquil");
            Console.WriteLine("C: Totodile");

            tamagotchi1.name = "none";
            while (tamagotchi1.name == "none")
            {
                userinput = Console.ReadLine();
                userinput = userinput.ToLower();

                if (userinput == "a")
                {
                    RestRequest request = new RestRequest("pokemon/chikorita");
                    IRestResponse response = client.Get(request);
                    Pokemon p = JsonConvert.DeserializeObject<Pokemon>(response.Content);
                    tamagotchi1.name = p.name;

                }
                else if (userinput == "b")
                {
                    RestRequest request = new RestRequest("pokemon/cyndaquil");
                    IRestResponse response = client.Get(request);
                    Pokemon p = JsonConvert.DeserializeObject<Pokemon>(response.Content);
                    tamagotchi1.name = p.name;

                }
                else if (userinput == "c")
                {
                    RestRequest request = new RestRequest("pokemon/totodile");
                    IRestResponse response = client.Get(request);
                    Pokemon p = JsonConvert.DeserializeObject<Pokemon>(response.Content);
                    tamagotchi1.name = p.name;

                }
                else
                {
                    Console.WriteLine("Enter a valid input");

                }

            }

            Loading();

            while (tamagotchi1.GetAlive() == true)
            {
                Console.WriteLine("What would you like to do?");
                tamagotchi1.PrintStats();
                Console.WriteLine();

                Console.WriteLine("A: Feed " + tamagotchi1.name);
                Console.WriteLine("B: Train " + tamagotchi1.name);
                Console.WriteLine("C: Cook curry with " + tamagotchi1.name);

                userinput = Console.ReadLine();
                userinput = userinput.ToLower();

                if (userinput == "a")
                {
                    tamagotchi1.Feed();
                    tamagotchi1.Tick();
                    Console.Clear();
                }

                else if (userinput == "b")
                {
                    tamagotchi1.Train();
                    tamagotchi1.Tick();
                    Console.Clear();
                }

                else if (userinput == "c")
                {

                    Console.WriteLine("What should the main ingredient be?");
                    string ingredient = Console.ReadLine();
                    tamagotchi1.CookCurry(ingredient);
                    Console.Clear();
                }

                else
                {
                    Console.WriteLine("Please enter a valid action!");
                    
                }

            }

            Console.Clear();
            Gameover();


            Console.ReadLine();
        }

        public static void Gameover()
        {

            Console.WriteLine("Game over");

        }

        public static void Loading()
        {
            Console.Clear();
            Console.WriteLine("Loading");
            Console.Write(". ");
            Thread.Sleep(300);
            Console.Write(". ");
            Thread.Sleep(300);
            Console.Write(". ");
            Thread.Sleep(300);
            Console.Clear();

        }

    }
}
