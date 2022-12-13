using FluentAssertions;

namespace aoc2022.day13.tests
{
    public class ParserTests
    {
        [Fact]
        public void SimpleListCanCompareWhenInRightOrder()
        {
            var packetOne = "[1,1,3,1,1]";
            var packetTwo = "[1,1,5,1,1]";

            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(-1);
        }

        [Fact]
        public void SimpleListCanCompareWhenInIncorrectOrder()
        {
            var packetOne = "[1,1,5,1,1]";
            var packetTwo = "[1,1,3,1,1]";

            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(1);
        }

        [Fact]
        public void SimpleListCanCompareWhenOrderCannotBeDetermined()
        {
            var packetOne = "[1,1,3,1,1]";
            var packetTwo = "[1,1,3,1,1]";

            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(0);
        }

        [Fact]
        public void NestedListCanCompareWhenInRightOrder()
        {
            var packetOne = "[[1],[2,3,4]]";
            var packetTwo = "[[1],4]";

            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(-1);
        }

        [Fact]
        public void NestedListCanCompareWhenInIncorrectOrder()
        {
            var packetOne = "[9]";
            var packetTwo = "[[8,7,6]]";

            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(1);
        }

        [Fact]
        public void NestedListCanCompareWhenInRightOrderDueToLength()
        {
            var packetOne = "[[4,4],4,4]";
            var packetTwo = "[[4,4],4,4,4]";

            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(-1);
        }

        [Fact]
        public void NestedListCanCompareWhenInIncorrectOrderDueToLength()
        {
            var packetOne = "[[4,4],4,4,4]";
            var packetTwo = "[[4,4],4,4]";

            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(1);
        }

        [Fact]
        public void SimpleListCanCompareWhenInIncorrectOrderDueToLength()
        {
            var packetOne = "[7,7,7,7]";
            var packetTwo = "[7,7,7]";

            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(1);
        }

        [Fact]
        public void SimpleEmptyListCanCompareWhenInRightOrderDueToLength()
        {
            var packetOne = "[]";
            var packetTwo = "[3]";

            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(-1);
        }

        [Fact]
        public void SimpleEmptyListCanCompareWhenInIncorrectOrderDueToLength()
        {
            var packetOne = "[2]";
            var packetTwo = "[]";

            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(1);
        }

        [Fact]
        public void NestedEmptyListsCanCompareWhenInIncorrectOrderDueToLength()
        {
            var packetOne = "[[[]]]";
            var packetTwo = "[[]]";

            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(1);
        }

        [Fact]
        public void ComplexNestedListCanCompareWhenInIncorrectOrder()
        {
            var packetOne = "[1,[2,[3,[4,[5,6,7]]]],8,9]";
            var packetTwo = "[1,[2,[3,[4,[5,6,0]]]],8,9]";

            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(1);
        }

        [Theory]
        [InlineData("[1,1,3,1,1]", new string[] { "1", "1", "3", "1", "1" })]
        [InlineData("[[1],[2,3,4]]", new string[] { "[1]", "[2,3,4]" })]
        [InlineData("[[1],4]", new string[] { "[1]", "4" })]
        [InlineData("[[8,7,6]]", new string[] { "[8,7,6]" })]
        [InlineData("[]", new string[] { })]
        [InlineData("[[]]", new string[] { "[]" })]
        [InlineData("[[[]]]", new string[] { "[[]]" })]
        [InlineData("[1,[2,[3,[4,[5,6,7]]]],8,9]", new string[] { "1", "[2,[3,[4,[5,6,7]]]]", "8", "9" })]
        public void CanMapStringToList(string flatString, string[] expectedResult)
        {
            var actualResult = Parser.MapStringToList(flatString);

            actualResult.Should().HaveCount(expectedResult.Length);
            for (int i = 0; i < actualResult.Count; i++)
            {
                actualResult[i].Should().Be(expectedResult[i]);
            }
        }

        [Fact]
        public void AdditionalExtraTestsFromRealDataOne()
        {
            var packetOne = "[[[],10,[[6],[]],3,1]]";
            var packetTwo = "[[6,8,[9,2],7,2],[[10,[4],[6,2,9,2],[8,8,9]],8,[4],[[0,2]]]]";

            /*
             * [[],10,[[6],[]],3,1]
             * [6,8,[9,2],7,2],[[10,[4],[6,2,9,2],[8,8,9]],8,[4],[[0,2]]]
             * 
             * [] vs 6 -> [] vs [6] -> -1
             * 
             */
            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(-1);
        }

