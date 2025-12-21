using TxtProcessor.Core.Models;

namespace TxtProcessor.Core.Processing;

public static class TextAnalyzer
{
    public static IReadOnlyList<WordCount> GetTopWords(
        string text,
        int top = 5)
    {
        if (string.IsNullOrWhiteSpace(text))
            return [];

        var words = text
            .ToLowerInvariant()
            .Split(
                [' ', '\r', '\n', '\t', '.', ',', ';', '!', '?'],
                StringSplitOptions.RemoveEmptyEntries);

        var topWords = words
            .GroupBy(w => w)
            .Select(g => new WordCount(g.Key, g.Count()))
            .OrderByDescending(x => x.Count)
            .ThenBy(x => x.Word)
            .Take(top)
            .ToList();

        return topWords;
    }
}
