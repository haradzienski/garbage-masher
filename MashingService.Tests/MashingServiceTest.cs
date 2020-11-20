using System;
using Xunit;
using MashingService;

namespace MashingService.Tests
{
    public class MashingServiceTest
    {
        private readonly MashingService subject;

        public MashingServiceTest() {
            subject = new MashingService();
        }

        [Fact]
        public void Mash_ShouldCompactString_WhenDoingSoShortensIt()
        {
            var mashed = subject.Mash("uuueeeenzzzzz");

            Assert.Equal("u3e4nz5", mashed);
        }

        [Fact]
        public void Mash_ShouldNotCompactSymbols_ThatOnlyOccurTwice() {
            var mashed = subject.Mash("uuueeeennzzzzz");

            Assert.Equal("u3e4nnz5", mashed);
        }

        [Fact]
        public void Mash_ShouldReturnEmptyString_WhenGivenEmptyString() {
            var mashed = subject.Mash("");

            Assert.Equal(String.Empty, mashed);
        }

        [Fact]
        public void Mash_ShouldReturnEmptyString_WhenGivenNull() {
            var mashed = subject.Mash(null);

            Assert.Equal(String.Empty, mashed);
        }

        [Fact]

        public void Mash_ShouldCorrectlyAccountForSeparateCharacterGroups_WhenTheyArePresent() {
            var mashed = subject.Mash("uuuueeeeuuuunnnn");

            Assert.Equal("u4e4u4n4", mashed);
        }

        [Fact]
        public void Mash_ShouldCompactDigitsEscapingThem_WhenInputStringContainsDigits() {
            var mashed = subject.Mash("aaabbccc111223333");

            Assert.Equal("a3bbc3\\13\\2\\2\\34", mashed);
        }

        [Fact]
        public void Mash_ShouldReturnOriginalString_WhenCompactedOneIsEqualOrLonger() {
            var originalString = "abc0123456789";
            var mashed = subject.Mash(originalString);

            Assert.Equal(originalString, mashed);
        }
    }
}
