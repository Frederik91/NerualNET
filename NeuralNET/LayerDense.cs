using NumSharp;

namespace NeuralNET
{
    public class LayerDense : ILayer
    {
        public LayerDense(int inputSize, int neuronCount)
        {
            Weights = 0.1 * np.random.randn(inputSize, neuronCount);
            Biases = np.zeros((1, neuronCount));
        }

        public NDArray Weights { get; }
        public NDArray? Output { get; private set; }
        public NDArray Biases { get; }

        public void Forward(NDArray input)
        {
            Output = np.dot(input, Weights) + Biases;
        }
    }
}