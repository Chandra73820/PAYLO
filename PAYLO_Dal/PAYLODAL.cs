using System;
using System.Collections.Generic;
using System.Linq;



namespace PAYLO_Dal
{
    public class PAYLODAL : IPAYLODAL
    {
        private static IPAYLODAL dl;
        private static Object dllock = new Object();
        private static IConnService _connservice;

        private static IAdminService _adminService;
        private static IDistributorService _distributorService;
        private static ICommonService _commonService;

        private static IOpenService _openservice;

        //private static IShoppingCartService _shoppingCartService;

        //private static ISCMService _SCMService;

        private PAYLODAL()
        {
            _connservice = new ConnService();

            _adminService = new AdminService();
            _distributorService = new DistributorService();
            _commonService = new CommonService();

            _openservice = new OpenService();

            //_shoppingCartService = new ShoppingCartService();
            //_SCMService = new SCMService();

        }

        public static IPAYLODAL Instance
        {
            get
            {
                if (dl == null)
                {
                    lock (dllock)
                    {
                        if (dl == null)
                        {
                            dl = new PAYLODAL();
                        }
                    }
                }

                return dl;
            }
        }

        public IConnService ConnService{get{return _connservice;}}

        public IAdminService AdminService
        {
            get
            {
                return _adminService;
            }
        }

        public IDistributorService DistributorService{get{return _distributorService;}}


        public ICommonService CommonService {get{return _commonService;}}

        //public IShoppingCartService ShoppingCartService
        //{
        //    get
        //    {
        //        return _shoppingCartService;
        //    }
        //}

        //public ISCMService SCMService
        //{
        //    get
        //    {
        //        return _SCMService;
        //    }
        //}

        public IOpenService OpenService { get { return _openservice; } }

    }
}
