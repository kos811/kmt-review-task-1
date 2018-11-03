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

            var filesInFolder = Directory.GetFiles(folderPath);
            var result = filesInFolder.Where(x => !Path.GetFileNameWithoutExtension(x).ToLower().EndsWith("_result"))
                .ToList();
            return result;
        }

        public string GetResultFileName(string srcFilename)
        {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(srcFilename);
            return srcFilename.Replace(fileNameWithoutExtension, fileNameWithoutExtension + "_result");
        }
    }
}