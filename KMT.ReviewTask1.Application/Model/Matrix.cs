using System;
using System.Text;

namespace KMT.ReviewTask1.Application.Model
{
    public class Matrix
    {
        private readonly double[,] _matrix;

        public int RowCount => _matrix.GetLength(0);
        public int ColCount => _matrix.GetLength(1);

        public Matrix(int rowCount, int colCount)
        {
            _matrix = new double[rowCount, colCount];
            for (var i = 0; i < rowCount; i++)
            for (var j = 0; j < colCount; j++)
                _matrix[i, j] = 0;
        }

        public Matrix(double[,] input)
        {
            _matrix = (double[,])input.Clone();
        }

        public double this[int row, int col]
        {
            get
            {
                if (row >= RowCount)
                    throw new IndexOutOfRangeException($"В массиве {RowCount} строк");
                if (col >= ColCount)
                    throw new IndexOutOfRangeException($"В массиве {ColCount} столбцов");
                return _matrix[row, col];
            }
            set => _matrix[row, col] = value;
        }


        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.ColCount != b.ColCount)
                throw new ArgumentException("Количество столбцов в матрицах не совпадает");

            if (a.RowCount != b.RowCount)
                throw new ArgumentException("Количество строк в матрицах не совпадает");

            var targetRowCount = Math.Max(a.RowCount, b.RowCount);
            var targetColCount = Math.Max(a.ColCount, b.ColCount);
            var result = new Matrix(targetRowCount, targetColCount);
            for (var i = 0; i < targetRowCount; i++)
            for (var j = 0; j < targetColCount; j++)
                result[i, j] = a[i, j] + b[i, j];

            return result;
        }


        public static Matrix operator -(Matrix a, Matrix b)
        {
            var targetRowCount = Math.Max(a.RowCount, b.RowCount);
            var targetColCount = Math.Max(a.ColCount, b.ColCount);
            var result = new Matrix(targetRowCount, targetColCount);
            for (var i = 0; i < targetRowCount; i++)
            for (var j = 0; j < targetColCount; j++)
                result[i, j] = a[i, j] - b[i, j];

            return result;
        }


        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.ColCount != b.RowCount)
                throw new ArgumentException(
                    $"Количество столбцов в матрице А ({a.ColCount}) не соответствует количеству строк в матрице Б ({b.RowCount})");

            var result = new Matrix(a.RowCount, b.ColCount);
            for (var i = 0; i < a.RowCount; i++)
            {
                for (var j = 0; j < b.ColCount; j++)
                {
                    for (var ix = 0; ix < a.ColCount; ix++)
                    {
                        var x = a[i, ix];
                        var y = b[ix, j];
                        var temp = x * y;
                        result[i, j] += temp;
                    }
                }
            }

            return result;
        }

        public Matrix Transpose()
        {
            if (RowCount != ColCount)
                throw new ArgumentException("Матрица должна быть квадратной");

            var targetSize = RowCount;

            var result = new Matrix(_matrix);
            for (var i = 0; i < targetSize; i++)
            {
                for (var j = 0; j < i; j++)
                {
                   var temp = result[i, j];
                    result[i, j] = result[j, i];
                    result[j, i] = temp;
                }
            }

            return result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < RowCount; i++)
            {
                var line = "";
                for (var j = 0; j < ColCount; j++)
                {
                    line += $"\t{_matrix[i, j]}";
                }

                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix asMatrix))
                return false;

            if (asMatrix.ColCount != ColCount || asMatrix.RowCount != RowCount)
                return false;

            for (var i = 0; i < RowCount; i++)
                for (var j = 0; j < ColCount; j++)
                    if (asMatrix[i, j] != this[i, j])
                        return false;

            return true;
        }

        protected bool Equals(Matrix other)
        {
            return Equals(_matrix, other._matrix);
        }

        public override int GetHashCode()
        {
            return (_matrix != null ? _matrix.GetHashCode() : 0);
        }
    }
}