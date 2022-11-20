using NumSharp;

namespace NeuralNET;

public abstract class Loss
{
    public float Calculate(NDArray output, NDArray y)
    {
        var sampleLosses = Forward(output, y);
        var mean = np.mean(sampleLosses);
        return (float)mean.GetValue<double>();
    }
    
    public abstract NDArray Forward(NDArray output, NDArray y);
}

