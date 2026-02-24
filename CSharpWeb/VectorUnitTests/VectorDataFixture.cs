using VectorTask;

namespace VectorUnitTests
{
    public class VectorDataFixture : IDisposable
    {
        public List<Vector> Vectors { get; } =
        [
            new([2.0, 3.0, 1.0]) ,
            new([-1.0, 0, 2.0]) ,
            new([1.0, 3.0, 20.0])
        ];

        public void Dispose()
        {
            Vectors.Clear();
        }
    }
}
