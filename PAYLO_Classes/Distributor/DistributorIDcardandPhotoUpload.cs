
namespace PAYLO_Classes.Distributor
{
    public class DistributorPhotoIdCard_IP
    {
        public string? Action { get; set; }          

        public int RegID { get; set; }               

        public int KycID { get; set; }               

        public string? Photo_Image { get; set; }      

        public string? IDCardPhoto_Image { get; set; } 

        public string? IPAddress { get; set; }        

        public string? SessionID { get; set; }      

        public int PhotoStatus { get; set; }         

        public int IDCardPhotoStatus { get; set; }   

        public int UserType { get; set; } = 1;      
    }

    public class DistributorPhotoIdCard_OP
    {
        public string? Result { get; set; }    
    }

}
