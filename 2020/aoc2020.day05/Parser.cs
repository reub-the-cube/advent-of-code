using AoC.Core;
using aoc2020.day05.domain;

namespace aoc2020.day05
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var parsedInput = new Input();

            foreach (var i in input)
            {
                var rowAsBinary = i[..7].Replace('F', '0').Replace('B', '1');
                var columnAsBinary = i.Substring(7, 3).Replace('L', '0').Replace('R', '1');

                var rowValue = Convert.ToInt32(rowAsBinary, 2);
                var columnValue = Convert.ToInt32(columnAsBinary, 2);

                parsedInput.AddSeat(new Seat(rowValue, columnValue));
            }

            return parsedInput;
        }
    }
}
