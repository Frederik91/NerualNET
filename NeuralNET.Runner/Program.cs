using NeuralNET;
using NeuralNET.Tests;
using NumSharp;

var (X, y) = TestData.CreateSpiralData(100, 3);
var dense1 = new LayerDense(2, 3);
var activation1 = new ActivationReLU();

var dense2 = new LayerDense(3, 3);
var actionation2 = new ActivationSoftmax();

dense1.Forward(X);
activation1.Forward(dense1.Output!);
dense2.Forward(activation1.Outputs!);
actionation2.Forward(dense2.Output!);

var lossFunction = new CategoricalCrossEntropyLoss();
var loss = lossFunction.Calculate(actionation2.Outputs!, y);

var lowestLoss = 999999f;
var bestDense1Weights = dense1.Weights.copy();
var bestDense1Biases = dense1.Biases.copy();
var bestDense2Weights = dense2.Weights.copy();
var bestDense2Biases = dense2.Biases.copy();

for (int i = 0; i < 10000; i++)
{
    dense1.Weights = 0.05 * np.random.randn(2, 3);
    dense1.Biases = 0.05 * np.random.randn(1, 3);
    dense2.Weights = 0.05 * np.random.randn(3, 3);
    dense2.Biases = 0.05 * np.random.randn(1, 3);

    dense1.Forward(X);
    activation1.Forward(dense1.Output!);
    dense2.Forward(activation1.Outputs!);
    actionation2.Forward(dense2.Output!);

    loss = lossFunction.Calculate(actionation2.Outputs!, y);

    if (loss < lowestLoss)
    {
        var predictions = np.argmax(actionation2.Outputs!, axis: 1);
        var equality = predictions == y;
        var equalityNum = equality.astype(np.@byte);
        var accuracy = np.mean(equalityNum);
        Console.WriteLine($"New set of weights found, iteration: {i}, loss: {loss}, acc: {accuracy}");
        bestDense1Weights = dense1.Weights.copy();
        bestDense1Biases = dense1.Biases.copy();
        bestDense2Weights = dense2.Weights.copy();
        bestDense2Biases = dense2.Biases.copy();
        lowestLoss = loss;
    }
}