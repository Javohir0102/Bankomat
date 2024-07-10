using System;

namespace Bankomat
{
    public class AtmService
    {
        public Card EmvCard { get; set; }
        public AtmService()
        {
            Init();
        }

        private void Init()
        {
            Card card = new Card();
            card.Balance = 2000000;
            card.IsSmsOn = false;
            EmvCard = card;
            string selection;
            Console.WriteLine("Welcome to ATM");
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
                Console.WriteLine("1. Balance");
                Console.WriteLine("2. SMS ON/OFF");
                Console.WriteLine("3. WITHDRAW");

                isValidNumber = int.TryParse(Console.ReadLine(), out inputNum);

                if (!isValidNumber || inputNum < 1 || inputNum > 3)
                {
                    isValidNumber = false;
                    Console.WriteLine("Try again, please");
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
            Console.WriteLine("1. On display");
            Console.WriteLine("2. Print receipt");

            var inputNumber = int.Parse(Console.ReadLine()!);
            if (inputNumber == 1)
                ShowBalanceToDisplay();
            if (inputNumber == 2)
                ShowBalanceToReceipt();
        }

        private void ShowBalanceToDisplay()
        {
            Console.WriteLine($"Displayed to Monitor");
            Console.WriteLine($"Your balance: {EmvCard.Balance} so'm");
        }

        private void ShowBalanceToReceipt()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine($"DateTime: {DateTime.Now}");
            Console.WriteLine($"Your balance: {EmvCard.Balance} so'm");
            Console.WriteLine($"SMS on/off: {(EmvCard.IsSmsOn ? "ON" : "OFF")}");
            Console.WriteLine("***************************************");
        }

        private void ShowSmsMenu()
        {
            Console.WriteLine("1. Turn on message");
            Console.WriteLine("2. Turn off message");

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
                Console.WriteLine("Phone is successfully added!");
            }
        }

        private void SetSmsOff()
        {
            EmvCard.IsSmsOn = false;
            EmvCard.Phone = "";
            Console.WriteLine("Phone is successfully deleted!");
        }

        private void ShowWithDrawMenu()
        {
            Console.WriteLine("1. 100 000 sum");
            Console.WriteLine("2. 200 000 sum");
            Console.WriteLine("3. Other sum");

            var yourChoice = int.Parse(Console.ReadLine()!);
            if( yourChoice == 1)
            {
                WithDraw100000();
            }
            else if( yourChoice == 2)
            {
                WithDraw200000();
            }
            else if ( yourChoice == 3)
            {
                WithDrawYourChoice();
            }
        }

        private void WithDraw100000()
        {
            EmvCard.Balance -= 100000;
            Console.WriteLine("WithDrawed 100000 so'm");
            Console.WriteLine($"Current balance: {EmvCard.Balance}");
        }

        private void WithDraw200000()
        {
            EmvCard.Balance -= 200000;
            Console.WriteLine("WithDrawed 200000 so'm");
            Console.WriteLine($"Current balance: {EmvCard.Balance}");
        }

        private void WithDrawYourChoice()
        {
            Console.Write("Enter the amount of money: ");
            var money = decimal.Parse(Console.ReadLine()!);
            EmvCard.Balance -= money;
            Console.WriteLine($"Withdrawed {money} so'm");
            Console.WriteLine($"Current balance: {EmvCard.Balance}");
        }
    }
}
