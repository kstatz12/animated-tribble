//Problem: Substitution Cypher
//Rules: This is a fixed cypher so the input will always result in the output
//strings must be forward and backwards encdodeable

internal class Program
{
    private static void Main(string[] args)
    {
        Cypher c = new Cypher();

        string source = "HelloWorld";
        string encoded = c.Encode(source);

        Console.WriteLine(source);
        Console.WriteLine(encoded);
        Console.WriteLine(c.Decode(encoded));
    }
}

internal class Cypher
{
    public const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
    public const string Substitute = "opdefghiqrsxyzabcjklmntuvw";

    private static char Lookup(char input, string source, string destination)
    {
        int sourceIndex = -1;
        for (int j = 0; j < source.Length; j++)
        {
            if (source[j] == input)
            {
                sourceIndex = j;
                char substituteCharacter = destination[sourceIndex];
                return substituteCharacter;
            }
        }
        throw new Exception("Out Of Range");
    }

    public string Encode(string candidate)
    {
        string lowerInvariant = candidate.ToLower();
        string newString = string.Empty;
        for (int i = 0; i < lowerInvariant.Length; i++)
        {
            char c = lowerInvariant[i];
            newString += Lookup(c, Alphabet, Substitute);
        }
        return newString;
    }

    public string Decode(string candidate)
    {
        string lowerInvariant = candidate.ToLower();
        string newString = string.Empty;
        for (int i = 0; i < lowerInvariant.Length; i++)
        {
            char c = lowerInvariant[i];
            newString += Lookup(c, Substitute, Alphabet);
        }
        return newString;
    }
}
