using aoc2023.day15.domain;
using FluentAssertions;

namespace aoc2023.day15.tests
{
    public class FocusPowerTests
    {
        [Fact]
        public void GetFocusPowerForBoxWithTwoLenses()
        {
            var lenses = new List<Lens>(){
                new("rn", 3),
                new("cm", 5)
            };

            var focusPower = FocusPower.Calculate(10, lenses);

            // Box id of 10 -> use 11 in calculation
            // "rn" is in the first slot -> 1 * 3 -> focus power of 11 * 1 * 3 -> 33
            // "cm" is in the second slot -> 2 * 5 -> focus power of 11 * 10 -> 110
            focusPower.Should().Be(143);
        }
    }
}
