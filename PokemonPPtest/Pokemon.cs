namespace PokemonPPtest;

public class Pokemon
{
    private string Name;
    private int Level;
    private int Health;
    private int Strength;
    private string Type;
    private bool hasAttacked = false;

    public Pokemon(string name, int level, int health, int strength, string type)
    {
        Name = name;
        Level = level;
        Health = health;
        Strength = strength;
        Type = type;
    }

    public string getName()
    {
        return Name;
    }

    public int getLevel()
    {
        return Level;
            
    }

    public void setLevel(int LevelUp)
    {
        Level = LevelUp;
    }

    public int getHealth()
    {
        return Health;
    }

    public void setHealth(int Healing)
    {
        Health = Healing;
    }

    public int getStrength()
    {
        return Strength;
    }

    public void Attacked(Pokemon oponent)
    {
        Health -= oponent.getStrength();
    }

    public string getType()
    {
        return Type;
    }

    public bool getHasAttacked()
    {
        return hasAttacked;
    }

    public void setHasAttacked(bool x)
    {
        hasAttacked = x;
    }
}