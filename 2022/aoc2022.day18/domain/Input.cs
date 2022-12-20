using System;

namespace aoc2022.day18.domain
{
    public class Input
    {
        private List<Cube> Cubes { get; set; }

        public Input(List<Cube> cubes)
        {
            Cubes = cubes;
        }

        public List<Cube> GetCubes()
        {
            return Cubes;
        }
    }
}