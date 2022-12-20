namespace aoc2022.day20.domain
{
    public class Decryptor
    {
        public static List<KeyValuePair<long, long>> MixListOfNumbers(Dictionary<long, long> originalNumbers, int decryptionKey, int numberOfMixings)
        {
            var decryptedNumbers = originalNumbers.ToDictionary(k => k.Key, k => k.Value * decryptionKey);
            var workingList = decryptedNumbers.ToList();

            var modulus = originalNumbers.Count - 1;

            for (int i = 1; i < numberOfMixings + 1; i++)
            {
                foreach (var item in decryptedNumbers)
                {
                    var indexOfNumber = workingList.IndexOf(item);

                    var newIndex = (indexOfNumber + item.Value) % modulus;
                    if (newIndex < 0) newIndex += modulus;
                    if (newIndex == 0 && item.Value < 0) newIndex = modulus;

                    if (newIndex < indexOfNumber)
                    {
                        // Remove the old item, then add the new one
                        workingList.RemoveAt(indexOfNumber);
                        workingList.Insert((int)newIndex, item);
                    }
                    else
                    {
                        // Add the new one, then remove the old one
                        workingList.Insert((int)newIndex + 1, item);
                        workingList.RemoveAt(indexOfNumber);
                    }
                }
            }

            return workingList;
        }
    }
}
