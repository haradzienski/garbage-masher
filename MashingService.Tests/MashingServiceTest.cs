using System;
using Xunit;
using MashingService;

namespace MashingService.Tests
{
    public class MashingServiceTest
    {
        [Fact]
        public void Mash_ShouldCompactString_WhenDoingSoShortensIt()
        {
            var masher = new MashingService();

            var mashed = masher.Mash("uuueeeenzzzzz");

            Assert.Equal("u3e4nz5", mashed);
        }

        [Fact]
        public void Mash_ShouldNotCompactSymbols_ThatOnlyOccurTwice() {
            var masher = new MashingService();

            var mashed = masher.Mash("uuueeeennzzzzz");

            Assert.Equal("u3e4nnz5", mashed);
        }
    }
}
