using PAYLO_Classes.Enums;

namespace PAYLO_Classes
{
    public class CartItems
    {
        public int RegID { get; set; }

        public int ProductID { get; set; }

        public int ProdDetID { get; set; }

        public string? ProductName { get; set; }

        public string? DisplayName { get; set; }

        public string? ProductImage { get; set; }

        public string? SmallImagePath { get; set; }

        public string? ProductDescription { get; set; }

        public string? SubCategoryName { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal DP { get; set; }

        public decimal BV { get; set; }

        public decimal BonusBV { get; set; }

        public decimal GSTRate { get; set; }

        public decimal CGSTRate { get { return GSTRate / 2; } }

        public decimal SGSTRate { get { return GSTRate / 2; } }

        public int TaxType { get; set; }

        public int Qty { get; set; }
        public int StateID { get; set; }
        public int ShipID { get; set;  }
        public OrderType OrderType { get; set; }
        public OrderFrom OrderFrom { get; set; } 
        public decimal DiscountPer { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal TotalDP { get; set; }
        public decimal TotalBV { get; set; }
        public int? IsFPORedOfferApply { get; set; }=0;
        public int? FPORedOfferId { get; set; }=0;
        public string? ProductCode { get; set; }
        public int? OMasterId { get; set; } = 0;
        public int? OfferTypeID { get; set; } = 0;
        public int? StockAvailable { get; set; } = 0;
        public int? CatId { get; set; } = 0;

        public string? PickUpAddress { get; set; } = string.Empty;


        public int? PurchaseType { get; set; } = 0;
        public int? IsLeadcode { get; set; } = 0;


    }

    

    public class PickUp
    {
        public string? DisplayName { get; set; } = string.Empty;
        
        public string? Address { get; set; } = string.Empty;

        public int? Pincode { get; set; } = 0;

        public string? State { get; set; } = string.Empty;

        public string? Mobile { get; set; } = string.Empty;
    }
    public class SearchProductsInput
    {
        public string? SearchText { get; set; }
        public int? RegID { get; set; } = 0;
        public int? AddressID { get; set; } = 0;
        public int? UserType { get; set; } = 0;
    }
}
