// Read the document and retrieve the words
string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + @"/wordlist.txt";

// Read the document and retrieve the words
string documentContent = File.ReadAllText(filePath);
IEnumerable<string> words = documentContent.Split("\n").Select(x => x.ToLowerInvariant());

// Group the words by their sorted characters to identify anagrams
Dictionary<string, List<string>> anagramGroups = new Dictionary<string, List<string>>();


foreach (string word in words)
{
    string sortedChars = SortCharacters(word);

    if (anagramGroups.ContainsKey(sortedChars))
    {
        anagramGroups[sortedChars].Add(word);
    }
    else
    {
        anagramGroups[sortedChars] = new List<string> { word };
    }
}


// Print the anagram groups
foreach (var group in anagramGroups.Values)
{
    if (group.Count > 1)
    {
        Console.WriteLine(string.Join(", ", group));
    }
}
Console.WriteLine($"Total of {anagramGroups.Keys.Count} found.");


// Helper method to sort the characters of a word
static string SortCharacters(string word)
{
    char[] chars = word.ToCharArray();
    Array.Sort(chars);
    return new string(chars);
}