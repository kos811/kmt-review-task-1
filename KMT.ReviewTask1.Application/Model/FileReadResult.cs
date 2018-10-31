using System.Collections.Generic;

namespace KMT.ReviewTask1.Application.Model
{
    public class FileReadResult
    {
        public MatrixOperation Operation { get; set; }

        public ICollection<Matrix> Matrices { get; set; }
    }
}