﻿using System;
using System.Collections.Generic;
using ClientService.Model;
using Gui.Common;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Extensions;
using OxyPlot.Series;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace Gui.ViewModel
{
    [ImplementPropertyChanged]
    public class ChartViewModel
    {
        public PlotModel PlotModel { get; set; }
        public LineSeries LineSeries  { get; set; }
        private readonly List<OxyColor> Colors = new List<OxyColor>
                                            {
                                                OxyColors.Green,
                                                OxyColors.IndianRed,
                                                OxyColors.Coral,
                                                OxyColors.Chartreuse,
                                                OxyColors.Azure
                                            };

        private readonly List<MarkerType> MarkerTypes = new List<MarkerType>
                                                   {
                                                       MarkerType.Plus,
                                                       MarkerType.Star,
                                                       MarkerType.Diamond,
                                                       MarkerType.Triangle,
                                                       MarkerType.Cross
                                                   };

        public ChartViewModel()
        {
            SetUpModel();
        } 

        public void DrawChart(List<PointD> list)
        {
            foreach (var point in list)
            {
               LineSeries.Points.Add(new DataPoint(point.X, point.Y));
            }
            PlotModel.Series.Add(LineSeries);
            PlotModel.InvalidatePlot(true);
        }

        public void AddNewSeries(List<PointD> list, ObservableCollection<BoatDto> boatsCollection, 
            int selectedIndexBoat, double optimalDirection, int minX, int maxX, int minY, int maxY)
        {
            LineSeries = new LineSeries();
            LineSeries.Title = boatsCollection[selectedIndexBoat].Name + ", kurs optymalny: " + optimalDirection.ToString();
            AddAxes(minX-1, maxX+1, minY-1, maxY+1);
            DrawChart(list);

        }

        public void AddAxes(int minX, int maxX, int minY, int maxY)
        {
            PlotModel.Axes.Clear();
            PlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,

                Minimum = minX,
                Maximum = maxX
            });

            PlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = minY,
                Maximum = maxY
            });
        }

        public void SetUpModel()
        {
            PlotModel = new PlotModel();
            PlotModel.LegendTitle = "Legenda";
            PlotModel.LegendOrientation = LegendOrientation.Horizontal;
            PlotModel.LegendPlacement = LegendPlacement.Inside;
            PlotModel.LegendPosition = LegendPosition.RightTop;
            PlotModel.LegendBackground = OxyColor.FromAColor(200, OxyColors.White);
            PlotModel.LegendBorder = OxyColors.Black;

            AddAxes(0, 4, 0, 4);
            //var dateAxis = new DateTimeAxis(AxisPosition.Bottom, "Date", "HH:mm") { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, IntervalLength = 80 };
            //PlotModel.Axes.Add(dateAxis);
            //var valueAxis = new LinearAxis(AxisPosition.Left, 0) { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Title = "Value" };
            //PlotModel.Axes.Add(valueAxis);


            //  PlotModel.Series.Add(new FunctionSeries(Math.Cos, -20, 40, 0.1, "cos(x)"));

            //List<double> ListX = new List<double> { 5, 2, 9, 8, 7, 3 };
            //LineSeries ll = new LineSeries();
            //for (int i = 0; i < 20; i++)
            //{
            //    ll.Points.Add(new DataPoint(i, i + 6));
            //}
            //for (int i = 0; i < 20; i++)
            //{
            //    ll.Points.Add(new DataPoint(i, i - 6));
            //}

            //PlotModel.Series.Add(ll);



            //List<double> ListY = new List<double> { 5, 2, 9, 8, 7, 3 };
            //  PlotModel.AddScatterSeries(ListX, ListY);


            //var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };
            //var r = new Random(314);
            //for (int i = -20; i < 50; i++)
            //{
            //    var x = r.NextDouble();
            //    var y = r.Next(-90, -50);
            //    var size = r.Next(5, 15);
            //    var colorValue = r.Next(100, 1000);
            //    scatterSeries.Points.Add(new ScatterPoint(x, y, 10, colorValue));
            //}
            //PlotModel.Series.Add(scatterSeries);
        }

    }
}
