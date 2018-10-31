using System;
using System.Linq;
using System.Text;
using KMT.ReviewTask1.Application.Model;

namespace KMT.ReviewTask1.Application.Service.Impl
{
    public class MatrixSerializer : IMatrixSerializer
    {
        public string Serialize(Matrix m)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < m.RowCount; i++)
            {
                var line = "";
                for (var j = 0; j < m.ColCount; j++)
                {
                    line += " "+ m[i, j];
                }

                sb.AppendLine(line.Trim());
            }
            return sb.ToString();
        }

        public Matrix Deserialize(string s)
        {
            var rows = s.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            var elements = rows.Select(r => r.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToList()).ToList();

            var rowCount = rows.Length;
            var colCount = elements.Max(x => x.Count);

            var result = new Matrix(rowCount, colCount);
            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < colCount; j++)
                {
                    var row = elements[i];
                    result[i, j] = j < row.Count
                        ? row[j]
                        : 0;
                }
            }

            return result;
        }
    }
}
