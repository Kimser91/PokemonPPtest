namespace PokemonPPtest;

public class Pokemon
{
    public int Exp { get; private set; }
    public bool hasAttacked { get; private set; }
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Health { get; private set; }
    public int Attack { get; private set; }
    public string Type { get; private set; }

    public Pokemon(string name, int level, int health, int attack, string type)
    {
        Name = name;
        Level = level;
        Health = health;
        Attack = attack;
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

    public void SetHealth(int Healing)
    {
        Health += Healing;
    }

    public int GetStrength()
    {
        return Attack;
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
    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Level: {Level}, Strength: {Attack}");
    }
    public void PrintInfo(int ID)
    {
        Console.Write($"ID: {ID} ");
        PrintInfo();
    }

    public void PrintInfo(int ID, int Price)
    {
        PrintInfo(ID);
        Console.WriteLine($"Price: {Level * Price}");
        Console.WriteLine();
    }

}

