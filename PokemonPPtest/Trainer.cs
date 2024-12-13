namespace PokemonPPtest;

public class Trainer
{
    List<Item> PersonalInventory = new List<Item>();
    List<Pokemon> myPokemons = new List<Pokemon>();
    private Pokemon chosenPokemon;
    List<Pokemon> PokeDex = new List<Pokemon>();

    private string Name;
    private int Age;
    private string Terrain;
    public Trainer(string name, int age)
    {
        Name = name;
        Age = age;

    }





    //Trainer:

    public List<Item> getList()
    {
        return PersonalInventory;
    }

    public List<Pokemon> getPokemons()
    {
        return myPokemons;
    }
    public int getAge()
    {
        return Age;
    }

    public void setAge(int newAge)
    {
        Age = newAge;
    }

    public string getName()
    {
        return Name;
    }

    public void setName(string newName)
    {
        Name = newName;
    }


    public void addPokemon(Pokemon pokemon)
    {
        myPokemons.Add(pokemon);
    }


    // Pokedex:

    public List<Pokemon> getPokedex()
    {
        return PokeDex;
    }
    public void addToPokedex(Pokemon pokemon)
    {
        if (!PokeDex.Contains(pokemon))
        {
            PokeDex.Add(pokemon);
        }
    }

    public string getTerrain()
    {
        return Terrain;
    }

    public void setTerrain(string terrain)
    {
        Terrain = terrain;
    }

    public void setChosenPokemon(int index)
    {
        chosenPokemon = myPokemons[index];
    }

    public Pokemon GetChosenPokemon()
    {
        return chosenPokemon;
    }

}