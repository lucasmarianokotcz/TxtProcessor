namespace TxtProcessor.Core.Models;

public sealed record TextAnalysisResult(
    int TotalWords,
    int UniqueWords,
    IReadOnlyList<WordCount> TopWords
);

public sealed record WordCount(string Word, int Count);