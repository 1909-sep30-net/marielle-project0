using Project0.BusinessLogic;
using Xunit;

namespace Project0.Test
{
    public class LocationTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("                 ")]
        [InlineData(null)]
        public void BranchNameShouldValidateInputs(string input)
        {
            try
            {
                new Location()
                {
                    BranchName = input
                };
                Assert.True(false);
            }
            catch (InvalidLocationException)
            {
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData("Flagship")]
        [InlineData("      123           ")]
        [InlineData("\nBranch")]
        public void LocationShouldAddValidInputs(string input)
        {
            try
            {
                new Location()
                {
                    BranchName = input
                };
                Assert.True(true);
            }
            catch (InvalidLocationException)
            {
                Assert.True(false);
            }
        }
    }
}