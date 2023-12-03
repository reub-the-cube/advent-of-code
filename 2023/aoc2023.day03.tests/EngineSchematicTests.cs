using aoc2023.day03.domain;
using FluentAssertions;

namespace aoc2023.day03.tests
{
    public class EngineSchematicTests
    {
        [Fact]
        public void EngineSchematicRowWithTwoNumbersCanBeParsedToEngineParts()
        {
            var inputRow = "467..114..";

            var engineParts = Parser.ParseRow(inputRow);

            engineParts.Should().HaveCount(4);
            engineParts[0].PartType.Should().Be(EnginePartType.Number);
            engineParts[1].PartType.Should().Be(EnginePartType.Period);
            engineParts[2].PartType.Should().Be(EnginePartType.Number);
            engineParts[3].PartType.Should().Be(EnginePartType.Period);

            engineParts[0].StartIndex.Should().Be(0);
            engineParts[1].StartIndex.Should().Be(3);
            engineParts[2].StartIndex.Should().Be(5);
            engineParts[3].StartIndex.Should().Be(8);

            engineParts[0].EndIndex.Should().Be(2);
            engineParts[1].EndIndex.Should().Be(4);
            engineParts[2].EndIndex.Should().Be(7);
            engineParts[3].EndIndex.Should().Be(9);
        }

        [Fact]
        public void EngineSchematicRowWithSingleSymbolCanBeParsedToEngineParts()
        {
            var inputRow = "...*......";

            var engineParts = Parser.ParseRow(inputRow);

            engineParts.Should().HaveCount(3);
            engineParts[0].PartType.Should().Be(EnginePartType.Period);
            engineParts[1].PartType.Should().Be(EnginePartType.Symbol);
            engineParts[2].PartType.Should().Be(EnginePartType.Period);

            engineParts[0].StartIndex.Should().Be(0);
            engineParts[1].StartIndex.Should().Be(3);
            engineParts[2].StartIndex.Should().Be(4);

            engineParts[0].EndIndex.Should().Be(2);
            engineParts[1].EndIndex.Should().Be(3);
            engineParts[2].EndIndex.Should().Be(9);
        }

        [Fact]
        public void EngineSchematicRowWithNonAdjacentSymbolAndNumberCanBeParsedToEngineParts()
        {
            var inputRow = ".....+.58.";

            var engineParts = Parser.ParseRow(inputRow);

            engineParts.Should().HaveCount(5);
            engineParts[0].PartType.Should().Be(EnginePartType.Period);
            engineParts[1].PartType.Should().Be(EnginePartType.Symbol);
            engineParts[2].PartType.Should().Be(EnginePartType.Period);
            engineParts[3].PartType.Should().Be(EnginePartType.Number);
            engineParts[4].PartType.Should().Be(EnginePartType.Period);

            engineParts[0].StartIndex.Should().Be(0);
            engineParts[1].StartIndex.Should().Be(5);
            engineParts[2].StartIndex.Should().Be(6);
            engineParts[3].StartIndex.Should().Be(7);
            engineParts[4].StartIndex.Should().Be(9);

            engineParts[0].EndIndex.Should().Be(4);
            engineParts[1].EndIndex.Should().Be(5);
            engineParts[2].EndIndex.Should().Be(6);
            engineParts[3].EndIndex.Should().Be(8);
            engineParts[4].EndIndex.Should().Be(9);
        }

        [Fact]
        public void EngineSchematicRowWithAdjacentSymbolAndNumberCanBeParsedToEngineParts()
        {
            var inputRow = "617*......";

            var engineParts = Parser.ParseRow(inputRow);

            engineParts.Should().HaveCount(3);
            engineParts[0].PartType.Should().Be(EnginePartType.Number);
            engineParts[1].PartType.Should().Be(EnginePartType.Symbol);
            engineParts[2].PartType.Should().Be(EnginePartType.Period);

            engineParts[0].StartIndex.Should().Be(0);
            engineParts[1].StartIndex.Should().Be(3);
            engineParts[2].StartIndex.Should().Be(4);

            engineParts[0].EndIndex.Should().Be(2);
            engineParts[1].EndIndex.Should().Be(3);
            engineParts[2].EndIndex.Should().Be(9);
        }

        [Fact]
        public void EngineSchematicWithMultipleRowsCanBeParsedToEngineParts()
        {
            var inputRows = "......#...\r\n617*......".Split(Environment.NewLine);

            var engineParts = Parser.ParseRows(inputRows);

            engineParts.Should().HaveCount(6);
            engineParts[0].RowIndex.Should().Be(0);
            engineParts[1].RowIndex.Should().Be(0);
            engineParts[2].RowIndex.Should().Be(0);
            engineParts[3].RowIndex.Should().Be(1);
            engineParts[4].RowIndex.Should().Be(1);
            engineParts[5].RowIndex.Should().Be(1);
        }

        [Fact]
        public void EngineSchematicWithNumbersCanBeParsedToValue()
        {
            var inputRow = "467.......";

            var engineParts = Parser.ParseRow(inputRow);

            engineParts.Count.Should().BeGreaterThan(1);
            engineParts[0].PartValue.Should().Be("467");
        }
    }
}
