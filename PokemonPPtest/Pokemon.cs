namespace PokemonPPtest;

public class Pokemon
{
    private int Exp;
    private bool hasAttacked;
    private int Health;
    private int Level;
    private readonly string Name;
    private readonly int Strength;
    private readonly string Type;

    public Pokemon(string name, int level, int health, int strength, string type)
    {
        Name = name;
        Level = level;
        Health = health;
        Strength = strength;
        Type = type;
    }

    public string GetName()
    {
        return Name;
    }

    public int GetLevel()
    {
        return Level;
    }

    public void SetLevel(int LevelUp)
    {
        Level = LevelUp;
    }

    public int GetHealth()
    {
        return Health;
    }

    public void GetHealth(int Healing)
    {
        Health = Healing;
    }

    public int GetStrength()
    {
        return Strength;
    }

    public void Attacked(Pokemon oponent)
    {
        Health -= oponent.GetStrength();
    }

    public string GetType()
    {
        return Type;
    }

    public bool GetHasAttacked()
    {
        return hasAttacked;
    }

    public void SetHasAttacked(bool x)
    {
        hasAttacked = x;
    }

    public int GetExp()
    {
        return Exp;
    }

    public void SetExp(int exp)
    {
        Exp = exp;
    }
}