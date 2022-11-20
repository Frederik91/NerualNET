using NumSharp;

namespace NeuralNET;

public interface ILayer
{
    NDArray Weights { get; set; }
    NDArray? Output { get; }
    NDArray Biases { get; set; }

    void Forward(NDArray input);
}