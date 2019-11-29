using System.Text;

namespace Extensions
{
    public static class ImageRawObjectExtension
    {
        public static string ToStringBuilder(this byte[] imageRawObject)
        {
            var sb = new StringBuilder();

            foreach(var raw in imageRawObject)
            {
                sb.Append(raw.ToString());
            }

            return sb.ToString();
        }
    }
}
