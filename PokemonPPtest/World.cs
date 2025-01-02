
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PokemonPPtest;

public class World
{
    private BattleArena Battle = new();
    
    private Trainer CurrentTrainer = new("", 0);
    private Pokemon Opponent;
    private Random Rand = new();
    private Pokeshop Shop = new();
    private  List<Pokemon> StartPokemonSelection = new()
    {
        new Pokemon("Pika", 3, 210, 60, "Electric"),
        new Pokemon("Bulba", 4, 150, 22, "Grass"),
        new Pokemon("Charmander", 1, 70, 32, "Fire")
    };
    private string[] Terrain = new[] { "Grass", "Ground", "Water", "Rock" };
    List<Pokemon> WildPokemon = new List<Pokemon> { };
    private string json;
    private PokemonManager data;
    public World()
    {
        setList();
        StartScreen();
        
    }

    public void setList() 
    {

        string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pokemons.json");  
        json = File.ReadAllText(FilePath);
        var data = JsonSerializer.Deserialize<List<Pokemon>>(json);
        
        if (data != null) {
            foreach (var pokemon in data) 
            {
                WildPokemon.Add(pokemon);
            }
        }
        
    }

    public void serializeMethod() 
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(WildPokemon, options);
        System.IO.File.WriteAllText("E:\\ReStartItC#\\PokemonPPtest\\PokemonPPtest\\SaveFile.json", json);
        Console.WriteLine(json);
    }

    /*public void InputToJson() 
    {
        string jsonData = JsonConvert.SerializeObject(data);
        System.IO.File.WriteAllText("E:\\ReStartItC#\\PokemonPPtest\\PokemonPPtest\\SaveFile.json", jsonData);
        Console.WriteLine(jsonData);
    }*/
    
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
            Console.WriteLine("json test");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Shop.TheShop(CurrentTrainer, WildPokemon);
                    break;
                case "2":
                    ChooseTerrain();
                    break;
                case "3":
                    CurrentTrainer.HealMyPokemon();
                    break;
                case "4":
                    serializeMethod();
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
        Console.WriteLine("2. Ground Terrain");
        Console.WriteLine("3. Water Terrain");
        Console.WriteLine("4. Mountain Terrain");
        var index = int.Parse(Console.ReadLine()) - 1;

        CurrentTrainer.SetTerrain(Terrain[index]);
        LookForPokemon();
    }

    public int GetRandomPokemon()
    {
       
        var i = Rand.Next(0, WildPokemon.Count);

        return i;
    }

    public void LookForPokemon()
    {
       
        int i = GetRandomPokemon();
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