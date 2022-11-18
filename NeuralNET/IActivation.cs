using NumSharp;

namespace NeuralNET;

public interface IActivation
{
    NDArray? Output { get; }
    void Forward(NDArray inputs);
}
