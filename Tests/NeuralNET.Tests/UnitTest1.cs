using NumSharp;

namespace NeuralNET.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var (X, y) = TestData.CreateSpiralData(100, 3);
        var dense1 = new LayerDense(2, 3);
        var activation1 = new ActivationReLU();

        var dense2 = new LayerDense(3, 3);
        var actionation2 = new ActivationSoftmax();

        dense1.Forward(X);
        activation1.Forward(dense1.Output!);
        dense2.Forward(activation1.Outputs!);
        actionation2.Forward(dense2.Output!);
    }

    [Fact]
    public void Test2()
    {
        var x = np.zeros(4);
        var firstHalf = np.array(Enumerable.Range(0, 2));
        x[firstHalf] = np.full_like(x[firstHalf], 1);

        Assert.Equal(1, x[0].GetValue());
    }

    [Fact]
    public void Test3()
    {
        var x = np.zeros(1);
        var x1 = np.full_like(x, 1);
        var y = np.concatenate(new[] { x, x1 });
    }
}