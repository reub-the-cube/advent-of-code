using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc.day04.Models
{
    public class Board
    {
        public bool HasCompleteColumn { get; private set; }
        public bool HasCompleteRow { get; private set; }

        private Cell[][] Cells = Array.Empty<Cell[]>();

        public Board Fill(int numberOfColumns, string[] cellValues)
        {
            Cells = cellValues.Select(v => new Cell(Convert.ToInt16(v), false)).Chunk(numberOfColumns).ToArray();
            return this;
        }

        public (bool Found, int Column, int Row) Find(int value)
        {
            int rowIndex = Array.FindIndex(Cells, c => c.Any(a => a.Value == value));
            if (rowIndex < 0)
                return (false, -1, -1);

            int columnIndex = Array.FindIndex(Cells[rowIndex], c => c.Value == value);
            if (columnIndex < 0)
                return(false, -1, -1);

            return (true, columnIndex, rowIndex);
        }

        public Board Mark(int row, int column)
        {
            Cells[row][column] = new Cell(Cells[row][column].Value, true);
            HasCompleteColumn = Cells.All(a => a[column].Marked);
            HasCompleteRow = Cells[row].All(a => a.Marked);

            return this;
        }

        public int GetUnmarkedTotal()
        {
            return Cells.Sum(c => c.Sum(d => d.Marked ? 0 : d.Value));
        }
    }

    internal readonly record struct Cell(int Value, bool Marked);
}
