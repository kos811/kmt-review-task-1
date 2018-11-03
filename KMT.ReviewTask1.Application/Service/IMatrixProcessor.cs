using System.Collections.Generic;
using KMT.ReviewTask1.Application.Model;

namespace KMT.ReviewTask1.Application.Service
{
    public interface IMatrixProcessor
    {
        ICollection<Matrix> Process(FileReadResult fileContent);
    }
}