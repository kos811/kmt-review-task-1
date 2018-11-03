using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMT.ReviewTask1.Application.Model;

namespace KMT.ReviewTask1.Application.Service.Impl
{
    public class MatrixProcessor : IMatrixProcessor
    {
        private readonly IMatrixOperationResolver _operationResolver;
        private readonly ILogger _logger;

        public MatrixProcessor(IMatrixOperationResolver operationResolver, ILogger logger)
        {
            _operationResolver = operationResolver;
            _logger = logger;
        }

        public ICollection<Matrix> Process(FileReadResult fileContent)
        {
            var operation = fileContent.Operation;
            if (operation == MatrixOperation.transpose)
                return fileContent.Matrices.Select(x => x.Transpose()).ToList();

            var func = _operationResolver.Resolve(operation);

            var matrixArray = fileContent.Matrices.ToArray();
            var currentMatrix = matrixArray[0];

            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"\r\n"+currentMatrix);
            for (var i = 1; i < matrixArray.Length; i++)
            {
                stringBuilder.Append($"\r\n {operation} \r\n {matrixArray[i]}");
                currentMatrix = func.Invoke(currentMatrix, matrixArray[i]);
                
            }
            stringBuilder.Append($"\r\n = \r\n {currentMatrix}");
            _logger.Add(stringBuilder.ToString());

            return new List<Matrix> {currentMatrix};
        }
    }
}