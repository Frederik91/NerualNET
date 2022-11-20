using NumSharp;

namespace NeuralNET.Tests;

public class CategoricalCrossEntropyLossTests
{
    [Fact]
    public void Test()
    {
        var expected = np.array(new float[] { 0.7f, 0.5f, 0.9f });
        expected = np.log(expected);
        expected = expected.NegateFloat();
        var expectedLoss = (float)np.mean(expected).GetValue<double>();

        var cut = new CategoricalCrossEntropyLoss();

        var yPred = np.array(new float[][] {
                             new float[] { 0.7f, 0.1f, 0.2f },
                             new float[] { 0.1f, 0.5f, 0.4f },
                             new float[] { 0.02f, 0.9f, 0.08f }
        });
        var y = np.array(new int[] { 0, 1, 1 });

        var loss = cut.Calculate(yPred, y);

        Assert.Equal(expectedLoss, loss);
    }
}