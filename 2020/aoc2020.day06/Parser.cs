using AoC.Core;
using aoc2020.day06.domain;

namespace aoc2020.day06
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var groupAnswers = new List<string[]>();
            var answersForCurrentGroup = new List<string>();

            foreach (var item in input)
            {
                if (item == string.Empty)
                {
                    groupAnswers.Add(answersForCurrentGroup.ToArray());
                    answersForCurrentGroup = new List<string>();
                }
                else
                {
                    answersForCurrentGroup.Add(item);
                }
            }

            groupAnswers.Add(answersForCurrentGroup.ToArray());

            return new Input(groupAnswers);
        }
    }
}
