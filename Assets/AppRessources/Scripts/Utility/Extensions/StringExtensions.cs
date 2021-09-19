using System.Text;

namespace Extensions
{
    public static class StringExtention
    {
        public static string ReplaceEmTags(this string s) {
            StringBuilder sb = new StringBuilder(s);

            sb.Replace("<em>", "<i>");
            sb.Replace("</em>", "</i>");

            return sb.ToString();
        }
    }
}
