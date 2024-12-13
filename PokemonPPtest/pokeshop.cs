namespace PokemonPPtest;

public class pokeshop
{
    List<Item> inventory = new List<Item>()
    {
        new Item("pokeball"),
        new Item("pokeball"),
        new Item("pokeball"),
        new Item("pokeball"),
        new Item("pokeball"),
        new Item("pokeball"),
        new Item("pokeball"),
        new Item("Health Potion", 50),
        new Item("Health Potion", 50),
        new Item("Health Potion", 50),
        new Item("Health Potion", 50),
        new Item("Health Potion", 50),
        new Item("Health Potion", 50),
        new Item("Health Potion", 50),
        new Item("Health Potion", 50),
    };

    public List<Item> getInventory()
    {
        return inventory;
    }

}