using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020.day06
{
    public static class AnswerAnalyser
    {
        public static int NumberOfUniqueQuestionsAnsweredByAnyone(string[] answers)
        {
            var allAnswers = answers.SelectMany(s => s);

            return allAnswers.Distinct().Count();
        }

        public static int NumberOfUniqueQuestionsAnsweredByEveryone(string[] answers)
        {
            var numberOfPeople = answers.Length;
            var allAnswers = answers.SelectMany(s => s);
            var answersGroupedByAnswer = allAnswers.GroupBy(a => a);

            return answersGroupedByAnswer.Count(g => g.Count() == numberOfPeople);
        }
    }
}
