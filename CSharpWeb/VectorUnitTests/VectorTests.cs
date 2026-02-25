using VectorTask;

namespace VectorUnitTests;

public class VectorTests(VectorDataFixture vectorDataFixture) : IClassFixture<VectorDataFixture>
{
    [Fact]
    public void ScalarMultiplicationTest()
    {
        var scalarMultiplicationResult = Vector.GetScalarMultiplication(vectorDataFixture.Vectors[0],
            vectorDataFixture.Vectors[1]);

        Assert.Equal(0.0, scalarMultiplicationResult, 1);
    }

    [Fact]
    public void AdditionTest()
    {
        var additionResult = Vector.GetAddition(vectorDataFixture.Vectors[1], vectorDataFixture.Vectors[2]);

        Assert.Equal(new Vector([0, 3, 22]), additionResult);
    }

    [Fact]
    public void LengthTest()
    {
        var vectorLength = vectorDataFixture.Vectors[0].GetLength();

        Assert.Equal(3.742, vectorLength, 3);
    }
}