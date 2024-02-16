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

        // Tests SellIn reduction of basic item
        [Test]
        public void updateQuality_ReducesSellIn_From10To9()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
        }

        // tests quality reduction of basic item
        [Test]
        public void updateQuality_ReducesQuality_3To2()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);
        }

        // tests double quality reduction of item past sellIn date
        [Test]
        public void updateQuality_ReducesQualityBy2_WhenSellInLessThanZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(1, Items[0].Quality);
        }

        // tests quality reduction of item at boundary of sellIn date
        [Test]
        public void updateQuality_ReducesQualityBy1_WhenSellInEqualsOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);
        }

        // tests quality reduction of item at boundary of sellIn date
        [Test]
        public void updateQuality_ReducesQualityBy2_WhenSellInEqualsZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(1, Items[0].Quality);
        }

        // tests quality lower limit of 0
        [Test]
        public void updateQuality_QualityRemainsAtZero_WhenAtZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        // tests quality increase of aged brie above sell in date
        [Test]
        public void updateQuality_QualityIncreaseby1_WhenAgedBrie_WhenSellInAboveZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);
        }

        // tests double quality increase of aged brie when below sell in date
        [Test]
        public void updateQuality_QualityIncreaseby2_WhenAgedBrie_WhenSellInLessThanZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -5, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(3, Items[0].Quality);
        }

        // tests upper quality limit of 50
        [Test]
        public void updateQuality_QualityRemainsAt50_WhenAgedBrie_WhenQualityIs50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }
        // tests Sulfuras quality retention
        [Test]
        public void updateQuality_QualityDoesNotChange_WhenSulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
        }

        // tests Sulfuras SellIn retention
        [Test]
        public void updateQuality_SellInDoesNotChange_WhenSulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(10, Items[0].SellIn);
        }

        // tests passes double quality increase
        [Test]
        public void updateQuality_BackstagePassesQualityIncreasesBy2_When10DaysOrLess()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(7, Items[0].Quality);
        }

        // tests passes triple quality increase
        [Test]
        public void updateQuality_BackstagePassesQualityIncreasesBy3_When5DaysOrLess()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);
        }

        // tests passes quality drop to zero after sellin
        [Test]
        public void updateQuality_BackstagePassesDropToZeroQuality_WhenSellInIsLessThanZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        // tests passes single quality increase
        [Test]
        public void updateQuality_BackstagePassesQualityIncreasesBy1_When11DaysOrMore()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn =11, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(6, Items[0].Quality);
        }

        // tests conjured items double quality decrease
        [Test]
        public void updateQuality_ConjuredQualityDecreaseTwiceAsFastAsNormalItems()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 11, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(4, Items[0].Quality);
        }

        // tests conjured items double qualiity decrease after sell in date 
        [Test]
        public void updateQuality_ConjuredQualityDecreaseTwiceAsFastAsNormalItems_WhenSellInLessThanZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);
        }

    }
}
