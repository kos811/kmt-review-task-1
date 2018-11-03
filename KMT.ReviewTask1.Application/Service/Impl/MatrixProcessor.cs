using System.Collections.Generic;
using System.Linq;
using KMT.ReviewTask1.Application.Model;

namespace KMT.ReviewTask1.Application.Service.Impl
{
    public class MatrixProcessor : IMatrixProcessor
    {
        private readonly IMatrixOperationResolver _operationResolver;

        public MatrixProcessor(IMatrixOperationResolver operationResolver)
        {
            _operationResolver = operationResolver;
        }

        public ICollection<Matrix> Process(FileReadResult fileContent)
        {
            var operation = fileContent.Operation;
            if (operation == MatrixOperation.transpose)
                return fileContent.Matrices.Select(x => x.Transpose()).ToList();

            var func = _operationResolver.Resolve(operation);

            var matrixArray = fileContent.Matrices.ToArray();
            var currentMatrix = matrixArray[0];

            for (var i = 1; i < matrixArray.Length; i++)
                currentMatrix = func.Invoke(currentMatrix, matrixArray[i]);

            return new List<Matrix> {currentMatrix};
        }
    }
}