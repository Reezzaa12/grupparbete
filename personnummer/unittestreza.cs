public class GetGenderTests
{
    [Fact]
    public void GetGender_ReturnsMan_WhenGenderDigitIsOdd()
    {
        // given
        string personalNumber = "950405-5493";

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
}