using NumSharp;

namespace NeuralNET;

public class ActivationSoftmax : IActivation
{
    public NDArray? Outputs { get; private set; }

    public void Forward(NDArray inputs)
    {
        var exp = np.exp(inputs - np.max(inputs, axis: 1, keepdims: true));
        Outputs = exp / np.sum(exp, axis: 1, keepdims: true, np.float_);        
    }
}