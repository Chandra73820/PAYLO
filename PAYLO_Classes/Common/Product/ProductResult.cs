
using Newtonsoft.Json;

namespace PAYLO_Classes
{
    public class ProductResult
    {
        public string Result { get; set; }
        public string Msg { get; set; }
    }
    public class CartItemsResult 
    {
        public string Result { get; set; }
    }

    public class CartItems_New
    {
        public decimal HCAmount { get; set; }
        [JsonProperty("MainProducts")]
        public List<TempProducts> MainProducts { get; set; }

        [JsonProperty("OfferSelection")]
        public List<OfferSelection>? OfferSelection { get; set; }

        [JsonProperty("OfferProducts")]
        public List<OfferProducts>? OfferProducts { get; set; }
    }
    public class TempProducts
    {
        [JsonProperty("RegID")]
        public int RegID { get; set; }

        [JsonProperty("ProductID")]
        public int ProductID { get; set; }

        [JsonProperty("ProdDetID")]
        public int ProdDetID { get; set; }

        [JsonProperty("ProductCode")]
        public string ProductCode { get; set; }

        [JsonProperty("ProductName")]
        public string ProductName { get; set; }

        [JsonProperty("Qty")]
        public int Qty { get; set; }

        [JsonProperty("Mrp")]
        public decimal Mrp { get; set; }

        [JsonProperty("DP")]
        public decimal DP { get; set; }

        [JsonProperty("BV")]
        public decimal BV { get; set; }

        [JsonProperty("ProductPrice")]
        public decimal ProductPrice { get; set; }

        [JsonProperty("TotalMRP")]
        public decimal TotalMRP { get; set; }

        [JsonProperty("TotalDP")]
        public decimal TotalDP { get; set; }

        [JsonProperty("TotalBV")]
        public decimal TotalBV { get; set; }

        [JsonProperty("IPAddress")]
        public string IPAddress { get; set; }

        [JsonProperty("SessionID")]
        public string SessionID { get; set; }

        [JsonProperty("OrderType")]
        public int OrderType { get; set; }

        [JsonProperty("OrderFrom")]
        public int OrderFrom { get; set; }

        [JsonProperty("ProductImage")]
        public string ProductImage { get; set; }

        [JsonProperty("IsFPORedOfferApply")]
        public int? IsFPORedOfferApply { get; set; } = 0;
        public int? OMasterId { get; set; } = 0;
        public int ShipID { get; set; }
        public decimal GSTRate { get; set; }
        public int StateID { get; set; }
        public int IsFreeProd { get; set; }
    }
    public class OfferSelection
    {
        public string Product { get; set; }
        public int FreeQuantity { get; set; }
        public int SelectedQuantity { get; set; }
        public int RemainingQuantity { get; set; }
        public decimal DP { get; set; }
        public decimal BV { get; set; }
    }

    public class OfferProducts
    {
        public int RegID { get; set; }
        public int ProductID { get; set; }
        public int ProdDetID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal Mrp { get; set; }
        public decimal DP { get; set; }
        public decimal BV { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalMRP { get; set; }
        public decimal TotalDP { get; set; }
        public decimal TotalBV { get; set; }
        public string IPAddress { get; set; }
        public string SessionID { get; set; }
        public int OrderType { get; set; }
        public int OrderFrom { get; set; }
        public string ProductImage { get; set; }
        public int IsFreeProd { get; set; }
    }

    public class StockAndAddressCheck
    {
        public int AddressID { get; set; }
        public int ProdDetID { get; set; }
        public int Quantity { get; set; }
        public int? OMasterId { get; set; } = 0;
        public int? OfferTypeID { get; set; } = 0;
    }
    public class ProductCategories
    {
        public int? ID { get; set; }

        public string? CategoryName { get; set; }

        public string? BannerImages { get; set; }

        public string? SubCatIcon { get; set; }
    }
    public class ProductList
    {
        public int ProductID { get; set; }

        public int ProdDetID { get; set; }

        public string? ProductName { get; set; }
    }
    public class ProductsList
    {
        public int? ProductID { get; set; }

        public int? ProdDetID { get; set; }

        public int? SubCatID { get; set; }

        public string? ProductName { get; set; }

