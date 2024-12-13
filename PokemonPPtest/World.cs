using System.ComponentModel.Design;
using System.Linq;

namespace PokemonPPtest;

public class World
{
    private PokemonManager prog = new PokemonManager();
    private Random Rand = new Random();
    List<Pokemon> StartPokemonSelection = new List<Pokemon>()
    {
        new Pokemon("Pika", 3, 210, 60, "Electric"),
        new Pokemon("Bulba", 4, 150, 22, "Grass"),
        new Pokemon("Charmander", 1, 70, 32, "Fire")
    };

    private string[] Terrain = new[] { "Grass", "Mud", "Water", "Stone" }; 

    private Trainer CurrentTrainer = new Trainer("", 0);
    private Pokemon Oponent;
    public void StartScreen()
    {
        Console.WriteLine("Welcome new trainer What is your Name");
        Console.Write("My name is: ");
        string newName = Console.ReadLine();
        CurrentTrainer.setName(newName);
        Console.WriteLine("How old are you?");
        int newAge = int.Parse(Console.ReadLine());
        CurrentTrainer.setAge(newAge);
        Console.WriteLine($"Welcome {CurrentTrainer.getName()} only {CurrentTrainer.getAge()} Years old!!");
        Console.WriteLine("now you get to choose your first pokemon!");
        PrintStartPokemon();
    }

    public void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("Now it's time to get going!");
            Console.WriteLine("Where Do you want to go?");
            Console.WriteLine("1. Pokeshop");
            Console.WriteLine("2. Wilderness");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //EnterPokeshop();
                    break;
                case "2":
                    ChooseTerrain();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

    }

    public void PrintStartPokemon()
    {
        for (int i = 0; i < StartPokemonSelection.Count; i++)
        {
            int num = i + 1;
            Console.WriteLine($"{num} Name: {StartPokemonSelection[i].getName()} Level: {StartPokemonSelection[i].getLevel()}");
        }

        Console.WriteLine("what pokemon do you want? use the number:");
        int input = int.Parse(Console.ReadLine());
        int choise = input - 1;
        CurrentTrainer.addPokemon(StartPokemonSelection[choise]);
        CurrentTrainer.setChosenPokemon(0);
        MainMenu();
    }

    public void ChooseTerrain()
    {
        Console.WriteLine("Where do you want to go?");
        Console.WriteLine("1. Grass Terrain");
        Console.WriteLine("2. Mud Terrain");
        Console.WriteLine("3. Water Terrain");
        Console.WriteLine("4. Mountain Terrain");
        int index = int.Parse(Console.ReadLine()) - 1;

        CurrentTrainer.setTerrain(Terrain[index]);
        lookForPokemon();
    }

    public int getRandomPokemon()
    {
        List<Pokemon> WildPokemon = prog.GetList();
        int i = Rand.Next(0, WildPokemon.Count);

        return i;
    }

    public void lookForPokemon()
    {
        List<Pokemon> WildPokemon = prog.GetList();



        bool match = false;
        while(match == false)
        {
            getRandomPokemon();
            if (CurrentTrainer.getTerrain() == WildPokemon[getRandomPokemon()].getType())
            {
                Oponent = WildPokemon[getRandomPokemon()];
                match = true;
                BattleInWilderness();

            }
            }

    }

    public void BattleInWilderness()
    {
        List<Item> inventory = CurrentTrainer.getList();
        bool alive = true;
        while (alive)
        {
            if (CurrentTrainer.GetChosenPokemon().getHasAttacked() == false)
            {
                if (CurrentTrainer.GetChosenPokemon().getHealth() > 1)
                {
                    Oponent.Attacked(CurrentTrainer.GetChosenPokemon());
                    CurrentTrainer.GetChosenPokemon().setHasAttacked(true);
                    Oponent.setHasAttacked(false);
                    Console.WriteLine($"{CurrentTrainer.GetChosenPokemon().getName()} {CurrentTrainer.GetChosenPokemon().getHealth()}");
                }
                else
                {
                    Console.WriteLine($"{Oponent.getName()} Has Won!");
                    Console.WriteLine($"{CurrentTrainer.GetChosenPokemon().getName()} is unconcius");
                    alive = false;
                }
            }

            else if (Oponent.getHasAttacked() == false)
            {
                if (Oponent.getHealth() > 1)
                {
                    CurrentTrainer.GetChosenPokemon().Attacked(Oponent);
                    CurrentTrainer.GetChosenPokemon().setHasAttacked(false);
                    Oponent.setHasAttacked(true);
                    Console.WriteLine($"{Oponent.getName()} {Oponent.getHealth()}");
                }
                else
                {
                    Console.WriteLine($"{CurrentTrainer.GetChosenPokemon().getName()} Has Won!");
                    Console.WriteLine($"{Oponent.getName()} is unconcius");
                    Console.WriteLine("Do You Want To Catch It? Y/N");
                    string Ans = Console.ReadLine().ToUpper();
                    if (Ans == "Y")
                    {
                        CurrentTrainer.addPokemon(Oponent);
                    }

                    alive = false;
                }

            }
        }
    }
}

