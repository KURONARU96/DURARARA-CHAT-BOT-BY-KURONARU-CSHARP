using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Drrr_Bot_Kuronaru
{
    class EPICGAMES_FREEBIES
    {
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class KeyImage
        {
            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("url")]
            public string Url { get; set; }
        }

        public class Seller
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }
        }

        public class Item
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("namespace")]
            public string Namespace { get; set; }
        }

        public class CustomAttribute
        {
            [JsonPropertyName("key")]
            public string Key { get; set; }

            [JsonPropertyName("value")]
            public string Value { get; set; }
        }

        public class Category
        {
            [JsonPropertyName("path")]
            public string Path { get; set; }
        }

        public class CurrencyInfo
        {
            [JsonPropertyName("decimals")]
            public int Decimals { get; set; }
        }

        public class FmtPrice
        {
            [JsonPropertyName("originalPrice")]
            public string OriginalPrice { get; set; }

            [JsonPropertyName("discountPrice")]
            public string DiscountPrice { get; set; }

            [JsonPropertyName("intermediatePrice")]
            public string IntermediatePrice { get; set; }
        }

        public class TotalPrice
        {
            [JsonPropertyName("discountPrice")]
            public int DiscountPrice { get; set; }

            [JsonPropertyName("originalPrice")]
            public int OriginalPrice { get; set; }

            [JsonPropertyName("voucherDiscount")]
            public int VoucherDiscount { get; set; }

            [JsonPropertyName("discount")]
            public int Discount { get; set; }

            [JsonPropertyName("currencyCode")]
            public string CurrencyCode { get; set; }

            [JsonPropertyName("currencyInfo")]
            public CurrencyInfo CurrencyInfo { get; set; }

            [JsonPropertyName("fmtPrice")]
            public FmtPrice FmtPrice { get; set; }
        }

        public class LineOffer
        {
            [JsonPropertyName("appliedRules")]
            public List<object> AppliedRules { get; set; }
        }

        public class Price
        {
            [JsonPropertyName("totalPrice")]
            public TotalPrice TotalPrice { get; set; }

            [JsonPropertyName("lineOffers")]
            public List<LineOffer> LineOffers { get; set; }
        }

        public class DiscountSetting
        {
            [JsonPropertyName("discountType")]
            public string DiscountType { get; set; }

            [JsonPropertyName("discountPercentage")]
            public int DiscountPercentage { get; set; }
        }

        public class PromotionalOffer2
        {
            [JsonPropertyName("startDate")]
            public DateTime StartDate { get; set; }

            [JsonPropertyName("endDate")]
            public DateTime EndDate { get; set; }

            [JsonPropertyName("discountSetting")]
            public DiscountSetting DiscountSetting { get; set; }

            [JsonPropertyName("promotionalOffers")]
            public List<PromotionalOffer2> PromotionalOffers { get; set; }
        }

        public class UpcomingPromotionalOffer
        {
            [JsonPropertyName("promotionalOffers")]
            public List<PromotionalOffer2> PromotionalOffers { get; set; }
        }

        public class Promotions
        {
            [JsonPropertyName("promotionalOffers")]
            public List<PromotionalOffer2> PromotionalOffers { get; set; }

            [JsonPropertyName("upcomingPromotionalOffers")]
            public List<UpcomingPromotionalOffer> UpcomingPromotionalOffers { get; set; }
        }

        public class Element
        {
            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("namespace")]
            public string Namespace { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("effectiveDate")]
            public DateTime EffectiveDate { get; set; }

            [JsonPropertyName("offerType")]
            public string OfferType { get; set; }

            [JsonPropertyName("expiryDate")]
            public object ExpiryDate { get; set; }

            [JsonPropertyName("status")]
            public string Status { get; set; }

            [JsonPropertyName("isCodeRedemptionOnly")]
            public bool IsCodeRedemptionOnly { get; set; }

            [JsonPropertyName("keyImages")]
            public List<KeyImage> KeyImages { get; set; }

            [JsonPropertyName("seller")]
            public Seller Seller { get; set; }

            [JsonPropertyName("productSlug")]
            public string ProductSlug { get; set; }

            [JsonPropertyName("urlSlug")]
            public string UrlSlug { get; set; }

            [JsonPropertyName("url")]
            public object Url { get; set; }

            [JsonPropertyName("items")]
            public List<Item> Items { get; set; }

            [JsonPropertyName("customAttributes")]
            public List<CustomAttribute> CustomAttributes { get; set; }

            [JsonPropertyName("categories")]
            public List<Category> Categories { get; set; }

            [JsonPropertyName("tags")]
            public List<object> Tags { get; set; }

            [JsonPropertyName("price")]
            public Price Price { get; set; }

            [JsonPropertyName("promotions")]
            public Promotions Promotions { get; set; }
        }

        public class Paging
        {
            [JsonPropertyName("count")]
            public int Count { get; set; }

            [JsonPropertyName("total")]
            public int Total { get; set; }
        }

        public class SearchStore
        {
            [JsonPropertyName("elements")]
            public List<Element> Elements { get; set; }

            [JsonPropertyName("paging")]
            public Paging Paging { get; set; }
        }

        public class Catalog
        {
            [JsonPropertyName("searchStore")]
            public SearchStore SearchStore { get; set; }
        }

        public class Data
        {
            [JsonPropertyName("Catalog")]
            public Catalog Catalog { get; set; }
        }

        public class Extensions
        {
        }

        public class Root
        {
            [JsonPropertyName("data")]
            public Data Data { get; set; }

            [JsonPropertyName("extensions")]
            public Extensions Extensions { get; set; }
        }


    }

}
