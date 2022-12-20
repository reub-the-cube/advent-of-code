using aoc2022.day20.domain;
using FluentAssertions;

namespace aoc2022.day20.tests
{
    public class DecryptorTests
    {
        [Fact]
        public void MixingNumbersDecryptsFileCorrectly()
        {
            var originalNumbers = new Dictionary<long, long>
            {
                { 0, 1 },
                { 1, 2 },
                { 2, -3 },
                { 3, 3 },
                { 4, -2 },
                { 5, 0 },
                { 6, 4 }
            };

            var mixedList = Decryptor.MixListOfNumbers(originalNumbers, 1, 1);

            var expectedResult = "1, 2, -3, 4, 0, 3, -2";
            string.Join(", ", mixedList.Select(k => k.Value)).Should().Be(expectedResult);
        }
    }
}
