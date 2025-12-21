using TxtProcessor.Core.Processing;

namespace TxtProcessor.Core.Tests.Processing;

public class TextAnalyzerTests
{
    [Fact]
    public void AnalyzeText_Handles_Empty_String()
    {
        // Arrange
        var text = string.Empty;
        // Act
        var result = TextAnalyzer.AnalyzeText(text);
        // Assert
        Assert.Empty(result.TopWords);
    }

    [Fact]
    public void AnalyzeText_Returns_Total_Word_Count_Correctly()
    {
        // Arrange
        var text = "apple banana apple orange banana apple";
        // Act
        var result = TextAnalyzer.AnalyzeText(text);
        // Assert
        Assert.Equal(6, result.TotalWords);
    }

    [Fact]
    public void AnalyzeText_Returns_Unique_Word_Count_Correctly()
    {
        // Arrange
        var text = "apple banana apple orange banana apple";
        // Act
        var result = TextAnalyzer.AnalyzeText(text);
        // Assert
        Assert.Equal(3, result.UniqueWords);
    }

    [Fact]
    public void AnalyzeText_Returns_Top_Words_Correctly()
    {
        // Arrange
        var text = "apple banana apple orange banana apple grape orange";
        // Act
        var result = TextAnalyzer.AnalyzeText(text, topWordsCount: 2);
        // Assert
        Assert.Equal(2, result.TopWords.Count);
        Assert.Equal("apple", result.TopWords[0].Word);
        Assert.Equal(3, result.TopWords[0].Count);
        Assert.Equal("banana", result.TopWords[1].Word);
        Assert.Equal(2, result.TopWords[1].Count);
    }
}
