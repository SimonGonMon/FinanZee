﻿using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace FinanZee_WPF.Windows
{
    [ObservableObject]
    public partial class Graph1Model
    {
        //public Graph1Model()
        //{
        //    var cities = new[]
        //    {
        //        new City { Name = "Tokyo", Population = 4, LandArea = 3 },
        //        new City { Name = "New York", Population = 6, LandArea = 4 },
        //        new City { Name = "Seoul", Population = 2, LandArea = 1 },
        //        new City { Name = "Moscow", Population = 8, LandArea = 7 },
        //        new City { Name = "Shanghai", Population = 3, LandArea = 2 },
        //        new City { Name = "Guadalajara", Population = 4, LandArea = 5 }
        //    };


        //    SeriesCollection = new[]
        //    {
        //        new LineSeries<City>
        //        {
        //            Name = "Population",
        //            TooltipLabelFormatter = point => $"{point.Model.Name} population: {point.PrimaryValue:N2}M",
        //            Values = cities,

        //            Mapping = (city, point) =>
        //            {
        //                point.PrimaryValue = (float)city.Population;
        //                point.SecondaryValue = point.Context.Index;
        //            }
        //        }
        //    };
        //}

        public Graph1Model()
        {
            XAxes = new[]
            {
                new Axis
                {
                    LabelsRotation = 15,
                    Labeler = value => new DateTime((long) value).ToString("yyyy MMM dd"),
                    // set the unit width of the axis to "days"
                    // since our X axis is of type date time and 
                    // the interval between our points is in days
                    UnitWidth = TimeSpan.FromDays(1).Ticks
                }
            };

            SeriesCollection = new ISeries[]
            {
                new CandlesticksSeries<FinancialPoint>
                {
                    UpFill = new SolidColorPaint(SKColors.Blue),
                    UpStroke = new SolidColorPaint(SKColors.CornflowerBlue) { StrokeThickness = 5 },
                    DownFill = new SolidColorPaint(SKColors.Red),
                    DownStroke = new SolidColorPaint(SKColors.Orange) { StrokeThickness = 5 },
                    Values = new ObservableCollection<FinancialPoint>
                    {
                        //                             date,        high, open, close, low
                        new FinancialPoint(new DateTime(2021, 1, 1), 523, 500, 450, 400),
                        new FinancialPoint(new DateTime(2021, 1, 2), 500, 450, 425, 400),
                        new FinancialPoint(new DateTime(2021, 1, 3), 490, 425, 400, 380),
                        new FinancialPoint(new DateTime(2021, 1, 4), 420, 400, 420, 380),
                        new FinancialPoint(new DateTime(2021, 1, 5), 520, 420, 490, 400),
                        new FinancialPoint(new DateTime(2021, 1, 6), 580, 490, 560, 440),
                        new FinancialPoint(new DateTime(2021, 1, 7), 570, 560, 350, 340),
                        new FinancialPoint(new DateTime(2021, 1, 8), 380, 350, 380, 330),
                        new FinancialPoint(new DateTime(2021, 1, 9), 440, 380, 420, 350),
                        new FinancialPoint(new DateTime(2021, 1, 10), 490, 420, 460, 400),
                        new FinancialPoint(new DateTime(2021, 1, 11), 520, 460, 510, 460),
                        new FinancialPoint(new DateTime(2021, 1, 12), 580, 510, 560, 500),
                        new FinancialPoint(new DateTime(2021, 1, 13), 600, 560, 540, 510),
                        new FinancialPoint(new DateTime(2021, 1, 14), 580, 540, 520, 500),
                        new FinancialPoint(new DateTime(2021, 1, 15), 580, 520, 560, 520),
                        new FinancialPoint(new DateTime(2021, 1, 16), 590, 560, 580, 520),
                        new FinancialPoint(new DateTime(2021, 1, 17), 650, 580, 630, 550),
                        new FinancialPoint(new DateTime(2021, 1, 18), 680, 630, 650, 600),
                        new FinancialPoint(new DateTime(2021, 1, 19), 670, 650, 600, 570),
                        new FinancialPoint(new DateTime(2021, 1, 20), 640, 600, 610, 560),
                        new FinancialPoint(new DateTime(2021, 1, 21), 630, 610, 630, 590),
                    }
                }
            };

        }

        public ISeries[] SeriesCollection { get; set; }
        public Axis[] XAxes { get; set; }


    }


}



        //public Graph1Model()
        //{
        //    var values = new int[100];
        //    var r = new Random();
        //    var t = 0;

        //    for (var i = 0; i < 100; i++)
        //    {
        //        t += r.Next(-90, 100);
        //        values[i] = t;
        //    }

        //    SeriesCollection = new ISeries[] {
        //        new LineSeries<int> {
        //            Values = values,
        //            GeometrySize = 5,
        //            LineSmoothness = 0,
        //        } 
        //    };
        //}

        //public ISeries[] SeriesCollection { get; set; }