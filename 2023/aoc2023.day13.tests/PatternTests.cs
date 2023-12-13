using FluentAssertions;

namespace aoc2023.day13.tests
{
    public class PatternTests
    {
        [Fact]
        public void FindHorizontalLinesAboveReflectionForTwoLinePattern()
        {
            List<string> patternLines = [
                "..#..",
                "..#.."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection();

            linesAboveReflection.Should().Be(1);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForTwoLinePatternWithExtraRowAbove()
        {
            List<string> patternLines = [
                ".....",
                "..#..",
                "..#.."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection();

            linesAboveReflection.Should().Be(2);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForTwoLinePatternWithExtraRowBelow()
        {
            List<string> patternLines = [
                "..#..",
                "..#..",
                "....."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection();

            linesAboveReflection.Should().Be(1);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForFourLinePattern()
        {
            List<string> patternLines = [
                ".....",
                "..#..",
                "..#..",
                "....."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection();

            linesAboveReflection.Should().Be(2);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForFourLinePatternWithMatchAtBottom()
        {
            List<string> patternLines = [
                ".....",
                "....#",
                "..#..",
                "..#.."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection();

            linesAboveReflection.Should().Be(3);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForFourLinePatternWithThreeRepeatedRows()
        {
            List<string> patternLines = [
                ".....",
                "..#..",
                "..#..",
                "..#.."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection();

            linesAboveReflection.Should().Be(3);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForFourLinePatternWithImperfectReflection()
        {
            List<string> patternLines = [
                "...#.",
                "..#..",
                "..#..",
                "....#"
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection();

            linesAboveReflection.Should().Be(-1);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForFiveLinePatternWithFourRepeatedRows()
        {
            List<string> patternLines = [
                ".....",
                "..#..",
                "..#..",
                "..#..",
                "..#.."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection();

            linesAboveReflection.Should().Be(3);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForFiveLinePatternWithExtraRowAbove()
        {
            List<string> patternLines = [
                ".....",
                "....#",
                "..#..",
                "..#..",
                "....#"
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection();

            linesAboveReflection.Should().Be(3);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForFiveLinePatternWithExtraRowBelow()
        {
            List<string> patternLines = [
                "....#",
                "..#..",
                "..#..",
                "....#",
                "....."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection();

            linesAboveReflection.Should().Be(2);
        }

        [Fact]
        public void FindVerticalLinesToLeftOfReflectionForFiveLinePatternWithExtraColumnRight()
        {
            List<string> patternLines = [
                "#..##",
                ".##..",
                ".##..",
                "#..#.",
                "....."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesLeftOfReflection();

            linesAboveReflection.Should().Be(2);
        }

        [Fact]
        public void GetSummarizeScoreForPatternWithHorizontalReflection()
        {
            List<string> patternLines = [
                ".....",
                "....#",
                "..#..",
                "..#..",
                "....#"
            ];

            var pattern = new Pattern(patternLines);
            var summarizeScore = pattern.SummarizeScore();

            summarizeScore.Should().Be(300);
        }

        [Fact]
        public void GetSummarizeScoreForPatternWithVerticalReflection()
        {
            List<string> patternLines = [
                "#..##",
                ".##..",
                ".##..",
                "#..#.",
                "....."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.SummarizeScore();

            linesAboveReflection.Should().Be(2);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForTwoLinePatternWithHashSmudge()
        {
            List<string> patternLines = [
                ".....",
                "..#.."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection(true);

            linesAboveReflection.Should().Be(1);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForTwoLinePatternWithDotSmudge()
        {
            List<string> patternLines = [
                "..#..",
                "....."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection(true);

            linesAboveReflection.Should().Be(1);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForTwoLinePatternWithSmudgeOnFirstCharacter()
        {
            List<string> patternLines = [
                "..#..",
                "#.#.."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection(true);

            linesAboveReflection.Should().Be(1);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForTwoLinePatternWithSmudgeOnLastCharacter()
        {
            List<string> patternLines = [
                "..#..",
                "..#.#"
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection(true);

            linesAboveReflection.Should().Be(1);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForFiveLinePatternWithExtraRowBelowAndAHashSmudgeOnTheFirstReflection()
        {
            List<string> patternLines = [
                "....#",
                "..#..",
                ".....",
                "....#",
                "....."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection(true);

            linesAboveReflection.Should().Be(2);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForFiveLinePatternWithExtraRowBelowAndADotSmudgeOnTheFirstReflection()
        {
            List<string> patternLines = [
                "...##",
                ".....",
                "..#..",
                "...##",
                "....."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection(true);

            linesAboveReflection.Should().Be(2);
        }

        [Fact]
        public void FindHorizontalLinesAboveReflectionForFiveLinePatternWithExtraRowBelowAndASmudgeOnTheSecondReflection()
        {
            List<string> patternLines = [
                "....#",
                "..#..",
                "..#..",
                ".....",
                "....."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection(true);

            linesAboveReflection.Should().Be(2);
        }

        [Fact]
        public void FindVerticalLinesAboveReflectionForFiveLinePatternWithExtraRowBelowAndASmudgeOnTheSecondReflection()
        {
            List<string> patternLines = [
                "....#",
                "..#..",
                "..#..",
                ".....",
                "....."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.NumberOfLinesAboveReflection(true);

            linesAboveReflection.Should().Be(2);
        }
    }
}