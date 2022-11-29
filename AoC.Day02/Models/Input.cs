using static AoC.Day02.Enums;

namespace AoC.Day02.Models
{
    public readonly record struct MachineReadout(Input[] Inputs);
    public readonly record struct Input(SubmarineCommand Command, int UnitsOfChange);
}
