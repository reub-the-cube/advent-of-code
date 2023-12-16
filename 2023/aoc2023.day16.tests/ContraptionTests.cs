using FluentAssertions;
using static aoc2023.day16.Enums;

namespace aoc2023.day16.tests
{
    public class ContraptionTests
    {
        [Fact]
        public void EnteringTheContraptionInTheTopLeftFromTheLeftMarksTileAsEnergised()
        {
            List<string> input = [
                "...",
                "..."
            ];
            var contraption = new Contraption(input);

            contraption.Enter(0, 0, Direction.Right);

            var energisedTiles = contraption.EnergisedTiles;

            energisedTiles.Contains((0, 0, Direction.Right));
        }

        //[Theory]
        //[InlineData(0, 1, Direction.Up)]
        //public void LightCannotMoveAtEdgeOfContraption(int rowIndex, int columnIndex, Direction heading)
        //{
        //    List<string> input = [
        //        "...",
        //        "..."
        //    ];
        //    var contraption = new Contraption(input);

        //    contraption.Enter(rowIndex, columnIndex, heading);
        //}

        [Fact]
        public void FillingWithLightInAStraightRightLineEndsAtEdgeOfContraption()
        {
            List<string> input = [
                "...",
                "..."
            ];
            var contraption = new Contraption(input);

            contraption.FillWithLight(0, 0, Direction.Right);

            var energisedTiles = contraption.EnergisedTiles;

            energisedTiles.Count.Should().Be(3);
        }

        [Fact]
        public void FillingWithLightWithAMirrorEndsAtEdgeOfContraption()
        {
            List<string> input = [
                @".\.",
                 "..."
            ];
            var contraption = new Contraption(input);

            contraption.FillWithLight(0, 0, Direction.Right);

            var energisedTiles = contraption.EnergisedTiles;

            energisedTiles.Count.Should().Be(3);
            energisedTiles.Contains((1, 1, Direction.Down));
        }

        [Fact]
        public void FillingWithLightWithASplitterEndsAtEdgeOfContraption()
        {
            List<string> input = [
                @"...",
                 ".-."
            ];
            var contraption = new Contraption(input);

            contraption.FillWithLight(0, 1, Direction.Down);

            var energisedTiles = contraption.EnergisedTiles;

            energisedTiles.Count.Should().Be(4);
            energisedTiles.Contains((1, 0, Direction.Left));
            energisedTiles.Contains((1, 2, Direction.Right));
        }

        [Fact]
        public void FillingWithLightEndsWhenHeadingInTheSamePositionAndDirection()
        {
            List<string> input = [
                @"/\.",
                @"|..",
                @"\/."
            ];
            var contraption = new Contraption(input);

            contraption.FillWithLight(1, 2, Direction.Left);

            var energisedTiles = contraption.UniqueEnergisedTiles;

            energisedTiles.Count.Should().Be(7);
        }
    }
}
