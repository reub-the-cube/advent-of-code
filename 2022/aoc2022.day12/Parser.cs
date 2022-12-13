using AoC.Core;
using aoc2022.day12.domain;

namespace aoc2022.day12
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            Position? start = null;
            Position? end = null;
            var heights = input.Select(s =>
            {
                var originalRow = s;
                
                if (originalRow.Contains('S'))
                {
                    start = new Position(Array.IndexOf(input, originalRow), Array.IndexOf(s.ToCharArray(), 'S'));
                    s = s.Replace('S', 'a');
                }

                if (s.Contains('E'))
                {
                    end = new Position(Array.IndexOf(input, originalRow), Array.IndexOf(originalRow.ToCharArray(), 'E'));
                    s = s.Replace('E', 'z');
                }
                
                return s.Select(c => Convert.ToInt32(c - 96)).ToArray();
            }).ToArray();

            if (start == null)
            {
                throw new Exception("start position could not be found!");
            }

            if (end == null)
            {
                throw new Exception("end position could not be found!");
            }
            
            return new Input(start.Value, end.Value, heights);
        }
    }
}
