using aoc2023.day03.domain;
using FluentAssertions;

namespace aoc2023.day03.tests
{
    public class EnginePartTests
    {
        EnginePart symbolAbove = new(EnginePartType.Symbol, 3, 6, 0, string.Empty);
        EnginePart symbolAboveLeft = new(EnginePartType.Symbol, 2, 2, 1, string.Empty);
        EnginePart symbolAboveRight = new(EnginePartType.Symbol, 7, 7, 1, string.Empty);
        EnginePart symbolLeft = new(EnginePartType.Symbol, 2, 2, 2, string.Empty);
        EnginePart symbolRight = new(EnginePartType.Symbol, 7, 7, 2, string.Empty);
        EnginePart symbolBelowLeft = new(EnginePartType.Symbol, 2, 2, 3, string.Empty);
        EnginePart symbolBelowRight = new(EnginePartType.Symbol, 7, 7, 3, string.Empty);
        EnginePart symbolBelow = new(EnginePartType.Symbol, 3, 6, 4, string.Empty);

        [Fact]
        public void EnginePartWithSymbolJustNotAdjacentIsAValidPart()
        {
            /*
             * ...++++...
             * ..+....+..
             * ..+.12.+..
             * ..+....+..
             * ...++++...
             */

            var enginePartUnderTest = new EnginePart(EnginePartType.Number, 4, 5, 2, string.Empty);

            var engineParts = new List<EnginePart>()
            {
                symbolAbove,
                symbolAboveLeft,
                symbolAboveRight,
                symbolLeft,
                symbolRight,
                symbolBelowLeft,
                symbolBelowRight,
                symbolBelow,
                enginePartUnderTest
            };

            var isAdjacentToSymbol = PartChecker.IsPartAdjacentToASymbol(enginePartUnderTest, engineParts);

            isAdjacentToSymbol.Should().BeFalse();
        }

        [Fact]
        public void EnginePartWithSymbolAdjacentToTheLeftIsNotAValidPart()
        {
            /*
             * ..........
             * ..........
             * ..+12.....
             * ..........
             * ..........
             */

            var enginePartUnderTest = new EnginePart(EnginePartType.Number, 3, 4, 2, string.Empty);

            var engineParts = new List<EnginePart>()
            {
                symbolLeft,
                enginePartUnderTest
            };

            var isAdjacentToSymbol = PartChecker.IsPartAdjacentToASymbol(enginePartUnderTest, engineParts);

            isAdjacentToSymbol.Should().BeTrue();
        }

        [Fact]
        public void EnginePartWithSymbolAdjacentToTheRightIsNotAValidPart()
        {
            /*
             * ..........
             * ..........
             * .....12+..
             * ..........
             * ..........
             */

            var enginePartUnderTest = new EnginePart(EnginePartType.Number, 5, 6, 2, string.Empty);

            var engineParts = new List<EnginePart>()
            {
                symbolRight,
                enginePartUnderTest
            };

            var isAdjacentToSymbol = PartChecker.IsPartAdjacentToASymbol(enginePartUnderTest, engineParts);

            isAdjacentToSymbol.Should().BeTrue();
        }

        [Fact]
        public void EnginePartWithSymbolAdjacentAboveLeftIsNotAValidPart()
        {
            /*
             * ..........
             * ..+.......
             * ...12.....
             * ..........
             * ..........
             */

            var enginePartUnderTest = new EnginePart(EnginePartType.Number, 3, 4, 2, string.Empty);

            var engineParts = new List<EnginePart>()
            {
                symbolAboveLeft,
                enginePartUnderTest
            };

            var isAdjacentToSymbol = PartChecker.IsPartAdjacentToASymbol(enginePartUnderTest, engineParts);

            isAdjacentToSymbol.Should().BeTrue();
        }

        [Fact]
        public void EnginePartWithSymbolAdjacentAboveRightIsNotAValidPart()
        {
            /*
             * ..........
             * .......+..
             * .....12...
             * ..........
             * ..........
             */

            var enginePartUnderTest = new EnginePart(EnginePartType.Number, 5, 6, 2, string.Empty);

            var engineParts = new List<EnginePart>()
            {
                symbolAboveRight,
                enginePartUnderTest
            };

            var isAdjacentToSymbol = PartChecker.IsPartAdjacentToASymbol(enginePartUnderTest, engineParts);

            isAdjacentToSymbol.Should().BeTrue();
        }

        [Fact]
        public void EnginePartWithSymbolAdjacentBelowLeftIsNotAValidPart()
        {
            /*
             * ..........
             * ..........
             * ...12.....
             * ..+.......
             * ..........
             */

            var enginePartUnderTest = new EnginePart(EnginePartType.Number, 3, 4, 2, string.Empty);

            var engineParts = new List<EnginePart>()
            {
                symbolBelowLeft,
                enginePartUnderTest
            };

            var isAdjacentToSymbol = PartChecker.IsPartAdjacentToASymbol(enginePartUnderTest, engineParts);

            isAdjacentToSymbol.Should().BeTrue();
        }

        [Fact]
        public void EnginePartWithSymbolAdjacentBelowRightIsNotAValidPart()
        {
            /*
             * ..........
             * ..........
             * .....12...
             * .......+..
             * ..........
             */

            var enginePartUnderTest = new EnginePart(EnginePartType.Number, 5, 6, 2, string.Empty);

            var engineParts = new List<EnginePart>()
            {
                symbolBelowRight,
                enginePartUnderTest
            };

            var isAdjacentToSymbol = PartChecker.IsPartAdjacentToASymbol(enginePartUnderTest, engineParts);

            isAdjacentToSymbol.Should().BeTrue();
        }

        [Fact]
        public void AsteriskSymbolWithAdjacentPartNumbersReturnsGearInformation()
        {
            /*
             * ..........
             * ..........
             * ..*12.....
             * .6........
             * ..........
             */

            var symbolLeft = new EnginePart(EnginePartType.Symbol, 2, 2, 2, "*");
            var enginePartOne = new EnginePart(EnginePartType.Number, 3, 4, 2, "12");
            var enginePartTwo = new EnginePart(EnginePartType.Number, 1, 1, 3, "6");

            var engineParts = new List<EnginePart>()
            {
                symbolLeft,
                enginePartOne,
                enginePartTwo
            };

            var gearRatio = PartChecker.GetGearRatio(symbolLeft, engineParts);

            gearRatio.Should().Be(12 * 6);
        }
    }
}
