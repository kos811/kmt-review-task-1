using System.Collections.Generic;
using KMT.ReviewTask1.Application.Model;

namespace KMT.ReviewTask1.Application.Service
{
    public interface IFileReader
    {
        FileReadResult Read(string filename);
        void Write(string path, ICollection<Matrix> results);
    }
}