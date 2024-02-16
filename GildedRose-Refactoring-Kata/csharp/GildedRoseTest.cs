using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        // Tests basic
        [Test]
        public void updateQuality_ReducesSellIn_From10To9()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
        }
        //FUNCTION_Should_Change Quality_Standard_Item
        [Test]
        public void updateQuality_ReducesQuality_3To2()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);
        }

        //FUNCTION_Should_ChangeQualityTwiceAsFast
        [Test]
        public void updateQuality_ReducesQualityBy2WhenSellInLessThanZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(1, Items[0].Quality);
        }

        //FUNCTION_Should_ReducesQualityBy1
        [Test]
        public void updateQuality_ReducesQualityBy1WhenSellInEqualsOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);
        }

        [Test]
        public void updateQuality_ReducesQualityBy2WhenSellInEqualsZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(1, Items[0].Quality);
        }

        //when quality is 0, it should remain at 0 rather than -1
        [Test]
        public void updateQuality_QualityRemainsAtZeroWhenAtZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        // When Name is Aged Brie, Quality Should Increase by 1
        [Test]
        public void updateQuality_QualityIncreaseby1WhenAgedBrie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);
        }

        // When Name is Aged Brie, Quality Should Increase by 1
        [Test]
        public void updateQuality_QualityIncreaseby1WhenAgedBrieAndSellInLessThanZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -5, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);
        }

        //when quality is 50, it should remain at 50 rather than increasing to 51
        [Test]
        public void updateQuality_QualityRemainsAt50WhenAgedBrieQualityIs50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }
        //Sulfuras quality does not decrease
        [Test]
        public void updateQuality_SulfurasQualityDoesNotDecrease()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
        }

        //Sulfuras sell in does not change
        [Test]
        public void updateQuality_SulfurasSellInDoesNotDecrease()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(10, Items[0].SellIn);
        }

        // Backstage passes increases by 2 when 10 days or less 
        [Test]
        public void updateQuality_BackstagePassesQualityIncreasesBy2When10DaysOrLess()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(7, Items[0].Quality);
        }

        [Test]
        public void updateQuality_BackstagePassesQualityIncreasesBy3When5DaysOrLess()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void updateQuality_BackstagePassesDropToZeroQualityWhenSellInIsLessThanZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void updateQuality_BackstagePassesQualityIncreasesBy1When11DaysOrMore()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn =11, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(6, Items[0].Quality);
        }

        [Test]
        public void updateQuality_ConjuredQualityDecreaseTwiceAsFastAsNormalItems()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 11, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(4, Items[0].Quality);
        }

        [Test]
        public void updateQuality_ConjuredQualityDecreaseTwiceAsFastAsNormalItemsWhenSellInLessThanZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);
        }

    }
}
