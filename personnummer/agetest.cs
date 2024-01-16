public class CheckAgeTests
{
    [Fact]
    public void CheckAge_ReturnsCorrectAge_WhenPersonalNumberIsValid()
    {
        // Arrange
        string personalNumber = "950405-5493";

        // Act
        var writer = new StringWriter();
        Console.SetOut(writer);
        Program.CheckAge(personalNumber);

        // Assert
        var output = writer.GetStringBuilder().ToString().Split('\n');
        Assert.Equal("Ålder: 29 år", output[0].Trim());
        Assert.Equal("Personen är under 100 år gammal.", output[1].Trim());
    }

}