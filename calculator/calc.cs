Console.Write("First number: ");
bool valid = int.TryParse(Console.ReadLine(), out int num1);

if (!valid)
{
    Console.WriteLine("Input a number!");
    return;
}

Console.Write("Second number: ");
bool valid2 = int.TryParse(Console.ReadLine(), out int num2);

if (!valid2)
{
    Console.WriteLine("Input a number!");
    return;
}

Console.Write("Mode (add, subtract, multiply, divide): ");
string? mode = Console.ReadLine();

if (mode == "add")
{
    Console.WriteLine($"Answer: {num1 + num2}");
}

else if(mode == "subtract")
{
    Console.WriteLine($"Answer: {num1 - num2}");
}

else if(mode == "multiply")
{
    Console.WriteLine($"Answer: {num1 * num2}");
}

else if(mode == "divide")
{
    if(num2 == 0)
    {
        Console.WriteLine("Cannot divide by zero!");
    }

    else if()

    else
    {
        Console.WriteLine($"Answer: {num1 / num2}");
    }
}

else
{
    Console.WriteLine("Input a listed mode!!");
}