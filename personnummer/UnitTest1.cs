namespace personnummer;

public class UnitTest1
{
    [Fact]
    public void TestValidPersonnummer()
    {
        // Arrange
        string validPersonnummer = "000803-2872"; // Replace with a valid personnummer

        // Act
        bool isValid = Program.IsPersonnummerValid(validPersonnummer);

        // Assert
        Assert.True(isValid, "Valid personnummer should return true.");
    }
}
