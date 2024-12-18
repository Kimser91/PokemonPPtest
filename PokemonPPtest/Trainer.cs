namespace PokemonPPtest;

public class Trainer
{
    private readonly List<Pokemon> myPokemons = new();
    private readonly List<Item> PersonalInventory = new();
    private readonly List<Pokemon> PokeDex = new();
    private int Age;
    private int Cash = 1000;
    private Pokemon chosenPokemon;

    private string Name;
    private string Terrain;

    public Trainer(string name, int age)
    {
        Name = name;
        Age = age;
    }


    public List<Item> GetList()
    {
        return PersonalInventory;
    }

    public void AddToInventory(Item newItem)
    {
        PersonalInventory.Add(newItem);
    }

    public void RemoveFromInventory(Item UseItem)
    {
        PersonalInventory.Remove(UseItem);
    }

    public List<Pokemon> GetPokemons()
    {
        return myPokemons;
    }

    public int GetAge()
    {
        return Age;
    }

    public void SetAge(int newAge)
    {
        Age = newAge;
    }

    public string GetName()
    {
        return Name;
    }

    public void SetName(string newName)
    {
        Name = newName;
    }


    public void AddPokemon(Pokemon pokemon)
    {
        myPokemons.Add(pokemon);
    }


    public List<Pokemon> GetPokedex()
    {
        return PokeDex;
    }

    public void AddToPokedex(Pokemon pokemon)
    {
        if (!PokeDex.Contains(pokemon)) PokeDex.Add(pokemon);
    }

    public string GetTerrain()
    {
        return Terrain;
    }

    public void SetTerrain(string terrain)
    {
        Terrain = terrain;
    }

    public void SetChosenPokemon(int index)
    {
        chosenPokemon = myPokemons[index];
    }

    public Pokemon GetChosenPokemon()
    {
        return chosenPokemon;
    }

    public int GetCash()
    {
        return Cash;
    }

    public void SetCash(int adjustment)
    {
        Cash = adjustment;
    }

    public void HealMyPokemon()
    {
        var Healed = false;
        foreach (var item in PersonalInventory)
            if (item.GetName() == "Health Potion" && Healed == false)
            {
                chosenPokemon.GetHealth(100);
                RemoveFromInventory(item);
                Healed = true;
            }

        if (Healed)
        {
            Console.WriteLine("You have successfully healed " + chosenPokemon.GetName());
            Console.WriteLine("Health is now: " + chosenPokemon.GetHealth());
        }
        else
        {
            Console.WriteLine("You do not have any Health Potions left.");
        }
    }
}