namespace PAYLO_Classes
{
    public class HomePageProducts_IP
    {
        public int UserType { get; set; }
        public int RegID { get; set; }
    }

    public class HomeProducts_OP
    {
        public int ProductID { get; set; }
        public int ProdDetID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int? IsNewProd { get; set; }
        public int? IsOnlineSale { get; set; }
        public int SubCatID { get; set; }
        public int DisplayOrder { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal BV { get; set; }
        public decimal GST { get; set; }
        public string ProductImage { get; set; }
        public int? PurchaseType { get; set; } = 0;
        public string CategoryName { get; set; }

    }

    public class HomePageProductsList
    {
        public List<HomeProducts_OP> BestSellerProducts { get; set; }
        public List<HomeProducts_OP> HealthCareProducts { get; set; }
        public List<HomeProducts_OP> AgricultureProducts { get; set; }
        public List<HomeProducts_OP> BeautyProducts { get; set; }
        public List<ProductsList> NewArrivalProducts { get; set; }
    }
}
