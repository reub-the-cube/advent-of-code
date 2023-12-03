using aoc2023.day03.domain;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023.day03.tests
{
    public class EngineSchematicTests
    {
        [Fact]
        public void EngineSchematicRowCanBeParsedToEngineParts()
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
    }
}
