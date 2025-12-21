using TxtProcessor.Core.Processing;

namespace TxtProcessor.Core.Tests.Processing;

public class TextAnalyzerTests
{
    [Fact]
    public void GetTopWords_Returns_Most_Repeated_Words()
    {
        // Arrange
        var text = "apple banana apple orange banana apple";

        // Act
        var result = TextAnalyzer.GetTopWords(text);

        // Assert
        Assert.Equal(3, result.Count);

        Assert.Equal(new("apple", 3), result[0]);
        Assert.Equal(new("banana", 2), result[1]);
        Assert.Equal(new("orange", 1), result[2]);
    }
}
