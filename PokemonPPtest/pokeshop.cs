using System.Threading.Channels;

namespace PokemonPPtest;

public class Pokeshop
{

    private readonly List<Item> inventory = new()
    {
        new Item("Pokeball"),
        new Item("Health Potion", 50)
    };

    private bool shopping;

    public void TheShop(Trainer current, PokemonManager wildPokemon)
    {
        
        shopping = true;
        while (shopping)
        {
            Console.WriteLine("Welcome to the Pokeshop, what can i get you?");
            Console.WriteLine("1. Buy items");
            Console.WriteLine("2. Sell Pokemon");
            Console.WriteLine("3. Buy Pokemon");
            Console.WriteLine("3. Exit Shop");
            var input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    BuyItems(current);
                    break;
                case 2:
                    ChoosePokemonToSell(current);
                    break;
                case 3:
                    BuyPokemon(current, wildPokemon);
                    break;
                default:
                    shopping = false;
                    break;
            }
        }
    }

    void BuyPokemon(Trainer current, PokemonManager wildPokemon)
    {
        foreach (var pokemon in wildPokemon.GetList())
        {
            if (pokemon.GetLevel() < 6)
            {
                
                pokemon.PrintInfo(wildPokemon.GetList().IndexOf(pokemon), 300);

            }
        }

        Console.WriteLine("Who do you want to buy? Choose by ID");
        int choice = int.Parse(Console.ReadLine());
        current.AddPokemon(wildPokemon.GetList()[choice]);
        current.PrintPokemon();
        current.SetCash(current.GetCash() - wildPokemon.GetList()[choice].GetLevel()*300);
        Console.WriteLine(current.GetCash());

    }

    void BuyItems(Trainer current)
    {
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
        }

    }

    void ChoosePokemonToSell(Trainer current)
    {
       ;
        
       for (int i =1; i < current.GetPokemons().Count; i++)
       {
           Console.WriteLine();
           Console.WriteLine($"{i}: Name: {current.GetPokemons()[i].GetName()}, Level: {current.GetPokemons()[i].GetLevel()}, Strength: {current.GetPokemons()[i].GetStrength()}");
           Console.WriteLine();
           i++;
       }

       Console.WriteLine("Do You Want to sell? Y/N");
       var ans = Console.ReadLine().ToUpper(); 
       if (ans == "Y")
       {
           Console.WriteLine("Who do you want to sell?");
           int index = int.Parse(Console.ReadLine()) - 1;
           SellPokemon(current, index);
       }

       else
       {
           return;
       }

    }

    void SellPokemon(Trainer current, int index)
    {
        
        int salePrice = current.GetPokemons()[index].GetLevel() * 100;
        Console.WriteLine($"Your pokemon is worth: {salePrice}");
        Console.WriteLine("Do you want to sell? Y/N");
        var Ans = Console.ReadLine().ToUpper();
        if (Ans == "Y")
        {
            current.RemovePokemon(current.GetPokemons()[index]);
            current.SetCash(current.GetCash() + current.GetPokemons()[index].GetLevel() * 100);
            Console.WriteLine(current.GetCash());
        }
        else
        {
            Console.WriteLine("Do you want to Choose another instead? Y/N");
           Ans = Console.ReadLine();
           if (Ans == "Y")
           {
               ChoosePokemonToSell(current); 
           }
           else
           {
               return;
           }
        }
    }
}