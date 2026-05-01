namespace BankConsoleApp;

public class BankTerminal
{
    public static bool Menu(int option, BankOperations bankOperations)
    {
        switch (option)
        {
            case 1:
                bankOperations.ShowBalance();
                return true;

            case 2:
                bankOperations.Withdraw();
                return true;

            case 3:
                bankOperations.Deposit();
                return true;

            case 4:
                Console.WriteLine("Closing system...");
                return false;

            default:
                return true;
        }
    }
}