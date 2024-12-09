namespace ConsoleApp23
{
    internal class Program
    {
        public static void ConvertNumber()
        {
            Console.WriteLine("Виберіть конвертацію:");
            Console.WriteLine("1. Десяткова у двійкову");
            Console.WriteLine("2. Двійкова у десяткову");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть число у десятковій системі: ");
                    if (int.TryParse(Console.ReadLine(), out int decimalNumber))
                    {
                        string binary = Convert.ToString(decimalNumber, 2);
                        Console.WriteLine($"Число {decimalNumber} у двійковій системі: {binary}");
                    }
                    else
                    {
                        Console.WriteLine("Неправильне введення.");
                    }
                    break;
                case "2":
                    Console.Write("Введіть число у двійковій системі: ");
                    string binaryInput = Console.ReadLine();
                    try
                    {
                        int decimalValue = Convert.ToInt32(binaryInput, 2);
                        Console.WriteLine($"Число {binaryInput} у десятковій системі: {decimalValue}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неправильний формат для двійкового числа.");
                    }
                    break;
                default:
                    Console.WriteLine("Неправильний вибір.");
                    break;
             }

        }

        public static void ConvertWordToNumber()
        {
            string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            Console.Write("Введіть слово (zero - nine): ");
            string word = Console.ReadLine().ToLower();

            int index = Array.IndexOf(words, word);

            if (index >= 0)
            {
                Console.WriteLine($"Слово відповідає цифрі {index}.");
            }
            else
            {
                Console.WriteLine("Неправильне написане слово.");
            }
        }
        static void Main(string[] args)
        {
            ConvertNumber();
            ConvertWordToNumber();
            try
            {
                Passport passport = new Passport("12345678", "Кузнєцова Дарія", new DateTime(2024, 12, 09));
                passport.DisplayData();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
    class Passport
    {
        private string passportNumber;
        private string fullName;
        private DateTime issueDate;

        public Passport(string passportNumber, string fullName, DateTime issueDate)
        {
            if (string.IsNullOrWhiteSpace(passportNumber))
                throw new ArgumentException("Номер паспорта не може бути порожнім.");
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("ПІБ власника не може бути порожнім.");

            this.passportNumber = passportNumber;
            this.fullName = fullName;
            this.issueDate = issueDate;
        }

        public void DisplayData()
        {
            Console.WriteLine($"Номер паспорта: {passportNumber}");
            Console.WriteLine($"ПІБ власника: {fullName}");
            Console.WriteLine($"Дата видачі: {issueDate.ToShortDateString()}");
        }
    }
}
