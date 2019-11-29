using Extensions.DataModels;
using System.Linq;

namespace Extensions
{
    public static class FileConverterExtension
    {
        public static string ToFileNormalize(this string normalizeFile, string fileName, FileFormat fileFormat) =>
            normalizeFile = string.Format("{0}{1}", fileName, fileFormat.ToFileType());

    }
}
