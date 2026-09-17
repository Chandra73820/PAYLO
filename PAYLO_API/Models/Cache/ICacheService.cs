namespace PAYLO_API.Models.Cache
{
    public interface ICacheService
    {
        /// <summary>
        /// Get Data using key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        //T? GetData<T>(string Key);

        /// <summary>
        /// Remove Matched Keys with contains
        /// </summary>
        /// <param name="findKey"></param>
        //void RemoveAllKeys(string findKey);

        /// <summary>
        /// Remove Data
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        //object RemoveData(string key);

        /// <summary>
        /// Set Data with Value and Expiration Time of Key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirationTime"></param>
        /// <returns></returns>
        // bool SetData<T>(string Key, T Value, DateTimeOffset expirationTime);
    }
}
