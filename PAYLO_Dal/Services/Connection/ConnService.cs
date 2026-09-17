using SSReusableLib;

namespace PAYLO_Dal
{
    public class ConnService : IConnService
    {
        #region Field(s)

        ////private readonly IConfiguration configuration;

        /// <summary>
        /// Store the key and connection string
        /// </summary>
        private IDictionary<string, ObjectCache<SsConnection>> ssconnections;

        /// <summary>
        /// Store the lock the object
        /// </summary>
        private Object sslock = new Object();
        #endregion Field(s)

        #region Constructor(s)
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectCache"/> class.
        /// </summary>
        public ConnService()
        {
            ssconnections = new Dictionary<string, ObjectCache<SsConnection>>();
        }
        #endregion Constructor(s)

        #region User Settings
        /// <summary>
        /// Get the client connection string
        /// </summary>
        /// <param name="environment"><c>environment is either dev, stag or prod</c></param>
        /// <returns><c>returns SsConnection object</c></returns>
        public SsConnection GetClientConnection(string environment)
        {
            string keyValue = string.Format("{0}", environment);
            SsConnection result = null;
            if (!(ssconnections.ContainsKey(keyValue) && !ssconnections[keyValue].IsExpired()))
            {
                lock (sslock)
                {
                    if (!(ssconnections.ContainsKey(keyValue) && !ssconnections[keyValue].IsExpired()))
                    {
                        if (ssconnections.ContainsKey(keyValue))
                        {
                            ssconnections.Remove(keyValue);
                        }

                        ssconnections.Add(keyValue, new ObjectCache<SsConnection>(new SsConnection(GetConnectionString(environment))));
                    }
                }
            }

            result = ssconnections[keyValue].ObjectItem;
            return result;
        }

        /// <summary>
        /// Get the connection string
        /// </summary>
        /// <returns>returns connection string</returns>
        //internal static string GetConString()
        //{
        //    string strConfigConnection = ConfigurationManager.AppSettings["ConfigConnection"];
        //    return strConfigConnection;
        //}

        /// <summary>
        /// Get the connection string based on environment
        /// </summary>
        /// <param name="environment"><c>environment is either dev, stag or prod</c></param>
        /// <returns>returns connection string</returns>
        //protected string GetConnectionString(string environment)
        //{
        //    string strConfigConnection = string.Empty;

        //    if (environment.ToUpper().Equals("DEV"))
        //    {
        //        ////smartsoft.ws
        //        strConfigConnection = Config.GetSection("ConnectionStrings")["DevConnection"];
        //    }
        //    else if (environment.ToUpper().Equals("STAG"))
        //    {
        //        strConfigConnection = Config.GetSection("ConnectionStrings")["StagingConnection"];
        //    }
        //    else if (environment.ToUpper().Equals("PROD"))
        //    {
        //        strConfigConnection = Config.GetSection("ConnectionStrings")["ProductionConnection"];
        //    }
        //    else if (environment.ToUpper().Equals("LIVE"))
        //    {
        //        strConfigConnection = Config.GetSection("ConnectionStrings")["LiveConnection"];
        //    }

        //    else if (environment.ToUpper().Equals("GBLDEV"))
        //    {
        //        ////smartsoft.ws
        //        strConfigConnection = Config.GetSection("GBLConnectionStrings")["DevConnection"];
        //    }
        //    else if (environment.ToUpper().Equals("GBLSTAG"))
        //    {
        //        strConfigConnection = Config.GetSection("GBLConnectionStrings")["StagingConnection"];
        //    }
        //    else if (environment.ToUpper().Equals("GBLPROD"))
        //    {
        //        strConfigConnection = Config.GetSection("GBLConnectionStrings")["ProductionConnection"];
        //    }
        //    else if (environment.ToUpper().Equals("GBLLIVE"))
        //    {
        //        strConfigConnection = Config.GetSection("GBLConnectionStrings")["LiveConnection"];
        //    }
        //    return strConfigConnection;
        //}
        protected string GetConnectionString(string environment)
        {
            if (string.IsNullOrWhiteSpace(environment))
            {
                throw new Exception(
                    "Environment value is NULL or Empty.");
            }

            string strConfigConnection = string.Empty;

            environment = environment.ToUpper();

            if (environment.Equals("DEV"))
            {
                strConfigConnection =
                    Config.GetSection("ConnectionStrings")["DevConnection"];
            }
            else if (environment.Equals("STAG"))
            {
                strConfigConnection =
                    Config.GetSection("ConnectionStrings")["StagingConnection"];
            }
            else if (environment.Equals("PROD"))
            {
                strConfigConnection =
                    Config.GetSection("ConnectionStrings")["ProductionConnection"];
            }
            else if (environment.Equals("LIVE"))
            {
                strConfigConnection =
                    Config.GetSection("ConnectionStrings")["LiveConnection"];
            }
            else if (environment.Equals("GBLDEV"))
            {
                strConfigConnection =
                    Config.GetSection("GBLConnectionStrings")["DevConnection"];
            }
            else if (environment.Equals("GBLSTAG"))
            {
                strConfigConnection =
                    Config.GetSection("GBLConnectionStrings")["StagingConnection"];
            }
            else if (environment.Equals("GBLPROD"))
            {
                strConfigConnection =
                    Config.GetSection("GBLConnectionStrings")["ProductionConnection"];
            }
            else if (environment.Equals("GBLLIVE"))
            {
                strConfigConnection =
                    Config.GetSection("GBLConnectionStrings")["LiveConnection"];
            }
            else
            {
                throw new Exception(
                    $"Invalid Environment : {environment}");
            }

            if (string.IsNullOrWhiteSpace(strConfigConnection))
            {
                throw new Exception(
                    $"Connection string not found for environment : {environment}");
            }

            return strConfigConnection;
        }
        #endregion
    }
}