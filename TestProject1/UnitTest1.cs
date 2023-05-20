using Xunit;
namespace TestProject1
{

    public class UnitTest1
    {
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 2m.ToString(), "two DOLLARS" };
            yield return new object[] { 12m.ToString(), "twelve DOLLARS" };
            yield return new object[] { 1357256.32m.ToString(), "one million, three hundred and fifty seven thousand, two hundred and fifty six DOLLARS AND thirty two CENTS" };
            yield return new object[] { 4000015m.ToString(), "four million and fifteen DOLLARS" };
            yield return new object[] { 0.22m.ToString(), "twenty two CENTS" };
            yield return new object[] { 400000.16m.ToString(), "four hundred thousand DOLLARS AND sixteen CENTS" };
            yield return new object[] { 0.00m.ToString(), "zero DOLLARS AND zero CENTS" };
            yield return new object[] { "0000,00", "zero DOLLARS AND zero CENTS" };
            yield return new object[] { 2000000000m.ToString(), "two billion DOLLARS" };
            yield return new object[] { "not a number", "Input was not in correct format" };
            yield return new object[] { 15.155m.ToString(), "Input was not in correct format" };
            yield return new object[] { 1m.ToString(), "one DOLLAR" };
            yield return new object[] { 45.1m.ToString(), "forty five DOLLARS AND ten CENTS" };
            yield return new object[] { 45.01m.ToString(), "forty five DOLLARS AND one CENT" };
            yield return new object[] { 1985m.ToString(), "one thousand, nine hundred and eighty five DOLLARS" };
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Test1(string input, string expected)
        {
            var actual = new DecimalParser().Convert(input);
            Assert.Equal(expected, actual);
        }
    }
}
