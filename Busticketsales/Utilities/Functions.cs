using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
using System.Text;

namespace Busticketsales.Utilities
{
    public class Functions
    {
        public static int _UserID = 0;
        public static string _UserName = string.Empty;
        public static string _FullName = string.Empty;
        public static string _Password = string.Empty;
        public static string _Email = string.Empty;
        public static string _Messager = string.Empty;
        public static string _MessagerEmail = string.Empty;
        public static string _Images = string.Empty;
        public static string _SĐT = string.Empty;
        // internal static string _MessageEmail;   
        public static string TitleSlugGeneration(string type, string title, long id)
        {
            string sTitle = type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            return sTitle;
        }

        public static string getCurrentDate()
        {
            DateTime today = DateTime.Now.Date;
            return today.ToString("yyyy-MM-dd");
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));

            }
            return strBuilder.ToString();
        }
        public static string MD5Password(string? text)
        {
            string str = MD5Hash(text);
            // lặp thêm năm lần mã hóa xâu đảm bảo tính bảo mật
            // mỗi lần lặp nhân đôi xâu mã hóa , ở giữa thêm "_"
            // có thể làm cách khác để tăng tính bảo mật ở đây
            for (int i = 0; i <= 5; i++)
                str = MD5Hash(str + "_" + str);
            return str;
        }

        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Functions._UserName) || string.IsNullOrEmpty(Functions._Email) || (Functions._UserID <= 0))
                return false;
            return true;
        }
        public static bool IsLoginweb()
        {
            if (string.IsNullOrEmpty(Functions._FullName) || string.IsNullOrEmpty(Functions._Email) || (Functions._UserID <= 0))
                return false;
            return true;
        }
    }
}
