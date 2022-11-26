using static AoC.Day02.Enums;

namespace AoC.Day02
{
    public class JourneyPredictor
    {
        public static (int HorizontalChange, int DepthChange) ProjectFinalHorizontalPositionAndDepth(Models.Input[] instructions)
        {
            var horizontalChange = 0;
            var depthChange = 0;

            foreach (var item in instructions)
            {
                switch (item.Command)
                {
                    case SubmarineCommand.Up:
                        depthChange -= item.UnitsOfChange;
                        break;
                    case SubmarineCommand.Down:
                        depthChange += item.UnitsOfChange;
                        break;
                    case SubmarineCommand.Forward: 
                        horizontalChange += item.UnitsOfChange;
                        break;
                };
            }

            return (horizontalChange, depthChange);
        }

        public static (int HorizontalChange, int DepthChange) ProjectFinalHorizontalPositionAndDepthUsingAim(Models.Input[] instructions)
        {
            var aimChange = 0;
            var horizontalChange = 0;
            var depthChange = 0;

            foreach (var item in instructions)
            {
                switch (item.Command)
                {
                    case SubmarineCommand.Up:
                        aimChange -= item.UnitsOfChange;
                        break;
                    case SubmarineCommand.Down:
                        aimChange += item.UnitsOfChange;
                        break;
                    case SubmarineCommand.Forward:
                        horizontalChange += item.UnitsOfChange;
                        depthChange += (aimChange * item.UnitsOfChange);
                        break;
                };
            }

            return (horizontalChange, depthChange);
        }
    }
}
