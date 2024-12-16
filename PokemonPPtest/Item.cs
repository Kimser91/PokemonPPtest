namespace PokemonPPtest;

public class Item
{
    private string Name;
    private int HealthPoints;
    private int Price;

    public Item(string name)
    {
        Name = name;
        Price = 100;
    }

    public Item(string name, int healthpoints)
    {
        Name = name;
        HealthPoints = healthpoints;
        Price = 200;
    }

    public string GetName()
    {
        return Name;
    }

    public int GetHealthPoints()
    {
        return HealthPoints;
    }

    public int GetPrice()
    {
        return Price;
    }
}