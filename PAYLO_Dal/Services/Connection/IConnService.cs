namespace PAYLO_Dal
{
    public interface IConnService
    {
        /// <summary>
        /// The GetClientConnection method get the Connection String
        /// base on environment
        /// </summary>
        /// <param name="environment"><c>The environment is either Dev, Stag, Prod</c></param>
        /// <returns><c>returns SsConnection class object</c></returns>
        SsConnection GetClientConnection(string environment);
    }
}
