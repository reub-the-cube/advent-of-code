using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023.day15.tests
{
    public class HasherTests
    {
        [Fact]
        public void HashingACharacterWithACurrentValueOfZero()
        {
            var hasher = Hasher.HashCharacter('H');

            hasher.Should().Be(200);
        }

        [Fact]
        public void HashingACharacterWithACurrentValueOf200()
        {
            var hasher = Hasher.HashCharacter('A', 200);

            hasher.Should().Be(153);
        }

        [Fact]
        public void HashingACharacterWithACurrentValueOf153()
        {
            var hasher = Hasher.HashCharacter('S', 153);

            hasher.Should().Be(172);
        }

        [Fact]
        public void HashingACharacterWithACurrentValueOf172()
        {
            var hasher = Hasher.HashCharacter('H', 172);

            hasher.Should().Be(52);
        }

        [Fact]
        public void HashingTheWordHashReturns52()
        {
            var hasher = Hasher.HashString("HASH");

            hasher.Should().Be(52);
        }
    }
}
