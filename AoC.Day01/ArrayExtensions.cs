namespace AoC.Day01;

public static class ArrayExtensions
{
    public static int GetNumberOfTimesNextElementIsGreaterThanThePrevious(this IReadOnlyList<int> values)
    {
        var increases = 0;
        
        for (var i = 1; i < values.Count; i++)
        {
            var previousMeasurement = values[i - 1];
            var thisMeasurement = values[i];

            if (thisMeasurement > previousMeasurement)
            {
                increases++;
            }
        }
        
        return increases;
    }

    public static int[] GetAggregatedValuesOfThisAndSubsequentElements(this IReadOnlyList<int> values, int numberOfFollowingElementsToInclude)
    {
        var aggregatedValues = new int[values.Count - numberOfFollowingElementsToInclude];
        
        for (var i = 0; i < values.Count - numberOfFollowingElementsToInclude; i++)
        {
            var thisMeasurement = values[i];
            var nextMeasurement = values[i + 1];
            var nextButOneMeasurement = values[i + 2];

            aggregatedValues[i] = thisMeasurement + nextMeasurement + nextButOneMeasurement;
        }

        return aggregatedValues;
    }
}