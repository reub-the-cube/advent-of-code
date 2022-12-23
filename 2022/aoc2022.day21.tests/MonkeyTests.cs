using aoc2022.day21.domain;
using FluentAssertions;

namespace aoc2022.day21.tests
{
    public class MonkeyTests
    {
        [Fact]
        public void CanGetWhatMonkeyYellsByNameIfTheyHaveAPredeterminedNumber()
        {
            var riddle = new Riddle();
            riddle.AddMonkey("rth", 5);

            var number = riddle.GetMonkeyNumber("rth");

            number.Should().Be(5);
        }

        [Fact]
        public void CanGetWhatMonkeyYellsByNameIfTheyHaveADependencyOnAnotherMonkeyWithAPredeterminedNumber()
        {
            var riddle = new Riddle();
            riddle.AddMonkey("rth", 5, "jch", "+");
            riddle.AddMonkey("jch", 6);

            var number = riddle.GetMonkeyNumber("rth");

            number.Should().Be(11);
        }

        [Fact]
        public void CanGetWhatMonkeyYellsByNameIfTheyHaveADependencyOnTwoMonkeysWithAPredeterminedNumber()
        {
            var riddle = new Riddle();
            riddle.AddMonkey("rth", "twh", "jch", "+");
            riddle.AddMonkey("twh", 9);
            riddle.AddMonkey("jch", 6);

            var number = riddle.GetMonkeyNumber("rth");

            number.Should().Be(15);
        }

        [Fact]
        public void CanGetWhatMonkeyYellsByNameIfTheyHaveTwoLevelsOfDependency()
        {
            var riddle = new Riddle();
            riddle.AddMonkey("rth", "twh", "jch", "+");
            riddle.AddMonkey("twh", "awh", "seh", "+");
            riddle.AddMonkey("awh", 6);
            riddle.AddMonkey("seh", 8);
            riddle.AddMonkey("jch", 10);

            var number = riddle.GetMonkeyNumber("rth");

            number.Should().Be(24);
        }

        [Fact]
        public void CanGetWhatMonkeyYellsByNameFromTestScenario()
        {
            var riddle = new Riddle();
            riddle.AddMonkey("root", "pppw", "sjmn", "+");
            riddle.AddMonkey("dbpl", 5);
            riddle.AddMonkey("cczh", "sllz", "lgvd", "+");
            riddle.AddMonkey("zczc", 2);
            riddle.AddMonkey("ptdq", "humn", "dvpt", "-");
            riddle.AddMonkey("dvpt", 2);
            riddle.AddMonkey("lfqf", 2);
            riddle.AddMonkey("humn", 2);
            riddle.AddMonkey("ljgn", 2);
            riddle.AddMonkey("sjmn", "drzm", "dbpl", "*");
            riddle.AddMonkey("sllz", 4);
            riddle.AddMonkey("pppw", "cczh", "lfqf", "/");
            riddle.AddMonkey("lgvd", "ljgn", "ptdq", "*");
            riddle.AddMonkey("drzm", "hmdt", "zczc", "-");
            riddle.AddMonkey("hmdt", 32);

            var number = riddle.GetMonkeyNumber("root");

            number.Should().Be(152);
        }
    }
}
