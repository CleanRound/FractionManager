using Newtonsoft.Json;

class Fraction
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public Fraction(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}

class Program
{
    static void Main()
    {
        List<Fraction> fractions = EnterFractions();
        string serializedFractions = SerializeFractions(fractions);
        SaveToFile(serializedFractions, "fractions.json");

        string loadedData = LoadFromFile("fractions.json");
        List<Fraction> deserializedFractions = DeserializeFractions(loadedData);

        Console.WriteLine("Deserialized Fractions:");
        foreach (var fraction in deserializedFractions)
        {
            Console.WriteLine(fraction);
        }
    }

    static List<Fraction> EnterFractions()
    {
        List<Fraction> fractions = new List<Fraction>();
        Console.WriteLine("Enter the number of fractions:");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter numerator for fraction {i + 1}:");
            int numerator = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter denominator for fraction {i + 1}:");
            int denominator = int.Parse(Console.ReadLine());

            fractions.Add(new Fraction(numerator, denominator));
        }

        return fractions;
    }

    static string SerializeFractions(List<Fraction> fractions)
    {
        return JsonConvert.SerializeObject(fractions, Formatting.Indented);
    }

    static void SaveToFile(string data, string fileName)
    {
        File.WriteAllText(fileName, data);
    }

    static string LoadFromFile(string fileName)
    {
        return File.ReadAllText(fileName);
    }

    static List<Fraction> DeserializeFractions(string data)
    {
        return JsonConvert.DeserializeObject<List<Fraction>>(data);
    }
}