        [Fact]
        public void AdditionalExtraTestsFromRealDataTwo()
        {
            var packetOne = "[[10,[[2,3,9,10],[8,4,3,8]],2,2,[8,8,2,[2,0,9]]],[[[2,0,7,4,2]],9,[[3,8,7,3]],3,9]]";
            var packetTwo = "[[1],[[]],[1,[]]]";

            /*
             * [10,[[2,3,9,10],[8,4,3,8]],2,2,[8,8,2,[2,0,9]]],   [[[2,0,7,4,2]],9,[[3,8,7,3]],3,9]
             * [1],                                               [[]],                                [1,[]]
             * 
             * 10 vs 1 -> 1
             * 
             */
            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(1);
        }

        [Fact]
        public void AdditionalExtraTestsFromRealDataThree()
        {
            var packetOne = "[[[[10,4,9,5],[9,10,0,2],8,[],1],3,[4],1],[6]]";
            var packetTwo = "[[[[10,5,2,0]],10],[[[8,6],8,[3],[4],0]],[2,10,[9,[]],9,2],[1,3,[1,[4,9,9],[7,2,1,0],[5,2,6,1]]],[[[4,9,1,7,2]]]]";

            /*
             * [[[10,4,9,5],[9,10,0,2],8,[],1],3,[4],1],            [6]
             * [[[10,5,2,0]],10],                                   [[[8,6],8,[3],[4],0]],      [2,10,[9,[]],9,2],      [1,3,[1,[4,9,9],[7,2,1,0],[5,2,6,1]]],             [[[4,9,1,7,2]]]
             * 
             * [[10,4,9,5],[9,10,0,2],8,[],1],      3,      [4],        1
             * [[10,5,2,0]],                        10
             * 
             * [10,4,9,5],      [9,10,0,2],         8,      [],         1
             * [10,5,2,0]
             * 
             * 
             */
            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(-1);
        }

        [Fact]
        public void AdditionalExtraTestsFromRealDataFour()
        {
            var packetOne = "[[2],[],[],[3,10,6,0,[0,[7,2,8],4]]]";
            var packetTwo = "[[],[0,[0,7],5,[7,[9],9],1],[[[],4,[],[7,1],[4,9]],[],[1,10],0,[]],[]]";

            /*
             * [2],     [],[],[3,10,6,0,[0,[7,2,8],4]]
             * [],      [0,[0,7],5,[7,[9],9],1],[[[],4,[],[7,1],[4,9]],[],[1,10],0,[]],[]
             * 
             * 
             * 
             */
            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(1);
        }

        [Fact]
        public void AdditionalExtraTestsFromRealDataFive()
        {
            var packetOne = "[[],[2],[[[10,8,5,6,1],7,3,[5]],[[2,9,7,7],1],[[0,1,0],[0],1,10,[8,10,4]],0],[[],7,[[10,9,5,6,3],3],[[1,1,6,9],6,3]],[6,[[5,4]],[]]]";
            var packetTwo = "[[4,3],[[2,8,[8,5]],[3],[1,[10],7,[10,2,5,6]]],[6]]";

            /*
             * [],[2],[[[10,8,5,6,1],7,3,[5]],[[2,9,7,7],1],[[0,1,0],[0],1,10,[8,10,4]],0],[[],7,[[10,9,5,6,3],3],[[1,1,6,9],6,3]],[6,[[5,4]],[]]
             * [4,3],[[2,8,[8,5]],[3],[1,[10],7,[10,2,5,6]]],[6]
             * 
             * 
             * 
             */
            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(-1);
        }

        [Fact]
        public void AdditionalExtraTestsFromRealDataSix()
        {
            var packetOne = "[[],[[],[3],[0,6,5,10],[]],[],[[]]]";
            var packetTwo = "[[2,[],8,[3,2,8,3]]]";

            /*
             * [],                      [[],[3],[0,6,5,10],[]],[],[[]]
             * [2,[],8,[3,2,8,3]]
             * 
             * 
             * 
             */
            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(-1);
        }

