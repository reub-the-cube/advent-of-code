namespace aoc2023.day15
{
    public static class Hasher
    {
        public static int HashString(string stringToHash)
        {
            return stringToHash.Aggregate(0, (currentValue, characterToHash) => HashCharacter(characterToHash, currentValue));
        }

        public static int HashCharacter(char characterToHash)
        {
            return HashCharacter(characterToHash, 0);
        }

        public static int HashCharacter(char characterToHash, int currentValue)
        {
            var asciiCode = (int)characterToHash;

            asciiCode += currentValue;
            asciiCode *= 17;
            asciiCode %= 256;

            return asciiCode;
        }
    }
}
