using KMT.ReviewTask1.Application.Model;

namespace KMT.ReviewTask1.Application.Service.Impl
{
    public interface IFileReader
    {
        FileReadResult Read(string filename);
    }
}