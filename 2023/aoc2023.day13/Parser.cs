using AoC.Core;
using aoc2023.day13.domain;

namespace aoc2023.day13
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var pattern = new List<string>();
            var patternList = new List<Pattern>();

            foreach (var inputItem in input)
            {
                if (inputItem == string.Empty)
                {
                    patternList.Add(new Pattern(pattern.ToList()));
                    pattern.Clear();
                }
                else
                {
                    pattern.Add(inputItem);
                }
            }

            patternList.Add(new Pattern(pattern));

            return new Input(patternList);
        }
    }
}
