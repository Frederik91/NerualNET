using NumSharp;
using System.Numerics;

namespace NeuralNET;

internal static class NDArrayExtensions
{
    public static NDArray NegateFloat(this NDArray array)
    {
        var result = np.zeros(array.shape);
        for (int i = 0; i < array.size; i++)
        {
            result[i] = -array[i].GetValue<float>();
        }
        return result;
    }
}

