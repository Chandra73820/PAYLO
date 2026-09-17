namespace PAYLO_Classes.Common.CMS
{
    public class ImageCollection : Session_IPAdd
    {
        public int ImageID { get; set; }
        public int? ImageCategoryID { get; set; }
        public string? Title { get; set; }
        public string? AltText { get; set; }
        public string? ImageUrl { get; set; }
        public int DisplayStatus { get; set; }
        public int DisplayOrder { get; set; }
        public int UserID { get; set; }
        
    }
}
