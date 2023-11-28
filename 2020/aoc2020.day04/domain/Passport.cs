namespace aoc2020.day04.domain
{
    public record Passport(
        string? BirthYear,
        string? IssueYear,
        string? ExpirationYear,
        string? Height,
        string? HairColour,
        string? EyeColour,
        string? PassportId,
        string? CountryId) { }
}