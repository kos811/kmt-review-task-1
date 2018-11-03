using System;
using System.Linq.Expressions;
using KMT.ReviewTask1.Application.Model;

namespace KMT.ReviewTask1.Application.Service.Impl
{
    public class MatrixOperationResolver : IMatrixOperationResolver
    {
        public Func<Matrix, Matrix, Matrix> Resolve(MatrixOperation operationEnum)
        {
            switch (operationEnum)
            {
                case MatrixOperation.multiply:
                    return (a, b) => a * b;
                case MatrixOperation.add:
                    return (a, b) => a + b;
                case MatrixOperation.subtract:
                    return (a, b) => a - b;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operationEnum), operationEnum, null);
            }
        }
    }
}