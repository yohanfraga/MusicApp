namespace Tests.TestTools;

public static class UtilTools
{
    public static string GenerateStringByLength(int length)
    {
        const string chars = "test";

        var random = new Random();

        var repeatedString = Enumerable.Repeat(chars, length);

        var randomChars = repeatedString
            .Select(s => s[random.Next(s.Length)])
            .ToArray();
        
        return new string(randomChars);
    }
}