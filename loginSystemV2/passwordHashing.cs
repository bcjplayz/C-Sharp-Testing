using System.Security.Cryptography;
using System.IO;

// if a selection is chosen, run the program
while (true)
{

    // menu layout for ease of use
    Console.WriteLine("=======================");
    Console.WriteLine("Account System");
    Console.WriteLine("=======================");

    // options
    Console.WriteLine("register");
    Console.WriteLine("login");
    Console.WriteLine("exit");

    string? choice = Console.ReadLine();

    // making an account
    if(choice == "register")
    {
    Console.Write("Enter a username: ");
    string? username = Console.ReadLine();
    Console.Write("Enter a password: ");
    string? pass = Console.ReadLine();

    // if user inputs blank
    if (string.IsNullOrEmpty(username))
        {
            Console.WriteLine("Username cannot be empty.");
            // continue skips the while loop, taking you back to the menu if input is blank
            continue;
        }

    else if (string.IsNullOrEmpty(pass))
    {
        Console.WriteLine("Password cannot be empty.");
        continue;
    }

    // bytes are an array of bytes. remember nibbles bits & bytes??
    // salt = password to be hashed
    byte[] salt = RandomNumberGenerator.GetBytes(16);
    string saltText = Convert.ToHexString(salt);

    Console.WriteLine($"Salt: {saltText}");

    // hashing begin
    byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
        pass,
        salt,
        600_000,
        HashAlgorithmName.SHA256,
        32
    );

    string hashText = Convert.ToHexString(hash);
    Console.WriteLine($"Hashed Password: {hashText}");

    // adds hashed password to a file, in this case a .txt, though it could easily be a .db
    if (File.Exists("accounts.txt"))
    {
        Console.WriteLine("Accounts file found.");
    }
    else
    {
        File.WriteAllText("accounts.txt", "");
        Console.WriteLine("Accounts file created.");
    }

    File.AppendAllText("accounts.txt",$"{username}:{saltText}:{hashText}{Environment.NewLine}");
    }

    // log in to an account
    else if(choice == "login")
    {
        Console.WriteLine("Enter your username: ");
        string? username = Console.ReadLine();
        if (string.IsNullOrEmpty(username))
        {
            Console.WriteLine("Username cannot be empty.");
            continue;
        }
        // reads accounts.txt
        string[] accounts = File.ReadAllLines("accounts.txt");

        // starts at false
        bool accountFound = false;
        string[]? matchedAccount = null;

    foreach (string account in accounts)
    {
        string[] parts = account.Split(':');

        if (parts[0] == username)
        {
            accountFound = true;
            matchedAccount = parts;
            Console.WriteLine("Username found");
            break;
        }
    }

    if (!accountFound)
    {
        Console.WriteLine("Account not found...");
        continue;
    }

    Console.Write("Enter your password: ");
    string? pass = Console.ReadLine();

    if (string.IsNullOrEmpty(pass))
    {
        Console.WriteLine("Password cannot be empty");
        continue;
    }

    byte[] salt = Convert.FromHexString(matchedAccount![1]);
    byte[] storedHash = Convert.FromHexString(matchedAccount[2]);

    byte[] enteredHash = Rfc2898DeriveBytes.Pbkdf2(
        pass,
        salt,
        600_000,
        HashAlgorithmName.SHA256,
        32
    );

    if (CryptographicOperations.FixedTimeEquals(enteredHash, storedHash))
    {
        Console.WriteLine("Login successful!!!");
    }
    else
    {
        Console.WriteLine("Incorrect password");
    }

    }

    // bye bye
    else if(choice == "exit")
    {
        Console.WriteLine("Goodbye");
        return;
    }
    

    // e.g if they type "bhechbcsdbsdbi" or "737363"
    else
    {
        Console.WriteLine("Invalid input");
    }
    continue;
}