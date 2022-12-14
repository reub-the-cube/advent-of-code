using FluentAssertions;

namespace AoC.Day01.Tests;

public class SonarScannerReportIncreaseInDepthTests
{
    [Fact]
    public void TheNumberOfIncreasesIsZeroWhenNoDistancesAreInTheReport()
    {
        var report = new SonarScannerReport(Array.Empty<int>());
        var numberOfIncreases = report.GetIncreasesInDepthByDay();
        numberOfIncreases.Should().Be(0);
    }
    
    [Fact]
    public void TheNumberOfIncreasesIsZeroWhenAllDistancesDecreaseInTheReport()
    {
        int[] distancesMeasured = {5, 4, 3, 2, 1};
        var report = new SonarScannerReport(distancesMeasured);
        var numberOfIncreases = report.GetIncreasesInDepthByDay();
        numberOfIncreases.Should().Be(0);
    }
    
    [Fact]
    public void TheNumberOfIncreasesIsCorrectWhenAllDistancesIncreaseInTheReport()
    {
        int[] distancesMeasured = {1, 2, 3, 4, 5};
        var report = new SonarScannerReport(distancesMeasured);
        var numberOfIncreases = report.GetIncreasesInDepthByDay();
        numberOfIncreases.Should().Be(4);
    }
    
    [Fact]
    public void TheNumberOfIncreasesIsCorrectForTheExampleInTheReadme()
    {
        int[] distancesMeasured = {199, 200, 208, 210, 200, 207, 240, 269, 260, 263};
        var report = new SonarScannerReport(distancesMeasured);
        var numberOfIncreases = report.GetIncreasesInDepthByDay();
        numberOfIncreases.Should().Be(7);
    }
}