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

    [Fact]
    public void GetGender_ReturnsMan_WhenGenderDigitIsOdd()
    {
        // given
        string personalNumber = "950405-5483";

        //when
        string result = Program.GetGender(personalNumber);

        // then
        Assert.Equal("Man", result);
    }

    [Fact]
    public void GetGender_ReturnsKvinna_WhenGenderDigitIsEven()
    {
        // given
        string personalNumber = "950405-5483";

        // when
        string result = Program.GetGender(personalNumber);

        // then
        Assert.Equal("Kvinna", result);
    }

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
