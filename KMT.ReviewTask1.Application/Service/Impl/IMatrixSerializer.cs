using KMT.ReviewTask1.Application.Model;

namespace KMT.ReviewTask1.Application.Service.Impl
{
    public interface IMatrixSerializer
    {
        Matrix Deserialize(string s);
        string Serialize(Matrix m);
    }
}