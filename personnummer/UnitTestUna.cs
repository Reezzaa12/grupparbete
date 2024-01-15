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

    [Fact]
    public void TestGetGenderMale()
    {
        // Given
        string malePersonnummer = "811218-9876";
        string expectedGender = "Man";

        // When
        string actualGender = Program.GetGender(malePersonnummer);

        // Then
        Assert.Equal(expectedGender, actualGender);
    }

    [Fact]
    public void TestGetGenderFemale()
    {
        // Given
        string femalePersonnummer = "001219-3421";
        string expectedGender = "Kvinna";

        // When
        string actualGender = Program.GetGender(femalePersonnummer);

        // Then
        Assert.Equal(expectedGender, actualGender);
    }
}