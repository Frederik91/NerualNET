namespace NeuralNET.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var (X, y) = TestData.CreateSpiralData(100, 3);
        var layer1 = new LayerDense(2, 5);
        var activation1 = new ActivationReLU();
        layer1.Forward(X);
        activation1.Forward(layer1.Output!);
    }
}