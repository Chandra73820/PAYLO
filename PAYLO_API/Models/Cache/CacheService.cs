namespace PAYLO_API.Models.Cache
{
    public class CacheService : ICacheService
    {
        //private IDatabase _db;

        //public bool IsRedisCacheEnable { get; set; }
        //public string RedisURL { get; set; }

        //public CacheService(IConfiguration configuration)
        //{
        //    IsRedisCacheEnable = configuration.GetValue<bool>("IsRedisCacheEnable");
        //    RedisURL = configuration.GetValue<string>("RedisURL");

        //    if (IsRedisCacheEnable)
        //    {
        //        ConfigureRedis();
        //    }
        //}

        //private void ConfigureRedis()
        //{
        //    _db = ConnectionHelper.Connection.GetDatabase();
        //}

        //public T? GetData<T>(string Key)
        //{
        //    var value = _db.StringGet(Key);

        //    if (!string.IsNullOrEmpty(value))
        //    {
        //        return JsonConvert.DeserializeObject<T>(value);
        //    }

        //    return default;
        //}

        //public bool SetData<T>(string Key, T Value, DateTimeOffset expirationTime)
        //{
        //    TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);

        //    var isEnable = _db.StringSet(Key, JsonConvert.SerializeObject(Value), expiryTime);

        //    return isEnable;
        //}

        //public object RemoveData(string key)
        //{
        //    bool _isKeyExist = _db.KeyExists(key);

        //    if (_isKeyExist == true)
        //    {
        //        return _db.KeyDelete(key);
        //    }
        //    return false;
        //}

        //public void RemoveAllKeys(string findKey)
        //{
        //    ConnectionMultiplexer connectionMultiplexer = ConnectionHelper.Connection;

        //    IServer server = connectionMultiplexer.GetServer(RedisURL);

        //    foreach (var key in server.Keys())
        //    {
        //        if (key.ToString().Contains(findKey))
        //        {
        //            bool _isKeyExist = _db.KeyExists(key);

        //            if (_isKeyExist == true)
        //            {
        //                _db.KeyDelete(key);
        //            }
        //        }
        //    }
        //}
    }
}
