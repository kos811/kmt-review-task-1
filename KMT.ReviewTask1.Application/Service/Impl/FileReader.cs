using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KMT.ReviewTask1.Application.Model;

namespace KMT.ReviewTask1.Application.Service.Impl
{
    public class FileReader : IFileReader
    {
        private readonly IMatrixSerializer _matrixSerializer;

        private const string MATRIX_DELIMITER = "\r\n\r\n";

        public FileReader(IMatrixSerializer matrixSerializer)
        {
            _matrixSerializer = matrixSerializer;
        }

        public FileReadResult Read(string filename)
        {
            var fileContent = File.ReadAllText(filename);

            var parts = fileContent.Split(new[] { MATRIX_DELIMITER }, StringSplitOptions.RemoveEmptyEntries);
            if (!Enum.TryParse(parts.First(), out MatrixOperation operation))
                throw new ArgumentException($"Нераспознаная операция '{parts.First()}'");

            var result = new FileReadResult
            {
                Operation = operation,
                Matrices = parts.Skip(1).Select(x => _matrixSerializer.Deserialize(x)).ToList()
            };
            return result;
        }

        public void Write(string path, ICollection<Matrix> results)
        {
            var serialized = results.Select(_matrixSerializer.Serialize).ToList();
            var newFileContent = string.Join(MATRIX_DELIMITER, serialized);
            File.WriteAllText(path, newFileContent);
        }
    }
}