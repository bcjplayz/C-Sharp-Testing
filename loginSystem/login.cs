Console.Write("Enter your name: ");
string? name = Console.ReadLine();
Console.WriteLine($"Welcome, {name}!");

Console.Write("Enter a password: ");
string? pass = Console.ReadLine();
Console.WriteLine($"Password set.");

Console.WriteLine("Account Created.");
Console.Write("Please verify your log in details: ");
Console.Write("Enter your username: ");
string? newName = Console.ReadLine();
Console.Write("Enter your password: ");
string? newPass = Console.ReadLine();

if(newName != name)
    Console.WriteLine("Incorrect username. Try again.");
else if(newPass != pass)
    Console.WriteLine("Incorrect password. Try again.");
else
    Console.WriteLine("Login Successful.");