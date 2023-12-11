using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023.day11.tests
{
    public class GalaxyImageTests
    {
        [Fact]
        public void GalaxyImageWithColumnOfSpaceCanExpandHorizontally()
        {
            List<string> galaxyImageInput = [   "##.",
                                                "#..",
                                                ".#."
            ];
            
            var expandedGalaxyImage = GalaxyImage.Expand(galaxyImageInput);

            var dimensions = expandedGalaxyImage.GetSize();

            dimensions.Width.Should().Be(4);
            dimensions.Height.Should().Be(3);
        }

        [Fact]
        public void GalaxyImageWithRowOfSpaceCanExpandVertically()
        {
            List<string> galaxyImageInput = [   "##.",
                                                "#..",
                                                "...",
                                                ".##"
            ];

            var expandedGalaxyImage = GalaxyImage.Expand(galaxyImageInput);

            var dimensions = expandedGalaxyImage.GetSize();

            dimensions.Width.Should().Be(3);
            dimensions.Height.Should().Be(5);
        }

        [Fact]
        public void GalaxyImageCanExpandVerticallyAndHorizontally()
        {
            List<string> galaxyImageInput = [   "##.",
                                                "#..",
                                                "...",
                                                ".#."
            ];

            var expandedGalaxyImage = GalaxyImage.Expand(galaxyImageInput);

            var dimensions = expandedGalaxyImage.GetSize();

            dimensions.Width.Should().Be(4);
            dimensions.Height.Should().Be(5);
        }

        [Fact]
        public void GalaxyImageWithMultipleEmptyRowsAndColumnsCanExpandVerticallyAndHorizontally()
        {
            List<string> galaxyImageInput = [   ".....",
                                                "#.#..",
                                                "#....",
                                                ".....",
                                                ".....",
                                                "..#..",
                                                "....."
            ];

            var expandedGalaxyImage = GalaxyImage.Expand(galaxyImageInput);

            var dimensions = expandedGalaxyImage.GetSize();

            dimensions.Width.Should().Be(8);
            dimensions.Height.Should().Be(11);
        }
    }
}
