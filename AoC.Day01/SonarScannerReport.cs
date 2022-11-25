namespace AoC.Day01;

public class SonarScannerReport
{
    private readonly int[] _depthMeasurements;

    public SonarScannerReport(int[] depthMeasurements)
    {
        _depthMeasurements = depthMeasurements;
    }

    public int GetIncreasesInDepthByDay()
    {
        return GetNumberOfTimesNextElementIsGreaterThanThePrevious(_depthMeasurements);
    }

    public int GetIncreasesInDepthBySlidingWindow()
    {
        return GetNumberOfTimesNextElementIsGreaterThanThePrevious(GetAggregatedValuesOfThisAndNextTwoElements(_depthMeasurements));
    }

    private static int GetNumberOfTimesNextElementIsGreaterThanThePrevious(int[] values)
    {
        var increases = 0;
        
        for (var i = 1; i < values.Length; i++)
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

    private int[] GetAggregatedValuesOfThisAndNextTwoElements(int[] values)
    {
        var aggregatedValues = new int[values.Length - 2];
        
        for (var i = 0; i < values.Length - 2; i++)
        {
            var thisMeasurement = values[i];
            var nextMeasurement = values[i + 1];
            var nextButOneMeasurement = values[i + 2];

            aggregatedValues[i] = thisMeasurement + nextMeasurement + nextButOneMeasurement;
        }

        return aggregatedValues;
    }
}
