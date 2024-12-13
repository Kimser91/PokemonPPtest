namespace PokemonPPtest;

public class Item
{
    private string Name;
    private int HealthPoints;
    public Item(string name)
    {
        Name = name;
    }

    public Item(string name, int healthpoints)
    {
        Name = name;
        HealthPoints = healthpoints;
    }

    public string getName()
    {
        return Name;
    }

    public int getHealthPoints()
    {
        return HealthPoints;
    }
}