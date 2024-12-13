namespace PokemonPPtest;

public class Pokemon
{
    private string Name;
    private int Level;
    private int Health;
    private int Strength;

    public Pokemon(string name, int level, int health, int strength)
    {
        Name = name;
        Level = level;
        Health = health;
        Strength = strength;
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

    public void Attack(Pokemon Oponent)
    {

    }
}