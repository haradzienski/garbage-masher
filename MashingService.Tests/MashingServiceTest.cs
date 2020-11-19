using System;
using Xunit;
using MashingService;

namespace MashingService.Tests
{
    public class MashingServiceTest
    {
        [Fact]
        public void Mash_CompactsString_WhenDoingSoShortensIt()
        {
            var masher = new MashingService();

            var mashed = masher.Mash("uuueeeenzzzzz");

            Assert.Equal("u3e4nz5", mashed);
        }
    }
}
