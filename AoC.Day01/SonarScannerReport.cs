namespace AoC.Day01;
public class SonarScannerReport
{
    private readonly List<int> _depthMeasurements;

    public SonarScannerReport(string[] inputMeasurements)
    {
        _depthMeasurements = new List<int>(Array.ConvertAll(inputMeasurements, Parser.ParseLine));
    }

    public int GetIncreasesInDepthByDay()
    {
        var increases = 0;
        
        for (var i = 1; i < _depthMeasurements.Count; i++)
        {
            var previousMeasurement = _depthMeasurements[i - 1];
            var thisMeasurement = _depthMeasurements[i];

            if (thisMeasurement > previousMeasurement)
            {
                increases++;
            }
        }
        
        return increases;
    }
}
