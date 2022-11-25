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
        return _depthMeasurements
            .GetNumberOfTimesNextElementIsGreaterThanThePrevious();
    }

    public int GetIncreasesInDepthBySlidingWindow()
    {
        if (_depthMeasurements.Length < 2) return 0;
        
        return _depthMeasurements
            .GetAggregatedValuesOfThisAndSubsequentElements(2)
            .GetNumberOfTimesNextElementIsGreaterThanThePrevious();
    }
}
