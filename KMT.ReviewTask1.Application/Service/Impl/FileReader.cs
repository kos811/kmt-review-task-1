using System;
using System.IO;
using System.Linq;
using KMT.ReviewTask1.Application.Model;

namespace KMT.ReviewTask1.Application.Service.Impl
{
    public class FileReader : IFileReader
    {
        private readonly IMatrixSerializer _matrixSerializer;

        public FileReader(IMatrixSerializer matrixSerializer)
        {
            _matrixSerializer = matrixSerializer;
        }

        public FileReadResult Read(string filename)
        {
            var fileContent = File.ReadAllText(filename);

            var parts = fileContent.Split(new []{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            if(!Enum.TryParse(parts.First(), out MatrixOperation operation))
                throw new ArgumentException($"Нераспознаная операция '{parts.First()}'");

            var result = new FileReadResult
            {
                Operation = operation,
                Matrices =  parts.Skip(1).Select(x=> _matrixSerializer.Deserialize(x)).ToList()
            };
            return result;
        }
    }
}