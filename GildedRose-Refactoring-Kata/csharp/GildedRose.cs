using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            var defaultQualityDecreaseAmount = -1; // controls how quickly quality degrades for normal items
            foreach (var item in Items)
            {
                var qualityChangeAmount = defaultQualityDecreaseAmount;
                var sellIn = item.SellIn;


                // Adjust qualityChangeAmount based on item type
                switch (item.Name)
                {
                    case "Aged Brie":
                        if (sellIn <= 0) qualityChangeAmount *= -2; // brie increases at the rate a typical item decreases.
                        else qualityChangeAmount *= -1; // brie increases at the rate a typical item decreases.
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        if (sellIn <= 0) qualityChangeAmount = -item.Quality;
                        else if (sellIn < 6) qualityChangeAmount = 3;
                        else if (sellIn < 11) qualityChangeAmount = 2;
                        else qualityChangeAmount = 1;
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        qualityChangeAmount = 0;
                        break;
                    case "Conjured Mana Cake":
                        if (sellIn <= 0) qualityChangeAmount *= 4;
                        else qualityChangeAmount *= 2;
                        break;
                    default:
                        if (sellIn <= 0) qualityChangeAmount *= 2;
                        break;
                }

                // Update SellIn value
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn -= 1;
                }

                // Update item quality and clamp between 0 and 50
                item.Quality += qualityChangeAmount;
                if (item.Quality > 50 && item.Name != "Sulfuras, Hand of Ragnaros") item.Quality = 50;
                else if (item.Quality < 0) item.Quality = 0;
            }
        }
    }
}
