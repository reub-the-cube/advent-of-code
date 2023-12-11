using static aoc2023.day11.domain.Enums;

namespace aoc2023.day11
{
    public class GalaxyImage
    {
        private SpaceMatter[,] _spaceMap;

        public GalaxyImage(SpaceMatter[,] spaceMap)
        {
            _spaceMap = spaceMap;
        }


        public static GalaxyImage Expand(List<string> galaxyImageInput)
        {
            var horizontallyExpandedImage = ExpandHorizontally(galaxyImageInput);
            var verticallyExpandedImage = ExpandVertically(horizontallyExpandedImage);

            // Build map
            var rowCount = verticallyExpandedImage.Count;
            var columnCount = verticallyExpandedImage[0].Length;
            var spaceMap = new SpaceMatter[rowCount, columnCount];

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    spaceMap[i, j] = verticallyExpandedImage[i][j] == '.' ? SpaceMatter.EmptySpace : SpaceMatter.Galaxy;
                }
            }

            return new GalaxyImage(spaceMap);
        }

        private static List<string> ExpandHorizontally(List<string> currentImage)
        {
            var emptySpaceColumns = GetEmptyColumns(currentImage);
            var expandedImage = AddHorizontalSpace(currentImage, emptySpaceColumns);
            return expandedImage;
        }

        private static List<string> ExpandVertically(List<string> currentImage)
        {
            var emptySpaceRows = GetEmptyRows(currentImage);
            var expandedImage = AddVerticalSpace(currentImage, emptySpaceRows);
            return expandedImage;
        }

        private static List<int> GetEmptyColumns(List<string> image)
        {
            var emptySpaceColumns = new List<int>();

            // Expand horizontally
            for (int j = 0; j < image[0].Length; j++)
            {
                if (image.All(g => g[j] == '.'))
                {
                    emptySpaceColumns.Add(j);
                }
            }

            return emptySpaceColumns;
        }

        private static List<int> GetEmptyRows(List<string> image)
        {
            var emptySpaceRows = new List<int>();

            // Expand vertically
            for (int i = 0; i < image.Count; i++)
            {
                if (image[i].All(g => g == '.'))
                {
                    emptySpaceRows.Add(i);
                }
            }

            return emptySpaceRows;
        }

        private static List<string> AddHorizontalSpace(List<string> currentImage, List<int> emptySpaceColumns)
        {
            var expandedInput = new List<string>();
            foreach (string galaxyRowInput in currentImage)
            {
                string rowInput = galaxyRowInput;
                int numberOfSpacesAdded = 0;
                foreach (int emptySpaceColumn in emptySpaceColumns)
                {
                    rowInput = rowInput.Insert(emptySpaceColumn + numberOfSpacesAdded, ".");
                    numberOfSpacesAdded++;
                }

                expandedInput.Add(rowInput);
            }

            return expandedInput;
        }

        private static List<string> AddVerticalSpace(List<string> currentImage, List<int> emptySpaceRows)
        {
            var expandedInput = new List<string>();
            for (int i = 0; i < currentImage.Count; i++)
            {
                if (emptySpaceRows.Contains(i))
                {
                    expandedInput.AddRange(Enumerable.Repeat(currentImage[i], 2));
                }
                else
                {
                    expandedInput.Add(currentImage[i]);
                }
            }

            return expandedInput;
        }

        public (int Width, int Height) GetSize()
        {
            return (_spaceMap.GetUpperBound(1) + 1, _spaceMap.GetUpperBound(0) + 1);
        }
    }
}
