namespace BankConsoleApp;

public class BankOperations
{
    private decimal balance = 2000;

    public decimal ShowBalance()
    {
        Console.WriteLine($"Current balance: ${balance:F2}");
        return balance;
    }

    public void Withdraw()
    {
        Console.WriteLine("Enter the amount you want to withdraw:");

        decimal amount;

        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Enter a valid amount:");
        }

        if (amount > balance)
        {
            Console.WriteLine("Insufficient funds.");
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"Withdrawal successful. Current balance: ${balance:F2}");
        }
    }

    public void Deposit()
    {
        Console.WriteLine("Enter the amount you want to deposit:");

        decimal amount;

        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Enter a valid amount:");
        }

        balance += amount;

        Console.WriteLine($"Deposit successful. Current balance: ${balance:F2}");
    }
}