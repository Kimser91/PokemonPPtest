using System.Threading.Channels;

namespace PokemonPPtest;

public class Pokeshop
{
    private readonly List<Item> inventory = new()
    {
        new Item("Pokeball"),
        new Item("Health Potion", 50)
    };

    private Trainer Customer;

    public void TheShop(Trainer current)
    {
        Customer = current;
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
                    BuyItems();
                    break;
                case 2:
                    ChoosePokemonToSell();
                    break;
                default:
                    shopping = false;
                    break;
            }
        }
    }

    void BuyItems()
    {
        Console.WriteLine("1. Pokleballs");
        Console.WriteLine("2. Health Potions");
        Console.WriteLine("3. Exit Shop");
        var input = int.Parse(Console.ReadLine());
        switch (input)
        {
            case 1:
                Customer.AddToInventory(inventory[input - 1]);
                Customer.SetCash(Customer.GetCash() - inventory[input - 1].GetPrice());
                Console.WriteLine(
                    $"You bought: {Customer.GetList().Last().GetName()}. You now have {Customer.GetCash()} left.");
                break;
            case 2:
                Customer.AddToInventory(inventory[input - 1]);
                Customer.SetCash(Customer.GetCash() - inventory[input - 1].GetPrice());
                Console.WriteLine(
                    $"You bought: {Customer.GetList().Last().GetName()}. You now have {Customer.GetCash()} left.");
                break;
        }

    }

    void ChoosePokemonToSell()
    {
       List<Pokemon> sellabelList = Customer.GetPokemons();
        int i = 1;
       foreach (var pokemon in sellabelList)
       {
           Console.WriteLine();
           Console.WriteLine($"{i}: Name: {pokemon.GetName()}, Level: {pokemon.GetLevel()}, Strength: {pokemon.GetStrength()}");
           Console.WriteLine();
           i++;
       }

       Console.WriteLine("Do You Want to sell? Y/N");
       var ans = Console.ReadLine().ToUpper(); 
       if (ans == "Y")
       {
           Console.WriteLine("Who do you want to sell?");
           int index = int.Parse(Console.ReadLine()) - 1;
           SellPokemon(sellabelList[index]);
        }

       else
       {
           return;
       }

    }

    void SellPokemon(Pokemon pokemon)
    {
        int salePrice = pokemon.GetLevel() * 100;
        Console.WriteLine($"Your pokemon is worth: {salePrice}");
        Console.WriteLine("Do you want to sell? Y/N");
        var Ans = Console.ReadLine().ToUpper();
        if (Ans == "Y")
        {
            Customer.RemovePokemon(pokemon);
        }
        else
        {
            Console.WriteLine("Do you want to Choose another instead? Y/N");

        }
    }
}