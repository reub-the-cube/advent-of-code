using AoC.Core;
using aoc2020.day04.domain;

namespace aoc2020.day04
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var parsedInput = new Input();
            var passportFields = new Dictionary<string, string>();

            foreach (string passportData in input) {
                if (passportData == string.Empty) {
                    parsedInput.AddPassport(BuildPassportFromDataFields(passportFields));
                    passportFields.Clear();
                } else {
                    var passportDataFields = passportData.Split(" ").ToList();
                    foreach (string dataField in passportDataFields) {
                        passportFields.Add(dataField.Split(":")[0], dataField.Split(":")[1]);
                    }
                }
            }

            parsedInput.AddPassport(BuildPassportFromDataFields(passportFields));

            return parsedInput;
        }

        private static Passport BuildPassportFromDataFields(Dictionary<string, string> passportFields) {
            passportFields.TryGetValue("byr", out string? birthYear);
            passportFields.TryGetValue("iyr", out string? issueYear);
            passportFields.TryGetValue("eyr", out string? expiryYear);
            passportFields.TryGetValue("hgt", out string? height);
            passportFields.TryGetValue("hcl", out string? hairColour);
            passportFields.TryGetValue("ecl", out string? eyeColour);
            passportFields.TryGetValue("pid", out string? passportId);
            passportFields.TryGetValue("cid", out string? countryId);

            return new Passport(birthYear, issueYear, expiryYear, height, hairColour, eyeColour, passportId, countryId);
        }
    }
}
