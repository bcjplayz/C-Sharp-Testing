int AInum = Random.Shared.Next(1, 101);
int attempts = 5;

Console.WriteLine("I'm thinking of a number between 1 and 100. Guess.");

while (attempts > 0)
{
    Console.Write("Enter a number: ");
    int userGuess = int.Parse(Console.ReadLine()!);
    attempts -= 1;
    Console.WriteLine($"Attempts left: {attempts}");

    if (userGuess == AInum)
    {
        Console.WriteLine($"Correct! My number was {AInum}.");
        break;
    }

    if (attempts == 0)
    {
        Console.WriteLine($"No more guesses. The number was {AInum}.");
        break;
    }

    if (userGuess < AInum)
    {
        Console.WriteLine("Guess higher");
    }
    else
    {
        Console.WriteLine("Guess lower");
    }
}