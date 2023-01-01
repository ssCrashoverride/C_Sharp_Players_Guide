Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore?");
int manticorePosition = NumberCheck();
Console.Clear();
Console.WriteLine("Player 2, it's your turn.");
int cityHealth = 15;
int manticoreHealth = 10;
for (int round = 1; cityHealth > 0 | manticoreHealth > 0; round++)
{
    int damage = DefineDamage(round);
    Status(round, cityHealth, manticoreHealth, damage);
    int player2Field = NumberCheck();
    manticoreHealth = Player2Turn(damage, manticoreHealth, player2Field);
    cityHealth = cityHealth - 1;
    if (cityHealth == 0)
    {
        Console.WriteLine("The Manticore win the game. City of Consolas has been destroyed");
        break;
    }
    else if (manticoreHealth <= 0)
    {
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        break;
    }
}
void Status(int round, int cityHealth, int manticoreHealt, int damage)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("------------------------------------------------");
    Console.WriteLine($"Round: {round}   City: {cityHealth}/15   Manticore: {manticoreHealt}/10");
    if (damage == 1)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"The cannon is expected to deal {damage} damage this round");
    }
    else if (damage == 3)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"The cannon is expected to deal {damage} damage this round");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"The cannon is expected to deal {damage} damage this round");
    }
}
int DefineDamage(int round)
{
    int damage;
    if (round % 3 == 0 & round % 5 == 0)
        damage = 10;
    else if (round % 3 == 0 | round % 5 == 0)
        damage = 3;
    else
        damage = 1;

    return damage;
}
int Player2Turn(int damage, int manticoreHealth, int player2Field)
{
    if (player2Field < manticorePosition)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("That round FELL SHORT of the target");
    }
    else if (player2Field == manticorePosition)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("That round was a DIRECT HIT");
        manticoreHealth = manticoreHealth - damage;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("That round OVERSHOT the target");
    }
    return manticoreHealth;
}
int NumberCheck()
{
    bool check = false;
    int playerInput = 0;
    while (check == false)
    {
        Console.Write("Enter desire range (integer in range 0-100): ");
        var player = Console.ReadLine();
        if (int.TryParse(player, out playerInput))
        {
            if (playerInput >= 0 & playerInput <= 100)
            {
                check = true;
            }
            else
            {
                Console.WriteLine("The input is not in a rage of 0-100");
                check = false;
            }
        }
        else
        {
            Console.WriteLine("The input is not an integer");
            check = false;
        }
    }
    return playerInput;
}