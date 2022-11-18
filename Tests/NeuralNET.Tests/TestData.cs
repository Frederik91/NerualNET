using NumSharp;

namespace NeuralNET.Tests;

public static class TestData
{
    public static (NDArray, NDArray) CreateSpiralData(int points, int classes)
    {
        var X = np.zeros(new Shape(points * classes, 2));
        var y = np.zeros(new Shape(points * classes), np.uint8);
        foreach (var classNumber in Enumerable.Range(0, classes))
        {
            var ix = np.array(Enumerable.Range(points * classNumber, points));
            var r = np.linspace(0.0, 1, points);
            var t = np.linspace(classNumber * 4, (classNumber + 1) * 4, points) + np.random.randn(points) * 0.2;
            X[ix] = np.concatenate((r * np.sin(t * 2.5), r * np.cos(t * 2.5)));
            y[ix] = classNumber;
        }
        return (X, y);
    }
}