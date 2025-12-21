namespace TxtProcessor.Core.Processing;

public static class TextAnalyzer
{
    public static IReadOnlyList<(string Word, int Count)> GetTopWords(
        string text,
        int top = 5)
    {
        if (string.IsNullOrWhiteSpace(text))
            return [];

        var words = text
            .ToLowerInvariant()
            .Split(
                separator: [' ', '\r', '\n', '\t', '.', ',', ';', '!', '?'],
                options: StringSplitOptions.RemoveEmptyEntries);

        return [.. words
            .GroupBy(w => w)
            .Select(g => (Word: g.Key, Count: g.Count()))
            .OrderByDescending(x => x.Count)
            .ThenBy(x => x.Word)
            .Take(top)];
    }
}
