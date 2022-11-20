using NumSharp;

namespace NeuralNET;

public class ActivationReLU : IActivation
{
    public NDArray? Outputs { get; private set; }

    public void Forward(NDArray inputs)
    {
        Outputs = np.maximum(0.0, inputs);
    }
}