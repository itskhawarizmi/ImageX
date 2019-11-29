using Extensions.DataModels;
using System;
using System.Threading.Tasks;

namespace Files
{
    public interface IFileManager
    {
        Task WriteImageByteObjectToFileAsync(string fileName, FileFormat fileFormat, string path, string imageByteObject);
    }
}
