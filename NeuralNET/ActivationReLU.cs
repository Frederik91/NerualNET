using NumSharp;

namespace NeuralNET;

public class ActivationReLU : IActivation
{
    public NDArray? Output { get; private set; }

    public void Forward(NDArray inputs)
    {
        Output = np.maximum(0.0, inputs);
    }
}