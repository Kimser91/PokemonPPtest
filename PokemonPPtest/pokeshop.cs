namespace PokemonPPtest;

public class Pokeshop
{
    private readonly List<Item> inventory = new()
    {
        new Item("Pokeball"),
        new Item("Health Potion", 50)
    };

    public void TheShop(Trainer current)
    {
        var shopping = true;
        while (shopping)
        {
            Console.WriteLine("Welcome to the Pokeshop, what can i get you?");
            Console.WriteLine("1. Pokleballs");
            Console.WriteLine("2. Health Potions");
            Console.WriteLine("3. Exit Shop");
            var input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    current.AddToInventory(inventory[input - 1]);
                    current.SetCash(current.GetCash() - inventory[input - 1].GetPrice());
                    Console.WriteLine(
                        $"You bought: {current.GetList().Last().GetName()}. You now have {current.GetCash()} left.");
                    break;
                case 2:
                    current.AddToInventory(inventory[input - 1]);
                    current.SetCash(current.GetCash() - inventory[input - 1].GetPrice());
                    Console.WriteLine(
                        $"You bought: {current.GetList().Last().GetName()}. You now have {current.GetCash()} left.");
                    break;
                default:
                    shopping = false;
                    break;
            }
        }
    }
}