using System;
//kommentar
class Program
{
    static void Main()
    {
        Console.WriteLine("\nVälkommen till personnummerkontrollen!");

        while (true)
        {
            Console.Write("\nAnge ett svenskt personnummer (ÅÅMMDD-XXXX eller ÅÅMMDD+XXXX): \n eller skriv exit för att avsluta programmet \n");
            string input = Console.ReadLine() ?? "";

            if (input.ToLower() == "exit")
            {
                // Användaren har valt att avsluta programmet
                break;
            }
            else if (IsPersonnummerValid(input))
            {
                Console.WriteLine($"Personnumret är giltigt. Könet är: {GetGender(input)}");
                CheckAge(input);
            }
            else
            {
                Console.WriteLine("Ogiltigt personnummer. Försök igen eller skriv 'exit' för att avsluta.\n");
            }
        }
    }

    public static bool IsPersonnummerValid(string personnummer)
    {
        if (personnummer.Length != 11 ||
                (personnummer[6] != '-' && personnummer[6] != '+'))
        {
            return false;
        }
        // Ta bort strecket från personnumret
        personnummer = personnummer.Replace("-", "");

        // Kontrollera att personnumret nu består av exakt 10 siffror
        if (personnummer.Length != 10)
            return false;  // Om det inte gör det, returnera 'false'

        // Skapa en variabel för att hålla summan av siffrorna
        int sum = 0;

        // Loopa igenom varje siffra i personnumret
        for (int i = 0; i < personnummer.Length; i++)
        {
            // Multiplicera varje siffra  1 och  2
            int num = int.Parse(personnummer[i].ToString()) * (2 - i % 2);

            // Om resultatet blir större än 9, subtrahera 9 från det
            if (num > 9)
                num -= 9;

            // Lägg till resultatet till summan
            sum += num;
        }

        // Kontrollera om summan är jämnt delbar med 10
        return sum % 10 == 0;
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

        if (age < 0 || personalNumber[6] == '+')
        {
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
