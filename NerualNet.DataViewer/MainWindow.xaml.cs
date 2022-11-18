using NeuralNET.Tests;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NerualNet.DataViewer;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public PlotModel Model { get; private set; }

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        var tmp = new PlotModel { Title = "Simple example", Subtitle = "using OxyPlot" };
        
        var (X, y) = TestData.CreateSpiralData(100, 3);

        var series1 = new ScatterSeries { Title = "Series 1", MarkerType = MarkerType.Circle };
        
        for (int i = 0; i < 100; i++)
        {
            series1.Points.Add(new ScatterPoint(X[i][0], X[i][1], tag: y[i]));
        }

        // Add the series to the plot model
        tmp.Series.Add(series1);

        // Axes are created automatically if they are not defined

        // Set the Model property, the INotifyPropertyChanged event will make the WPF Plot control update its content
        Model = tmp;
    }
}
