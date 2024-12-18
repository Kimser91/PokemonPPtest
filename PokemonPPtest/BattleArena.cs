namespace PokemonPPtest;

public class BattleArena
{
    public void AutoBattleInWilderness(Trainer CurrentTrainer, Pokemon Opponent)
    {
        var alive = true;
        while (alive)
            if (CurrentTrainer.GetChosenPokemon().GetHasAttacked() == false)
            {
                if (CurrentTrainer.GetChosenPokemon().GetHealth() > 1)
                {
                    Opponent.Attacked(CurrentTrainer.GetChosenPokemon());
                    CurrentTrainer.GetChosenPokemon().SetHasAttacked(true);
                    Opponent.SetHasAttacked(false);
                    Console.WriteLine(
                        $"{CurrentTrainer.GetChosenPokemon().GetName()} {CurrentTrainer.GetChosenPokemon().GetHealth()}");
                }
                else
                {
                    Console.WriteLine($"{Opponent.GetName()} Has Won!");
                    Console.WriteLine($"{CurrentTrainer.GetChosenPokemon().GetName()} is unconcius");
                    alive = false;
                }
            }

            else if (Opponent.GetHasAttacked() == false)
            {
                if (Opponent.GetHealth() > 1)
                {
                    CurrentTrainer.GetChosenPokemon().Attacked(Opponent);
                    CurrentTrainer.GetChosenPokemon().SetHasAttacked(false);
                    Opponent.SetHasAttacked(true);
                    Console.WriteLine($"{Opponent.GetName()} {Opponent.GetHealth()}");
                }
                else
                {
                    Console.WriteLine($"{CurrentTrainer.GetChosenPokemon().GetName()} Has Won!");
                    Console.WriteLine($"{Opponent.GetName()} is unconcius");
                    Console.WriteLine("Do You Want To Catch It? Y/N");
                    var Ans = Console.ReadLine().ToUpper();
                    if (Ans == "Y") CurrentTrainer.AddPokemon(Opponent);

                    alive = false;
                }
            }
    }

    public void ManualBattleInWilderness(Trainer CurrentTrainer, Pokemon Opponent)
    {
        var alive = true;

        Console.WriteLine("");
        while (alive)
            if (CurrentTrainer.GetChosenPokemon().GetHasAttacked() == false)
            {
                if (CurrentTrainer.GetChosenPokemon().GetHealth() > 1)
                {
                    Console.WriteLine(
                        $"{CurrentTrainer.GetChosenPokemon().GetName()}  Health:  {CurrentTrainer.GetChosenPokemon().GetHealth()}");
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Heal");
                    Console.WriteLine("3. Flee");
                    var choise = Console.ReadLine();
                    switch (choise)
                    {
                        case "1":
                            Opponent.Attacked(CurrentTrainer.GetChosenPokemon());
                            CurrentTrainer.GetChosenPokemon().SetHasAttacked(true);
                            Opponent.SetHasAttacked(false);
                            Console.WriteLine(
                                $"{CurrentTrainer.GetChosenPokemon().GetName()} {CurrentTrainer.GetChosenPokemon().GetHealth()}");
                            break;

                        case "2":
                            CurrentTrainer.HealMyPokemon();
                            CurrentTrainer.GetChosenPokemon().SetHasAttacked(true);
                            Opponent.SetHasAttacked(false);
                            break;

                        default:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine($"{Opponent.GetName()} Has Won!");
                    Console.WriteLine($"{CurrentTrainer.GetChosenPokemon().GetName()} is unconcius");
                    alive = false;
                }
            }

            else if (Opponent.GetHasAttacked() == false)
            {
                if (Opponent.GetHealth() > 1)
                {
                    CurrentTrainer.GetChosenPokemon().Attacked(Opponent);
                    CurrentTrainer.GetChosenPokemon().SetHasAttacked(false);
                    Opponent.SetHasAttacked(true);
                    Console.WriteLine($"{Opponent.GetName()} {Opponent.GetHealth()}");
                }
                else
                {
                    Console.WriteLine($"{CurrentTrainer.GetChosenPokemon().GetName()} Has Won!");
                    Console.WriteLine($"{Opponent.GetName()} is unconcius");
                    alive = false;
                    Console.WriteLine("Do You Want To Catch It? Y/N");
                    var Ans = Console.ReadLine().ToUpper();
                    if (Ans == "Y") CurrentTrainer.AddPokemon(Opponent);
                }
            }
    }
}