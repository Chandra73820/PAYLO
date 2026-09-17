namespace PAYLO_Dal
{
    public interface IPAYLODAL
    {
        IConnService ConnService { get; }
        IDistributorService DistributorService { get; }
        IAdminService AdminService { get; }
        ICommonService CommonService { get; }
        IOpenService OpenService { get; }
    }
}
