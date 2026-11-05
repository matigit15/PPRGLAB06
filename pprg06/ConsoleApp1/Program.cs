string heroName = "Ada";
int health = 70;
int maxHealth = 100;
int gold = 15;
int strength = 6;
int weaponDamage = 3;
bool isRunning = true;

List<string>inventory = new List<string>() {"miecz", "mikstura" , "łuk"};



while (isRunning)
{
    ShowStatus(heroName, health, maxHealth, gold);
    ShowMenu();
    string command = ReadCommand();

    if (command == "1")
    {
        int damage = CalculateDamage( strength, weaponDamage);
        Console.WriteLine($"Zadajesz {damage} obrażeń wrogowi!");

    
    }
    else if (command == "2")
    {
        health = Heal(health,10,maxHealth);
        Console.WriteLine($"Uleczono się o 10 punktów zdrowia. Aktualne zdrowie: {health}/{maxHealth}");

    }
    else if (command == "3")
    {
        isRunning = false;

    }
    if (isGameOver(health))
    {
        Console.WriteLine("Bohater polegl. Koniec gry.");
        isRunning = false;
    }
}
void ShowPanelTitle(string title, ConsoleColor color)
{
    Console.ResetColor();
    Console.ForegroundColor = color;
    Console.WriteLine(title.ToUpper());
    Console.ResetColor();
}
void ShowStatus(string name , int health , int maxHealth , int gold)
{
    ShowPanelTitle("Status Bohatera", ConsoleColor.DarkBlue);
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Bohater");
    Console.ResetColor();
    Console.WriteLine(name);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Zdrowie:");
    Console.ResetColor();
    Console.WriteLine($"{health}/{maxHealth}");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Złoto:");
    Console.ResetColor();
    Console.WriteLine(gold);

}

void ShowMenu()
{
    ShowPanelTitle("Menu", ConsoleColor.DarkCyan);
    Console.WriteLine("1. Atakuj wroga");
    Console.WriteLine("2. Ulecz się");
    Console.WriteLine("3. Zakończ grę");

}
string ReadCommand()
{
    while (true)
    {
        Console.Write("Wybor");
        string? command = Console.ReadLine();
        if (command == "1" || command == "2" || command == "3")
        {
            return command;

        }
        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
    }
}
int CalculateDamage(int strength, int weaponDamage)=> strength + weaponDamage ;

int Heal(int health ,int amount ,int maxHealth)
{
    int newHealth = health + amount;
    return newHealth > maxHealth? maxHealth : newHealth;
}
bool isGameOver(int health) => health <= 0;


