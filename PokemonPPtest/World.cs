namespace PokemonPPtest;

public class World
{
    List<Pokemon> StartPokemonSelection = new List<Pokemon>()
    {
        new Pokemon("Pika", 3, 100, 30),
        new Pokemon("Bulba", 4, 150, 22),
        new Pokemon("Charmander", 1, 70, 32)
    };

    private string[] Terrain = new[] { "Gras", "Mud", "Water", "Stone" }; 

    private Trainer CurrentTrainer = new Trainer("", 0);

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
        foreach (var pokemon in CurrentTrainer.getPokemons())
        {
            Console.WriteLine(pokemon.getName());
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
        MainMenu();
    }
}

