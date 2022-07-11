using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Collections.Generic;

namespace WacomArea {
    public class Converter {
        static Dictionary<string, float> TabletArea = new Dictionary<string, float>();
        static Dictionary<string, int> WacomArea = new Dictionary<string, int>();
        static public void Main(string[] args) {
            Console.WriteLine("Wacom Area Converter made by Fysix");
            Console.WriteLine("What is your area width?: ");
            float w = float.Parse(Console.ReadLine());
            Console.WriteLine("What is your area height?: ");
            float h = float.Parse(Console.ReadLine());
            Console.WriteLine("What is your area X position?: ");
            float x = float.Parse(Console.ReadLine());
            Console.WriteLine("What is your area Y position?: ");
            float y = float.Parse(Console.ReadLine());
            TabletArea.Add("width", w);
            TabletArea.Add("height", h);
            TabletArea.Add("xpos", x);
            TabletArea.Add("ypos", y);
            double wacomLeft = (TabletArea["xpos"] - TabletArea["width"] / 2) * 100.0;
            double wacomRight = (TabletArea["xpos"] + TabletArea["width"] / 2) * 100.0;
            double wacomTop = (TabletArea["ypos"] - TabletArea["height"] / 2) * 100.0;
            double wacomBottom = (TabletArea["ypos"] + TabletArea["height"] / 2) * 100.0;
            Console.WriteLine("Left: " + Math.Round(wacomLeft));
            Console.WriteLine("Right: " + Math.Round(wacomRight));
            Console.WriteLine("Top: " + Math.Round(wacomTop));
            Console.WriteLine("Bottom: " + Math.Round(wacomBottom));
        } 
    }
}