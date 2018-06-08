using Xunit;
using TestStack.BDDfy;
using System.Threading.Tasks;

namespace kata_09_checkout.test
{
    public class Test
    {
        private Checkout _ch = new Checkout();

        [Fact]
        public void It_Counts_One()
        {
            this.Given(x => x.ItemIsAddedToBasket())
                .Then(x => x.ItReturnsExpetedCount(1))
                .BDDfy();
        }

        private async Task ItemIsAddedToBasket()
        {
            _ch.Scan("A");
        }

        private async Task ItReturnsExpetedCount(int count)
        {
            Assert.True(_ch.ItemsCount() == count);
        }
    }
}
