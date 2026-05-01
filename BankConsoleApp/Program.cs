namespace BankConsoleApp;

public class Program
{
    public static void Main()
    {
        BankOperations bankOperations = new BankOperations();

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("======= BANK SYSTEM =======");
            Console.WriteLine("Select an option:");
            Console.WriteLine("[1] Check balance");
            Console.WriteLine("[2] Withdraw");
            Console.WriteLine("[3] Deposit");
            Console.WriteLine("[4] Exit");

            int option;
            int attempts = 0;

            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 4)
            {
                attempts++;
                Console.WriteLine("Please select a valid option.");

                if (attempts == 4)
                {
                    Console.WriteLine("[1] Check balance");
                    Console.WriteLine("[2] Withdraw");
                    Console.WriteLine("[3] Deposit");
                    Console.WriteLine("[4] Exit");
                    attempts = 0;
                }
            }

            isRunning = BankTerminal.Menu(option, bankOperations);
        }
    }
}