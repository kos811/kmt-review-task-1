using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KMT.ReviewTask1.Application.Service.Impl
{
    public class FolderProvider : IFolderProvider
    {
        public ICollection<string> GetUnprocessed(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var filenames = Directory.GetFiles(folderPath).Select(Path.GetFileNameWithoutExtension).ToList();
            var result = filenames.Where(x => !filenames.Contains(GetResultFileName(x))).ToList();
            return result;
        }

        public string GetResultFileName(string srcFilename)
        {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(srcFilename);
            return srcFilename.Replace(srcFilename,fileNameWithoutExtension + "_result");
        }
    }
}