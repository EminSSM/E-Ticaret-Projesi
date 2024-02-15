using System.Security.Cryptography;
using System.Text;

namespace MyProject.UI.Tools
{
    public class GeneralTools
    {
        public static string GetMD5(string _text)
        {
            using (MD5 mD5 = MD5.Create())
            {
                byte[] hash = mD5.ComputeHash(Encoding.UTF8.GetBytes(_text));
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
        public static string GetUrl(string _text)
        {
            return _text.ToLower().Replace(" ", "-").Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c").Replace("&", "-").Replace("?","-");
        }
    }
}
