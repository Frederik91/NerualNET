using NumSharp;

namespace NeuralNET;

public interface IActivation
{
    NDArray? Outputs { get; }
    void Forward(NDArray inputs);
}
