using System.Collections.Generic;

namespace KMT.ReviewTask1.Application.Service
{
    public interface IFolderProvider
    {
        ICollection<string> GetUnprocessed(string folderPath);

        string GetResultFileName(string srcFilename);
    }
}