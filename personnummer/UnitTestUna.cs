namespace personnummer;

public class UnitTestUna
{
    [Fact]
    public void TestInvalidPersonnummer()
    {
        // Given
        string invalidPersonnummer = "001219-3421"; // invalid personnummer

        // When
        bool isValid = Program.IsPersonnummerValid(invalidPersonnummer);

        // Then
        Assert.True(isValid, "Invalid personnummer should return false."); // output should be false
    }
}