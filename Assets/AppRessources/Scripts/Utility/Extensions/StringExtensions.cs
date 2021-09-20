using System.Text;

namespace Extensions
{
    public static class StringExtention
    {
        public static string ReplaceHtmlTags(this string s) {
            StringBuilder sb = new StringBuilder(s);

            sb.Replace("<em>", "<i>");
            sb.Replace("</em>", "</i>");
            
            sb.Replace("<strong>", "<b>");
            sb.Replace("</strong>", "</b>");

            return sb.ToString();
        }
    }
}
