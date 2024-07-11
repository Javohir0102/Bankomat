using System;

namespace Bankomat
{
    public class AtmService
    {
        private Card EmvCard { get; set; }
        private decimal Money { get; set; }
        private V1Logger LogHelper { get; set; }
        public AtmService()
        {
            Initialize();
        }

        private void Initialize()
        {
            LogHelper = new V1Logger();
            Card card = new Card();
            card.Balance = 2000000;
            card.IsSmsOn = false;
            EmvCard = card;
            string selection;
            LogHelper.LogInformation("Welcome to ATM");
            do
            {
                ShowMenu();
                Console.Write("Do you want to run again? press \"yes\" or \"y\" for continuing: ");
                selection = Console.ReadLine().ToLower();
            } while (selection == "yes" || selection == "y");
        }

        private void ShowMenu()
        {
            var inputNum = 0;
            var isValidNumber = false;
            do
            {
                LogHelper.LogInformation("1. Balance");
                Console.WriteLine("2. SMS ON/OFF");
                Console.WriteLine("3. WITHDRAW");

                isValidNumber = int.TryParse(Console.ReadLine(), out inputNum);

                if (!isValidNumber || inputNum < 1 || inputNum > 3)
                {
                    isValidNumber = false;
                    LogHelper.LogInformation("Try again, please");
                }
            } while (!isValidNumber);

            if (inputNum == 1)
                ShowBalanceMenu();
            if (inputNum == 2)
                ShowSmsMenu();
            if (inputNum == 3)
                ShowWithDrawMenu();
        }

        private void ShowBalanceMenu()
        {
            LogHelper.LogInformation("1. On display");
            LogHelper.LogInformation("2. Print receipt");

            var inputNumber = int.Parse(Console.ReadLine()!);
            if (inputNumber == 1)
                ShowBalanceToDisplay();
            if (inputNumber == 2)
                ShowBalanceToReceipt();
        }

        private void ShowBalanceToDisplay()
        {
            LogHelper.LogInformation($"Displayed to Monitor");
            LogHelper.LogInformation($"Your balance: {EmvCard.Balance} so'm");
        }

        private void ShowBalanceToReceipt()
        {
            LogHelper.LogInformation("***************************************");
            LogHelper.LogInformation($"DateTime: {DateTime.Now}");
            LogHelper.LogInformation($"Your balance: {EmvCard.Balance} so'm");
            LogHelper.LogInformation($"SMS on/off: {(EmvCard.IsSmsOn ? "ON" : "OFF")}");
            LogHelper.LogInformation("***************************************");
        }

        private void ShowSmsMenu()
        {
            LogHelper.LogInformation("1. Turn on message");
            LogHelper.LogInformation("2. Turn off message");

            var inputNumber = int.Parse(Console.ReadLine()!);
            if (inputNumber == 1)
                SetSmsOn();
            if (inputNumber == 2)
                SetSmsOff();
        }

        private void SetSmsOn()
        {
            Console.Write("Enter phone number: ");
            var phone = Console.ReadLine();
            if (phone.Length == 12)
            {
                EmvCard.IsSmsOn = true;
                EmvCard.Phone = phone;
                LogHelper.LogInformation("Phone is successfully added!");
            }
        }

        private void SetSmsOff()
        {
            EmvCard.IsSmsOn = false;
            EmvCard.Phone = "";
            LogHelper.LogInformation("Phone is successfully deleted!");
        }

        private void ShowWithDrawMenu()
        {
            LogHelper.LogInformation("1. 100 000 sum");
            LogHelper.LogInformation("2. 200 000 sum");
            LogHelper.LogInformation("3. Other sum");

            var yourChoice = int.Parse(Console.ReadLine()!);
            if (yourChoice == 1)
            {
                WithDraw100000();
            }
            else if (yourChoice == 2)
            {
                WithDraw200000();
            }
            else if (yourChoice == 3)
            {
                WithDrawYourChoice();
            }
        }

        private void WithDraw100000()
        {
            Money = 100000;
            if (!CheckBalance())
            {
                return;
            }
            EmvCard.Balance -= Money;
            LogHelper.LogInformation("WithDrawed 100000 so'm");
            LogHelper.LogInformation($"Current balance: {EmvCard.Balance}");
        }

        private void WithDraw200000()
        {
            Money = 200000;
            if (!CheckBalance())
            {
                return;
            }
            EmvCard.Balance -= Money;
            LogHelper.LogInformation("WithDrawed 200000 so'm");
            LogHelper.LogInformation($"Current balance: {EmvCard.Balance}");
        }

        private void WithDrawYourChoice()
        {

            Console.Write("Enter the amount of money: ");
            Money = decimal.Parse(Console.ReadLine()!);
            if (!CheckBalance())
            {
                return;
            }
            EmvCard.Balance -= Money;
            LogHelper.LogInformation($"Withdrawed {Money} so'm");
            LogHelper.LogInformation($"Current balance: {EmvCard.Balance}");

        }

        private bool CheckBalance()
        {
            if (EmvCard.Balance - Money >= 0)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                LogHelper.LogInformation($"Current balance is: {EmvCard.Balance} so'm. Your balance is not enough!");
                Console.ForegroundColor = ConsoleColor.White;
                ShowMenu();
                return false;
            }
        }
    }
}
