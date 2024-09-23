using System.Text;

namespace CCI.Common
{
    public class StringUtility
    {
        public static string CreateMd5(string input)
        {
            // Use input string to calculate MD5 hash
            using var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            var sb = new StringBuilder();
            foreach (var t in hashBytes)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }

        public static string GetMac<T>(T inputModel, string secretKey)
        {
            if (inputModel == null)
            {
                return string.Empty;
            }

            var listKey = (from propertyInfo
                in inputModel.GetType().GetProperties()
                           let value = propertyInfo.GetValue(inputModel, null)
                           where value != null
                                 && !propertyInfo.Name.Equals("mac_type")
                                 && !propertyInfo.Name.Equals("mac")
                           select propertyInfo.Name)
                .ToList();

            var orderedEnumerable = listKey.OrderBy(x => x).ToList();
            var listKeyValue = orderedEnumerable.Select(key => $"{key}={inputModel.GetType().GetProperty(key)?.GetValue(inputModel, null)}").ToList();

            var inputHash = string.Join("&", listKeyValue);
            return CreateMd5($"{secretKey}{inputHash}");
        }

    }
}
