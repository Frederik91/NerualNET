using NumSharp;

namespace NeuralNET;

public interface ILayer
{
    NDArray Weights {get;}
    NDArray? Output { get; }
    NDArray Biases { get; }

    void Forward(NDArray input);
}