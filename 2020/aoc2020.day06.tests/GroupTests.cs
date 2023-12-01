using FluentAssertions;

namespace aoc2020.day06.tests
{
    public class GroupTests
    {
        [Fact]
        public void ThreePeopleAnsweringFourQuestionsWithSixUniqueQuestionsAnsweredByAnyone()
        {
            var answers = new[] { "abcx", "abcy", "abcz" };

            var numberOfQuestionsAnswered = AnswerAnalyser.NumberOfUniqueQuestionsAnsweredByAnyone(answers);

            numberOfQuestionsAnswered.Should().Be(6);
        }

        [Fact]
        public void ThreePeopleAnsweringFourQuestionsWithSixUniqueQuestionsAnsweredByEveryone()
        {
            var answers = new[] { "abcx", "abcy", "abcz" };

            var numberOfQuestionsAnswered = AnswerAnalyser.NumberOfUniqueQuestionsAnsweredByEveryone(answers);

            numberOfQuestionsAnswered.Should().Be(3);
        }
    }
}