        public string? ProductImage { get; set; }

        public string? DisplayName { get; set; }

        public int? IsNewProd { get; set; }

        public int? IsOnlineSale { get; set; }

        public int? DisplayOrder { get; set; }

        public decimal? ProductPrice { get; set; }

        public decimal? Dp { get; set; }

        public decimal? BV { get; set; }

        public decimal? BonusBV { get; set; }

        public decimal? GSTRate { get; set; }

        public string? ProductCode { get; set; }

        public int? PurchaseType { get; set; } = 0;

        public string? CategoryName { get; set; }

        public decimal? MRP { get; set; }

    }
    public class ProductsList_New
    {
        public int? ProductID { get; set; }
        public int? ProdDetID { get; set; }
        public int? SubCatID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        public string? DisplayName { get; set; }
        public int? IsNewProd { get; set; }
        public int? IsOnlineSale { get; set; }
        public int? DisplayOrder { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? Dp { get; set; }
        public decimal? BV { get; set; }
        public decimal? BonusBV { get; set; }
        public decimal? GSTRate { get; set; }
        public string? ProductCode { get; set; }
        public int? PurchaseType { get; set; } = 0;
        public string? CategoryName { get; set; }
        public decimal? MRP { get; set; }
        public int? AvailableQty { get; set; } = 0;
    }
    public class FilterProducts
    {
        public string id { get; set; }
        public decimal minAmt { get; set; }
        public decimal maxAmt { get; set; }
        public int? RegID { get; set; } = 0;
        public int? AddressID { get; set; } = 0;
        public string? Action { get; set; }
        public int? UserType { get; set; } = 0;
        public int? SCMID { get; set; } = 0;
    }

    public class ProfileDetails
    {
        public string MemberID { get; set; }

        [JsonProperty("RegId")]
        public string RegId { get; set; }

        [JsonProperty("Result")]
        public string Result { get; set; }

        [JsonProperty("RegType")]
        public string RegType { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("Dob")]
        public DateTime Dob { get; set; }

        [JsonProperty("Residence")]
        public string Residence { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("CityID")]
        public int CityID { get; set; }

        [JsonProperty("StateID")]
        public int StateID { get; set; }

        [JsonProperty("Pincode")]
        public string Pincode { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Mobile")]
        public string Mobile { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }
        [JsonProperty("MotherName")]
        public string MotherName { get; set; }

        [JsonProperty("Status")]
        public int Status { get; set; }

        [JsonProperty("PAN")]
        public string PAN { get; set; }

        [JsonProperty("GSTNo")]
        public string GSTNo { get; set; }

        [JsonProperty("UserType")]
        public int UserType { get; set; }

        [JsonProperty("ProfileImage")]
        public string ProfileImage { get; set; }

        [JsonProperty("SprMemID")]
        public string SprMemID { get; set; }

        [JsonProperty("RefMemID")]
        public string RefMemID { get; set; }

        [JsonProperty("JoinDate")]
        public string JoinDate { get; set; }

        [JsonProperty("SponsorName")]
        public string SponsorName { get; set; }

        [JsonProperty("RefName")]
        public string RefName { get; set; }

        [JsonProperty("NomineeName")]
        public string NomName { get; set; }

        [JsonProperty("NomineeRelation")]
        public string NomRelation { get; set; }

        [JsonProperty("NomineeAge")]
        public int NomineeAge { get; set; }

        [JsonProperty("KycStatus")]
        public string KycStatus { get; set; }

        [JsonProperty("AcccountNo")]
        public string AcccountNo { get; set; }

        [JsonProperty("IfscID")]
        public string IfscID { get; set; }
        [JsonProperty("Bank")]
        public string Bank { get; set; }

        [JsonProperty("Branch")]
        public string Branch { get; set; }

        [JsonProperty("IDCardPhotoImage")]
        public string IDCardPhotoImage { get; set; }

        public string MaritalStatus { get; set; }

        public string? District { get; set; }

        public string? WAMobileNo { get; set; }

        public string? RelationType { get; set; }

        public string? RelativeName { get; set; }
        public string? TelNo { get; set; }
        [JsonProperty("EditProfileStatus")]
        public int EditProfileStatus { get; set; }

        [JsonProperty("AddressPrfType")]
        public string AddressPrfType { get; set; }
        [JsonProperty("AddPrf_Number")]
        public string AddPrf_Number { get; set; }
        [JsonProperty("IDPrfDocType")]
        public string IDPrfDocType { get; set; }
        [JsonProperty("IDPrf_Number")]
        public string IDPrf_Number { get; set; }
    }
    public class SubCatIDInput
    {
        public int? RegID { get; set; } = 0;


