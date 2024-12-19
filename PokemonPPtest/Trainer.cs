using System.IO.Enumeration;

namespace PokemonPPtest;

public class Trainer
{
    
    private  List<Pokemon> myPokemons = new List<Pokemon>();
    private  List<Item> PersonalInventory = new List<Item>();
    private  List<Pokemon> PokeDex = new List<Pokemon>();
    private int Age;
    private int Cash = 1000;
    private Pokemon chosenPokemon;
    private int index = 0;
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

    public void PrintPokemon()
    {
        foreach (var pokemon in myPokemons)
        {
            Console.WriteLine();
            Console.WriteLine(pokemon.GetName());
            Console.WriteLine();
        }
    }

    public int GetAge()
    {
        return Age;
    }

    public void SetAge(int newAge)
    {
        Age = newAge ;
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

    public void RemovePokemon(Pokemon pokemon)
    {
        myPokemons.Remove(pokemon);
    }


    public List<Pokemon> GetPokedex()
    {
        return PokeDex;
    }

    public void AddToPokedex(Pokemon pokemon)
    {
        if (!PokeDex.Contains(pokemon)){ PokeDex.Add(pokemon);}
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

    Item FindHelathPotion()
    {
        foreach (var item in PersonalInventory)
            if (item.GetName() == "Health Potion")
            {

                return item;
            }

        return null;
    }

    public void HealMyPokemon()
    {
        Item item = FindHelathPotion();
        if (item != null)
        {
            Console.WriteLine(chosenPokemon.GetHealth());
            chosenPokemon.SetHealth(100);
            RemoveFromInventory(item);
            Console.WriteLine(chosenPokemon.GetHealth());
        }

    }



 
}