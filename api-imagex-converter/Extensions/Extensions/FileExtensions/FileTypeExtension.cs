using Extensions.DataModels;

namespace Extensions
{
    public static class FileTypeExtension
    {
        public static string ToFileType(this FileFormat fileFormat)
        {
            switch (fileFormat)
            {
                case FileFormat.DOC:
                    return ".doc";

                case FileFormat.PDF:
                    return ".pdf";

                case FileFormat.TXT:
                    return ".txt";

                // i make sure for our application running in safe mode
                // by setting default value for File is (.txt).
                default:
                    return ".txt";

            }
        }
    }
}