        public int? SubCatID { get; set; }

        public int? ProdDetID { get; set; }

        public int? AddressID { get; set; } = 0;


        public int? UserType { get; set; } = 0;

    }
    public class StockRequestProducts_IP
    {
        public string? Action { get; set; }
        public int? ID { get; set; }
        public int? SCMIDORStoreID { get; set; }
    }

    public class StockRequestProducts_OP
    {
        public int? ProductID { get; set; }
        public int? ProdDetID { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }

        public int? SubCatID { get; set; }
        public decimal? MRP { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? GST { get; set; }
        public decimal? BV { get; set; }
        public string? CategoryName { get; set; }
        public int? AvlQty { get; set; }
        public int? MainQty { get; set; }
        public int? OfferQty { get; set; }
    }
    public class GetShippingAddressesInput
    {
        public int? RegID { get; set; }
        public int? UserType { get; set; }
    }

    public class GetOfferProducts_IP
    {
        public decimal? DP { get; set; }
        public decimal? BV { get; set; }
        public int SCMID { get; set; }
    }
    public class InsertOfferTempCartItems_IP
    {
        public int? RegID { get; set; }
        public int? ProdDetID { get; set; }
        public int? Quantity { get; set; }
        public int? UserType { get; set; }
        public int? OrderFrom { get; set; }
        public string? SessionID { get; set; }
        public string? IPAddress { get; set; }
    }
    public class ZonelID
    {
        public int? ZoneID { get; set; }
    }
    public class ProductIDInput
    {
        public int? ProductID { get; set; }
        public int? RegID { get; set; } = 0;
        public int? UserType { get; set; } = 0;
    }
    public class RemoveCartItemInput
    {
        public int? ProductID { get; set; }
        public int? Regid { get; set; }

    }
    public class ProductData_List
    {
        public int ProductID { get; set; }
        public int SubCatID { get; set; }
        public string ProductName { get; set; }
        public string DisplayName { get; set; }
        public int IsNewProd { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string HowToUse { get; set; }
        public string Benefits { get; set; }
        public string YoutubeLink { get; set; }
        public string Ingredients { get; set; }
        public string ReturnPolicyDescription { get; set; }
        public string ShippingDescription { get; set; }
        public List<ProductDetails> Details { get; set; }
        public string Keywords { get; set; }
        public string Hsncode { get; set; }
        public string Sizes { get; set; }
        public int DefaultAttID { get; set; }
        public List<ProductOptions> Options { get; set; }
        public int? VisibleOnWeb { get; set; }
        public int? IsOnlineSale { get; set; }
    }
    public class ProductDetails
    {
        public int? prodDetID { get; set; }
        public string ProductCode { get; set; }
        public List<ProductImage> ProductImage { get; set; }
        public int? LineNumber { get; set; }
        public int? DefaultOptionID { get; set; }
        public int? DisplayOrder { get; set; }
        public decimal? ProductPrice { get; set; }

        public decimal? BV { get; set; }
        public decimal? BonusBV { get; set; }
        public decimal? GST { get; set; }

    }
    public class ProductImage
    {
        public int ProdImgID { get; set; }
        public int ProdDetID { get; set; }
        public string SmallImagePath { get; set; }
        public string LargeImagePath { get; set; }
        public int ImageOrder { get; set; }
    }
    public class ProductOptions
    {
        public int AttributeID { get; set; }
        public string AttributeCode { get; set; }
        public string AttributeName { get; set; }
        public int AttributeOrder { get; set; }
        public int OptionID { get; set; }
        public string OptionCode { get; set; }
        public string OptionValue { get; set; }
        public int ProdOptValID { get; set; }
        public int ProdDetID { get; set; }
    }
    
}
