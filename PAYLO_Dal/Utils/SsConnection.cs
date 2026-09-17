namespace PAYLO_Dal
{
    public class SsConnection
    {   
        /// <summary>
        /// Store the Server
        /// </summary>
        private readonly String server = string.Empty;

        /// <summary>
        /// Store the database
        /// </summary>
        private readonly String database = string.Empty;

        /// <summary>
        /// Store the ConnectionString
        /// </summary>
        private String enterpriseConnectionString;

        /// <summary>
        /// <c>Initializes a new instance of the SsConnection class.</c>
        /// </summary>
        /// <param name="enterpriseConnectionString">enterpriseConnectionString is a connection string</param>
        public SsConnection(String enterpriseConnectionString)
        {
            this.enterpriseConnectionString = enterpriseConnectionString;
        }

        /// <summary>
        /// Gets the enterprise connection string
        /// </summary>
        public String EnterpriseConnectionString
        {
            get
            {
                return this.enterpriseConnectionString;
            }
        }

        /// <summary>
        /// Gets the Server value 
        /// </summary>
        public String Server
        {
            get
            {
                return this.server;
            }
        }

        /// <summary>
        /// Gets the database Value
        /// </summary>
        public String Database
        {
            get
            {
                return this.database;
            }
        }

        /// <summary>
        /// Gets the Linked Database Connection
        /// </summary>
        public String LinkedDbConnection
        {
            get
            {
                return String.Format("[{0}].[{1}].dbo", this.server, this.database);
            }
        }
    }
}