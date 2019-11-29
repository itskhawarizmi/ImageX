using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Extensions;
using Extensions.DataModels;
using Files.Awaiters;

namespace Files
{
    public class FileManager : IFileManager
    {
        #region FileManager Methods

        public async Task WriteImageByteObjectToFileAsync(string fileName, FileFormat fileFormat, string path, string imageByteObject)
        {
            var normalizeFile = default(string);

            try
            {
                // run on thread safe mode
                await FileThreadAwaiter.AwaitAsync(nameof(FileManager) + path, async () =>
                {
                    await Task.Run(() =>
                    {
                        path = ResolvePath(path);

                        if (!Directory.Exists($"{path}/ImageX"))
                        {
                            DirectoryInfo di = Directory.CreateDirectory($"{path}/ImageX");
                        }

                        if(File.Exists($"{normalizeFile.ToFileNormalize(fileName += ("-" + GenerateRandomNumber(10, 1000)), fileFormat)}"))
                        {
                            normalizeFile.ToFileNormalize(fileName += ("-" + GenerateRandomNumber(20, 1000)), fileFormat);
                        }

                        using (var streaWriter = (TextWriter)new StreamWriter(File.Open($"{path}/ImageX/{normalizeFile.ToFileNormalize(fileName += ("-" + GenerateRandomNumber(10, 1000)), fileFormat)}", FileMode.CreateNew)))
                        {
                            streaWriter.Write(imageByteObject);
                        }

                    });
                });
                
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Message: {ex.Message}");
            }
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Get the current file path to full path.
        /// </summary>
        /// <param name="path">The path of file</param>
        /// <returns></returns>
        private string ResolvePath(string path) => Path.GetFullPath(path);

        private string GenerateRandomString(int size, bool lowerCase)
        {
            var sb = new StringBuilder();

            Random random = new Random();

            char characters;

            for(int initial= 0; initial < size; initial++)
            {
                characters = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                sb.Append(characters);
            }

            if (lowerCase)
            {
                return sb.ToString().ToLower();
            }

            return sb.ToString();

        }
        private int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);

        }

        #endregion
    }
}
