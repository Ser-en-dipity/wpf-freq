// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="OxyPlot">
//   Copyright (c) 2014 OxyPlot contributors
// </copyright>
// <summary>
//   Represents the view-model for the main window.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace wpf.oxyplot
{
    using OxyPlot;
    using OxyPlot.Series;

    /// <summary>
    /// Represents the view-model for the main window.
    /// </summary>
    public class MainViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        public MainViewModel()
        {
            // Create the plot model
            var tmp = new PlotModel { Title = "Simple example", Subtitle = "using OxyPlot" };
            var series1 = new LineSeries { Title = "Series 1", MarkerType = MarkerType.Circle };

            // frequence response plot
            /// w0 central rejection frequency
            var w0 = 400;
            /// wc width of rejected band
            var wc = -3;
            for (int w = 0; w < 1000; w++)
            {
                var denominator = Math.Sqrt(Math.Pow(w0 * w0 - w * w, 2) + Math.Pow(wc * w, 2));
                var numerator = w0 * w0 - w * w;
                var amplitude = numerator / denominator;
                var y = 20 * Math.Log10(Math.Abs(amplitude));
                if (y < -100000)
                {
                    continue;
                }
                series1.Points.Add(new DataPoint(w, y));
            }

            var series2 = new LineSeries { Title = "Series 2", MarkerType = MarkerType.Square };
            w0 = 800;
            wc = 10;
            for (int w = 0; w < 1600; w++)
            {
                var denominator = Math.Sqrt(Math.Pow(w0 * w0 - w * w, 2) + Math.Pow(wc * w, 2));
                var numerator = w0 * w0 - w * w;
                var amplitude = numerator / denominator;
                var y = 20 * Math.Log10(Math.Abs(amplitude));
                if (y < -100000)
                {
                    continue;
                }
                series2.Points.Add(new DataPoint(w, y));
            }



            // Add the series to the plot model
            tmp.Series.Add(series1);
            tmp.Series.Add(series2);

            // Axes are created automatically if they are not defined

            // Set the Model property, the INotifyPropertyChanged event will make the WPF Plot control update its content
            this.Model = tmp;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Plot1.RefreshPlot(true);
        }

        /// <summary>
        /// Gets the plot model.
        /// </summary>
        public PlotModel Model { get; private set; }
    }
}