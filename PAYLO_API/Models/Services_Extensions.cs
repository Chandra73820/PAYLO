namespace PAYLO_API.Models
{
    internal static class Services_Extensions
    {
        public static string MaskPhoneNumber(this string phoneNumber)
        {
            if (!string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length >= 4)
            {
                return new string('*', phoneNumber.Length - 4) + phoneNumber[^4..];
            }
            return phoneNumber;
        }

        public static string GenerateNewRandom()
        {
            Random generator = new Random();
            String r = generator.Next(0, 1000000).ToString("D6");
            if (r.Distinct().Count() == 1)
            {
                r = GenerateNewRandom();
            }
            return r;
        }
    }
}
