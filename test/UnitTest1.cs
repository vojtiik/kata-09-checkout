using Xunit;
using TestStack.BDDfy;
using System.Threading.Tasks;

namespace kata_09_checkout.test
{
    public class Test
    {
        private Checkout _ch = new Checkout();

        [Fact]
        public void It_Scans_And_Totals_Single_Item_Correctly()
        {
            this.Given(x => x.ItemAIsAddedToTheBasket())
                .Then(x => x.BasketReturnsExpetedCount(1))
                .And(x => x.BasketTotalIsCorrect(50))
                .BDDfy();
        }

        [Fact]
        public void It_Scans_And_Totals_TwoSame_Items_Correctly()
        {
            this.Given(x => x.ItemAIsAddedToTheBasket())
                .Given(x => x.ItemAIsAddedToTheBasket())
                .Then(x => x.BasketReturnsExpetedCount(2))
                .And(x => x.BasketTotalIsCorrect(100))
                .BDDfy();
        }

        [Fact]
        public void It_Scans_And_Totals_TwoDifferent_Items_Correctly()
        {
            this.Given(x => x.ItemAIsAddedToTheBasket())
                .Given(x => x.ItemBIsAddedToTheBasket())
                .Then(x => x.BasketReturnsExpetedCount(2))
                .And(x => x.BasketTotalIsCorrect(80))
                .BDDfy();
        }

        [Fact]
        public void It_Applies_Offer()
        {
            this.Given(x => x.ItemAIsAddedToTheBasket())
                .Given(x => x.ItemAIsAddedToTheBasket())
                .Given(x => x.ItemAIsAddedToTheBasket())
                .Then(x => x.BasketReturnsExpetedCount(3))
                .And(x => x.BasketTotalIsCorrect(130))
                .BDDfy();
        }

        private async Task ItemAIsAddedToTheBasket()
        {
            _ch.Scan("A");
        }

        private async Task ItemBIsAddedToTheBasket()
        {
            _ch.Scan("B");
        }

        private async Task BasketReturnsExpetedCount(int count)
        {
            Assert.True(_ch.ItemsCount() == count);
        }

        private async Task BasketTotalIsCorrect(decimal cost)
        {
            Assert.True(_ch.TotalCost() == cost);
        }
    }
}
