using System.Diagnostics;
using AoC.Core;

namespace AoC.Day01;

public class Day1 : IDay
{
    private SonarScannerReport? _sonarScannerReport;

    public void Initialise(string[] input)
    {
        _sonarScannerReport = new SonarScannerReport(Array.ConvertAll(input, Parser.ParseLine));
    }

    public int ChallengeOne()
    {
        Debug.Assert(_sonarScannerReport != null, nameof(_sonarScannerReport) + " != null");
        return _sonarScannerReport.GetIncreasesInDepthByDay();
    }

    public int ChallengeTwo()
    {
        Debug.Assert(_sonarScannerReport != null, nameof(_sonarScannerReport) + " != null");
        return _sonarScannerReport.GetIncreasesInDepthBySlidingWindow();
    }
}