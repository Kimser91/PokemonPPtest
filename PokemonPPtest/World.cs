namespace PokemonPPtest;

public class World
{
    private readonly BattleArena Battle = new();

    private readonly Trainer CurrentTrainer = new("", 0);
    private Pokemon Opponent;
    private readonly Random Rand = new();
    private readonly Pokeshop Shop = new();

    private readonly List<Pokemon> StartPokemonSelection = new()
    {
        new Pokemon("Pika", 3, 210, 60, "Electric"),
        new Pokemon("Bulba", 4, 150, 22, "Grass"),
        new Pokemon("Charmander", 1, 70, 32, "Fire")
    };

    private readonly string[] Terrain = new[] { "Grass", "Mud", "Water", "Stone" };
    private readonly PokemonManager WildPokemons = new();

    public World()
    {
        StartScreen();
    }
    public void StartScreen()
    {
        Console.WriteLine("Welcome new trainer What is your Name");
        Console.Write("My name is: ");
        var newName = Console.ReadLine();
        CurrentTrainer.SetName(newName);
        Console.WriteLine("How old are you?");
        var newAge = int.Parse(Console.ReadLine());
        CurrentTrainer.SetAge(newAge);
        Console.WriteLine($"Welcome {CurrentTrainer.GetName()} only {CurrentTrainer.GetAge()} Years old!!");
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
            Console.WriteLine("3. Heal my Pokemon");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Shop.TheShop(CurrentTrainer);
                    break;
                case "2":
                    ChooseTerrain();
                    break;
                case "3":
                    CurrentTrainer.HealMyPokemon();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    public void PrintStartPokemon()
    {
        for (var i = 0; i < StartPokemonSelection.Count; i++)
        {
            var num = i + 1;
            Console.WriteLine(
                $"{num} Name: {StartPokemonSelection[i].GetName()} Level: {StartPokemonSelection[i].GetLevel()}");
        }

        Console.WriteLine("what pokemon do you want? use the number:");
        var input = int.Parse(Console.ReadLine());
        var choise = input - 1;
        CurrentTrainer.AddPokemon(StartPokemonSelection[choise]);
        CurrentTrainer.SetChosenPokemon(0);
        MainMenu();
    }

    public void ChooseTerrain()
    {
        Console.WriteLine("Where do you want to go?");
        Console.WriteLine("1. Grass Terrain");
        Console.WriteLine("2. Mud Terrain");
        Console.WriteLine("3. Water Terrain");
        Console.WriteLine("4. Mountain Terrain");
        var index = int.Parse(Console.ReadLine()) - 1;

        CurrentTrainer.SetTerrain(Terrain[index]);
        LookForPokemon();
    }

    public int GetRandomPokemon()
    {
        List<Pokemon> WildPokemon = WildPokemons.GetList();
        var i = Rand.Next(0, WildPokemon.Count);

        return i;
    }

    public void LookForPokemon()
    {
        List<Pokemon> WildPokemon = WildPokemons.GetList();
        int i = GetRandomPokemon();
        Console.WriteLine(i);
        var match = false;
        while (match == false)
        {
            if (CurrentTrainer.GetTerrain() == WildPokemon[i].GetType())
            {
                Opponent = WildPokemon[i];
                CurrentTrainer.AddToPokedex(WildPokemon[i]);
                match = true;
                Console.WriteLine(
                    $"Your oponent id {Opponent.GetName()} and is Level {Opponent.GetLevel()}, Strength {Opponent.GetStrength()}");
                Console.WriteLine("What type of Battle do you want?");
                Console.WriteLine("1. Auto Battle");
                Console.WriteLine("2. Maunal Battle");
                Console.WriteLine("3. Flee");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Battle.AutoBattleInWilderness(CurrentTrainer, Opponent);
                        break;
                    case "2":
                        Battle.ManualBattleInWilderness(CurrentTrainer, Opponent);
                        break;
                    default:
                        MainMenu();
                        break;
                }
            }
            else
            {
                LookForPokemon();
            }

        }
    }
}