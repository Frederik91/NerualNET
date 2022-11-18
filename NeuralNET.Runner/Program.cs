using NeuralNET;

var neurons = new INeuron[] { new SigmoidNeuron {Value = 1.0f}, new SigmoidNeuron(), new SigmoidNeuron(), new SigmoidNeuron() };
var weights = new float[][] { new float[] { 0.1f, 0.2f }, new float[] { 0.3f, 0.4f } };
var layer = new Layer(neurons, weights);

layer.CalculateOutput(new float[] { 1, 2 });

for (int i = 0; i < layer.Outputs.Length; i++)
{
    Console.WriteLine(layer.Outputs[i]);    
}