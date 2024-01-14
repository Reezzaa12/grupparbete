using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("\nVälkommen till personnummerkontrollen!");

        while (true)
        {
            Console.Write("\nAnge ett svenskt personnummer (ÅÅMMDD-XXXX eller ÅÅMMDD+XXXX): ");
            string input = Console.ReadLine() ?? "";

            if (IsValidSwedishPersonalNumber(input))
            {
                Console.WriteLine($"Personnumret är giltigt. Könet är: {GetGender(input)}");
                CheckAge(input);
            }
            else
            {
                Console.WriteLine("Ogiltigt personnummer. Försök igen.\n");
            }
        }
    }

    public static bool IsValidSwedishPersonalNumber(string personalNumber)
    {
        if (personalNumber.Length != 11 ||
            (personalNumber[6] != '-' && personalNumber[6] != '+'))
        {
            return false;
        }

        string datePart = personalNumber.Substring(0, 6);
        string sequencePart = personalNumber.Substring(7, 4);

        if (!DateTime.TryParseExact(datePart, "yyMMdd", null, System.Globalization.DateTimeStyles.None, out _))
        {
            return false;
        }

        return int.TryParse(sequencePart, out _);
    }

    public static string GetGender(string personalNumber)
    {
        int genderDigit = int.Parse(personalNumber.Substring(9, 1));
        return genderDigit % 2 == 0 ? "Kvinna" : "Man";
    }

    public static void CheckAge(string personalNumber)
    {
        int birthYear = int.Parse(personalNumber.Substring(0, 2));
        int currentYear = DateTime.Now.Year;

        birthYear += 2000;

        int age = currentYear - birthYear;

        if (age < 0 || personalNumber[6] == '+') {
            birthYear -= 100;
            age = currentYear - birthYear;
        }

        Console.WriteLine($"Ålder: {age} år");

        if (age >= 100)
        {
            Console.WriteLine("Personen är över 100 år gammal.");
        }
        else
        {
            Console.WriteLine("Personen är under 100 år gammal.");
        }
    }
}
