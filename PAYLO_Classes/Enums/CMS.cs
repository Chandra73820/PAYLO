using System.ComponentModel;

namespace PAYLO_Classes.Enums
{
    public enum CMSImageCategory
    {
        [Description("Home Page Banners")]
        HomePageBanners = 1,
        [Description("Events Gallery")]
        EventsGallery = 2,
        [Description("Achievers Gallery")]
        AchieversGallery = 3,
        [Description("Corporate Gallery")]
        CorporateGallery = 4,
        [Description("Pin Achievers")]
        PinAchievers = 5,
        [Description("Testimonial Gallery")]
        TestimonialGallery = 6,
        [Description("Promotional Offers")]
        PromotionalOffers = 7,
        [Description("DashBoard Popup")]
        DashBoardPopup = 8,
        [Description("Achievers")]
        Achievers = 9,
        [Description("Blog")]
        Blog = 11,
        [Description("Product Category Banners")]
        ProductCategories = 12,
        [Description("Distributor Banners")]
        DistributorBanners = 13,
        [Description("Mobile App Slides")]
        MobileAppSlides = 14,
        [Description("WH Popup")]
        WHPopup = 15,
        [Description("Franchise Popup")]
        FranchisePopup = 17,
        [Description("Website Popup")]
        WebsitePopup = 20,
        [Description("Customer Popup")]
        CustomerPopup = 21,
    }

    public enum DisplayOrder
    {
        Enable = 1,
        Disable = 0
    }

    public enum DisplayStatus
    {
        Active = 1,
        Inactive = 0
    }
}
