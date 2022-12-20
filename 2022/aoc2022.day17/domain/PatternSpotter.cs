namespace aoc2022.day17.domain;

public class PatternSpotter
{
    private Dictionary<Enums.RockShape, HashSet<int>> _rockJetTracker = new()
    {
        {Enums.RockShape.HorizontalLine, new HashSet<int>()},
        {Enums.RockShape.Plus, new HashSet<int>()},
        {Enums.RockShape.MirroredL, new HashSet<int>()},
        {Enums.RockShape.VerticalLine, new HashSet<int>()},
        {Enums.RockShape.Square, new HashSet<int>()}
    };
    
    private Dictionary<(Enums.RockShape RockShape, int JetPatternIndex, string ChamberProfile), (long RockIndex, long Height)> _rockReleaseProfile = new();
    public long CycleDuration { get; private set; }
    public int CycleHeightDelta { get; private set; }
    public bool HasDetectedPattern { get; private set; }
    
    public void AddRockToPattern(Enums.RockShape shapeEnum, int jetPatternIndex, Chamber chamber)
    {
        if (HasDetectedPattern) return;
        
        if (!_rockJetTracker[shapeEnum].Contains(jetPatternIndex))
        {
            _rockJetTracker[shapeEnum].Add(jetPatternIndex);
        }
        else
        {
            // This rock shape has started from this part of the jet pattern before. Is the height profile the same?
            var chamberProfile = chamber.GetProfileForHeights();
            var rockNumber = chamber.NumberOfRocksDropped + 1;
            var highestRock = chamber.GetHighestRock();
            
            if (_rockReleaseProfile.ContainsKey((shapeEnum, jetPatternIndex, chamberProfile)))
            {
                var (rockIndex, height) = _rockReleaseProfile[(shapeEnum, jetPatternIndex, chamberProfile)];
                CycleDuration = rockNumber - rockIndex;
                CycleHeightDelta = (int)(highestRock - height);
                HasDetectedPattern = true;
            }
            else
            {
                _rockReleaseProfile.Add((shapeEnum, jetPatternIndex, chamberProfile), (rockNumber, highestRock));
            }
        }
    }
}