using NumSharp;
using NumSharp.Utilities;

namespace NeuralNET;

public sealed class CategoricalCrossEntropyLoss : Loss
{
    public override NDArray Forward(NDArray yPred, NDArray yTrue)
    {
        var samples = yPred.shape[0];
        var yPredClipped = np.clip(yPred, 1E-7f, 1f - 1E-7f);

        NDArray correctConfidenses;
        if (yTrue.shape.Length == 1)
        {
            var range = np.array(Enumerable.Range(0, samples).ToArray());
            correctConfidenses = yPredClipped[range, yTrue];
        }
        else if (yTrue.shape.Length == 2)
            correctConfidenses = np.sum(yPredClipped * yTrue, axis: 1);
        else
            throw new NotSupportedException("yTrue shape must be of length 1 or 2");

        return np.log(correctConfidenses).NegateFloat();
    }
}

