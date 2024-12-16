namespace PokemonPPtest;

public class PokemonManager
{
    private readonly List<Pokemon> WildPokemons = new()
    {
        // Grass Type
        new Pokemon("Bulbasaur", 5, 150, 25, "Grass"),
        new Pokemon("Ivysaur", 10, 250, 35, "Grass"),
        new Pokemon("Venusaur", 20, 400, 50, "Grass"),
        new Pokemon("Oddish", 3, 100, 15, "Grass"),
        new Pokemon("Gloom", 8, 200, 25, "Grass"),
        new Pokemon("Vileplume", 15, 350, 40, "Grass"),
        new Pokemon("Bellsprout", 4, 120, 20, "Grass"),
        new Pokemon("Weepinbell", 9, 220, 30, "Grass"),
        new Pokemon("Victreebel", 18, 380, 45, "Grass"),

        // Ground Type
        new Pokemon("Sandshrew", 6, 180, 20, "Ground"),
        new Pokemon("Sandslash", 12, 300, 40, "Ground"),
        new Pokemon("Diglett", 3, 100, 15, "Ground"),
        new Pokemon("Dugtrio", 10, 250, 35, "Ground"),
        new Pokemon("Cubone", 5, 160, 20, "Ground"),
        new Pokemon("Marowak", 15, 350, 40, "Ground"),
        new Pokemon("Rhyhorn", 8, 250, 30, "Ground"),
        new Pokemon("Rhydon", 18, 450, 50, "Ground"),
        new Pokemon("Geodude", 4, 140, 20, "Ground"),
        new Pokemon("Graveler", 10, 280, 35, "Ground"),
        new Pokemon("Golem", 20, 420, 50, "Ground"),

        // Water Type
        new Pokemon("Squirtle", 5, 150, 25, "Water"),
        new Pokemon("Wartortle", 10, 250, 35, "Water"),
        new Pokemon("Blastoise", 20, 400, 50, "Water"),
        new Pokemon("Psyduck", 4, 130, 20, "Water"),
        new Pokemon("Golduck", 15, 350, 45, "Water"),
        new Pokemon("Poliwag", 3, 100, 15, "Water"),
        new Pokemon("Poliwhirl", 8, 220, 30, "Water"),
        new Pokemon("Poliwrath", 18, 400, 50, "Water"),
        new Pokemon("Tentacool", 5, 150, 20, "Water"),
        new Pokemon("Tentacruel", 15, 350, 45, "Water"),
        new Pokemon("Seel", 6, 160, 25, "Water"),
        new Pokemon("Dewgong", 16, 380, 50, "Water"),
        new Pokemon("Shellder", 4, 120, 20, "Water"),
        new Pokemon("Cloyster", 18, 420, 55, "Water"),

        // Rock Type
        new Pokemon("Onix", 12, 300, 35, "Rock"),
        new Pokemon("Kabuto", 8, 250, 30, "Rock"),
        new Pokemon("Kabutops", 18, 400, 50, "Rock"),
        new Pokemon("Omanyte", 7, 230, 28, "Rock"),
        new Pokemon("Omastar", 17, 410, 52, "Rock"),
        new Pokemon("Aerodactyl", 20, 450, 60, "Rock"),
        new Pokemon("Geodude", 4, 140, 20, "Rock"),
        new Pokemon("Graveler", 10, 280, 35, "Rock"),
        new Pokemon("Golem", 20, 420, 50, "Rock"),
        new Pokemon("Rhyhorn", 8, 250, 30, "Rock"),
        new Pokemon("Rhydon", 18, 450, 50, "Rock"),
        new Pokemon("Sudowoodo", 15, 350, 45, "Rock")
    };

    public List<Pokemon> GetList()
    {
        return WildPokemons;
    }
}