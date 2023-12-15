using aoc2023.day15.domain;
using FluentAssertions;
using static aoc2023.day15.Enums;

namespace aoc2023.day15.tests
{
    public class StepHandlerTests
    {
        [Fact]
        public void CanAddALensToABox()
        {
            var stepHandler = new StepHandler();
            var lens = new Lens("rn", 1);

            var boxAddedTo = stepHandler.AddLens(lens);
            var lenses = stepHandler.GetLenses(boxAddedTo);

            lenses.Should().HaveCount(1);
            lenses[0].Label.Should().Be("rn");
            lenses[0].FocalLength.Should().Be(1);
        }

        [Fact]
        public void CanAddALensToABoxForASecondTime()
        {
            var stepHandler = new StepHandler();
            var lens = new Lens("rn", 1);

            _ = stepHandler.AddLens(lens);

            lens = new Lens("rn", 2);
            var boxAddedTo = stepHandler.AddLens(lens);
            var lenses = stepHandler.GetLenses(boxAddedTo);

            lenses.Should().HaveCount(1);
            lenses[0].Label.Should().Be("rn");
            lenses[0].FocalLength.Should().Be(2);
        }

        [Fact]
        public void CanAddANewLensToTheSameBox()
        {
            var stepHandler = new StepHandler();
            var lensOne = new Lens("rn", 1);
            var lensTwo = new Lens("cm", 2);

            _ = stepHandler.AddLens(lensOne);
            var boxAddedTo = stepHandler.AddLens(lensTwo);
            var lenses = stepHandler.GetLenses(boxAddedTo);

            lenses.Should().HaveCount(2);
            lenses[0].Label.Should().Be("rn");
            lenses[1].Label.Should().Be("cm");
            lenses[0].FocalLength.Should().Be(1);
            lenses[1].FocalLength.Should().Be(2);
        }

        [Fact]
        public void CanRemoveALensFromABoxEvenIfItDidNotExist()
        {
            var stepHandler = new StepHandler();
            var lens = new Lens("rn", 1);

            var boxRemovedFrom = stepHandler.RemoveLens(lens);
            var lenses = stepHandler.GetLenses(boxRemovedFrom);

            lenses.Should().HaveCount(0);
        }

        [Fact]
        public void CanRemoveALensFromABoxIfItDidExist()
        {
            var stepHandler = new StepHandler();
            var lens = new Lens("rn", 1);

            _ = stepHandler.AddLens(lens);
            var boxRemovedFrom = stepHandler.RemoveLens(lens);
            var lenses = stepHandler.GetLenses(boxRemovedFrom);

            lenses.Should().HaveCount(0);
        }

        [Fact]
        public void CanRemoveALensFromABoxIfAnotherLensExists()
        {
            var stepHandler = new StepHandler();
            var lensOne = new Lens("rn", 1);
            var lensTwo = new Lens("cm", 1);

            _ = stepHandler.AddLens(lensOne);
            var boxRemovedFrom = stepHandler.RemoveLens(lensTwo);
            var lenses = stepHandler.GetLenses(boxRemovedFrom);

            lenses.Should().HaveCount(1);
            lenses[0].Label.Should().Be("rn");
        }

        [Fact]
        public void CanRemoveALensFromABoxIfAnotherLensExistsThenAddToTheEnd()
        {
            var stepHandler = new StepHandler();
            var lensOne = new Lens("rn", 1);
            var lensTwo = new Lens("cm", 1);

            _ = stepHandler.AddLens(lensOne);
            _ = stepHandler.AddLens(lensTwo);
            _ = stepHandler.RemoveLens(lensOne);
            var boxAddedTo = stepHandler.AddLens(lensOne);
            var lenses = stepHandler.GetLenses(boxAddedTo);

            lenses.Should().HaveCount(2);
            lenses[0].Label.Should().Be("cm");
            lenses[1].Label.Should().Be("rn");
        }

        [Fact]
        public void ParseRemoveInputToStep()
        {
            var input = "abc-";

            var step = StepHandler.ParseStep(input);

            step.Lens.Label.Should().Be("abc");
            step.Lens.FocalLength.Should().Be(-1);
            step.Operator.Should().Be(StepOperator.Remove);
        }

        [Fact]
        public void ParseAddInputToStep()
        {
            var input = "abc=9";

            var step = StepHandler.ParseStep(input);

            step.Lens.Label.Should().Be("abc");
            step.Lens.FocalLength.Should().Be(9);
            step.Operator.Should().Be(StepOperator.Add);
        }

        [Fact]
        public void ProcessStepAddsLensToBox()
        {
            var input = "qp=3";

            var stepHandler = new StepHandler();
            var boxChanged = stepHandler.ProcessStep(input);

            var lenses = stepHandler.GetLenses(boxChanged);

            lenses.Should().HaveCount(1);
        }

        [Fact]
        public void ProcessStepDoesNotAddLensToBox()
        {
            var input = "abc-";

            var stepHandler = new StepHandler();
            var boxChanged = stepHandler.ProcessStep(input);

            var lenses = stepHandler.GetLenses(boxChanged);

            lenses.Should().HaveCount(0);
        }
    }
}

// Hash the label to get the box (0-255) - split by =/-
// for a -, remove the lens if it is present with that label - bring remaining lenses forward
// for a =, replace if it exists, add to end if it doesn't