using TxtProcessor.Core.Models;

namespace TxtProcessor.Core.Processing;

public static class TextAnalyzer
{
    public static TextAnalysisResult AnalyzeText(
        string text,
        int topWordsCount = 5)
    {
        ArgumentNullException.ThrowIfNull(text);

        int totalWords = GetTotalWordCount(text);
        int uniqueWords = GetTotalUniqueWordCount(text);
        IReadOnlyList<WordCount> topWords = GetTopWords(text, topWordsCount);

        return new TextAnalysisResult
        (
            TotalWords: totalWords,
            UniqueWords: uniqueWords,
            TopWords: topWords
        );
    }

    private static int GetTotalWordCount(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;
        string[] words = text
            .Split(
                [' ', '\r', '\n', '\t', '.', ',', ';', '!', '?'],
                StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    private static int GetTotalUniqueWordCount(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;
        string[] words = text
            .ToLowerInvariant()
            .Split(
                [' ', '\r', '\n', '\t', '.', ',', ';', '!', '?'],
                StringSplitOptions.RemoveEmptyEntries);
        HashSet<string> uniqueWords = [.. words];
        return uniqueWords.Count;
    }

    private static IReadOnlyList<WordCount> GetTopWords(
        string text,
        int top = 5)
    {
        if (string.IsNullOrWhiteSpace(text))
            return [];

        string[] words = text
            .ToLowerInvariant()
            .Split(
                [' ', '\r', '\n', '\t', '.', ',', ';', '!', '?'],
                StringSplitOptions.RemoveEmptyEntries);

        List<WordCount> topWords = [.. words
            .GroupBy(w => w)
            .Select(g => new WordCount(g.Key, g.Count()))
            .OrderByDescending(x => x.Count)
            .ThenBy(x => x.Word)
            .Take(top)];

        return topWords;
    }
}