        [Fact]
        public void AdditionalExtraTestsFromRealDataSeven()
        {
            var packetOne = "[[3,7,10,6,[[6,2,3,10],[],[6],[2,10,9]]],[[[4,8,9],[10,0,1],0,0,[7,1,10,2,5]],4,9,9],[10],[[]]]";
            var packetTwo = "[[[8,9,[3,8,3,2],2,7],4,[[4,3,2,0],1,[8,6],[]]],[]]";

            /*
             * [3,7,10,6,[[6,2,3,10],[],[6],[2,10,9]]],                 [[[4,8,9],[10,0,1],0,0,[7,1,10,2,5]],4,9,9],[10],[[]]
             * [[8,9,[3,8,3,2],2,7],4,[[4,3,2,0],1,[8,6],[]]],          []
             * 
             * 3,                                                       7,10,6,[[6,2,3,10],[],[6],[2,10,9]]
             * [8,9,[3,8,3,2],2,7],                                     4,[[4,3,2,0],1,[8,6],[]]
             * 
             */
            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(-1);
        }

        [Fact]
        public void AdditionalExtraTestsFromRealDataEight()
        {
            var packetOne = "[[],[[[],6,5],[[8,5],1,[6,2],8,6]],[[2,[],7,6,[7]],[6,10,[],10,[9,4,9,6]],[1,1,4,[5,8],0],7],[0,10,1],[7,[[3,3,9],8,[],[2]]]]";
            var packetTwo = "[[3,9],[],[6,10,[[4,3,2,8],2],[1,[],[5,9,10],9,[7,6]],[2,[4,10],5]],[5]]";

            /*
             * [],                      [[[],6,5],[[8,5],1,[6,2],8,6]],[[2,[],7,6,[7]],[6,10,[],10,[9,4,9,6]],[1,1,4,[5,8],0],7],[0,10,1],[7,[[3,3,9],8,[],[2]]]
             * [3,9],                   [],[6,10,[[4,3,2,8],2],[1,[],[5,9,10],9,[7,6]],[2,[4,10],5]],[5]
             * 
             * 
             * 
             */
            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(-1);
        }

        [Fact]
        public void AdditionalExtraTestsFromRealDataNine()
        {
            var packetOne = "[[10,6]]";
            var packetTwo = "[[[[],[],3,[0,6],9]]]";

            /*
             * [10,6]
             * [[[],[],3,[0,6],9]]
             * 
             * 10,                      6
             * [[],[],3,[0,6],9]
             * 
             * 10
             * [],                      [],3,[0,6],9
             */
            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(1);
        }

        [Fact]
        public void AdditionalExtraTestsFromRealDataTen()
        {
            var packetOne = "[[7,4],[[[]],8,[[],3,7,[0,10],[8,7]]],[[8,10,8],6,[],4,[7,8,[2]]],[[[10,9],2,7,[],4]],[]]";
            var packetTwo = "[[[[7],4,5,5,[2,0,8]],0,[[10,5,8],[5,8,3,7],[5,10,6,3],2],7]]";

            /*
             * - Compare [7,4] vs [[[[7],4,5,5,[2,0,8]],0,[[10,5,8],[5,8,3,7],[5,10,6,3],2],7]]
             *   - Compare 7 vs [[[7],4,5,5,[2,0,8]],0,[[10,5,8],[5,8,3,7],[5,10,6,3],2],7]
             *     - Mixed types; convert 7 to [7] and retry
             *     - Compare [7] vs [[[7],4,5,5,[2,0,8]],0,[[10,5,8],[5,8,3,7],[5,10,6,3],2],7]
             *       - Compare 7 vs [[7],4,5,5,[2,0,8]],0,[[10,5,8],[5,8,3,7],[5,10,6,3],2]
             *         - Mixed types; convert 7 to [7] and retry
             *         - Compare [7] vs [[7],4,5,5,[2,0,8]],0,[[10,5,8],[5,8,3,7],[5,10,6,3],2]
             *           - Compare 7 vs [7]
             *             - Mixed types; convert 7 to [7] and retry
             *             - Compare [7] vs [7]
             *           - Left side ran out of items, so inputs are in the right order
             * 
             * 
             * 
             */
            var result = Parser.ComparePacketData(packetOne, packetTwo);

            result.Should().Be(-1);
        }
    }
}
