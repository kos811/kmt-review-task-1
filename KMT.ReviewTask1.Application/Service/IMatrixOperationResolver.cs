using System;
using KMT.ReviewTask1.Application.Model;

namespace KMT.ReviewTask1.Application.Service
{
    public interface IMatrixOperationResolver
    { 
        Func<Matrix, Matrix, Matrix> Resolve(MatrixOperation operationEnum);
    }
}