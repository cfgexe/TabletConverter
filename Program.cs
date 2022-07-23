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
            Console.WriteLine("Would you like to convert Wacom to Hawku area or Hawku to Wacom area?");
			Console.WriteLine("[1] Wacom To Hawku area");
			Console.WriteLine("[2] Hawku to Wacom area");
			int choice = int.Parse(Console.ReadLine());
			if (choice == 1) {
				WacToHaw();
			}
			else if (choice == 2) {
				HawToWac();
			}
        }
		static public void HawToWac() {
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
			Console.ReadKey();
		}
		static public void WacToHaw() {
			double ConversionFactor = 15200.0 / 152.0;
			Console.WriteLine("Wacom Area Converter made by Fysix");
            Console.WriteLine("What is your area Left?: ");
            float l = float.Parse(Console.ReadLine());
            Console.WriteLine("What is your area Right?: ");
            float r = float.Parse(Console.ReadLine());
            Console.WriteLine("What is your area Top?: ");
            float t = float.Parse(Console.ReadLine());
            Console.WriteLine("What is your area Bottom: ");
            float b = float.Parse(Console.ReadLine());
            TabletArea.Add("top", t);
            TabletArea.Add("left", l);
            TabletArea.Add("right", r);
            TabletArea.Add("bottom", b);
            double hawkuWidth = (r - l) / ConversionFactor;
			hawkuWidth = Math.Round((double)hawkuWidth, 2);
            double hawkuHeight = (b - t) / ConversionFactor;
			hawkuHeight = Math.Round((double)hawkuHeight, 2);
            double hawkuX = (hawkuWidth / 2) + (l / ConversionFactor);
			hawkuX = Math.Round((double)hawkuX, 2);
            double hawkuY = (hawkuHeight / 2) + (t / ConversionFactor);
			hawkuY = Math.Round((double)hawkuY, 2);
            Console.WriteLine("Width: " + hawkuWidth);
            Console.WriteLine("Height: " + hawkuHeight);
            Console.WriteLine("X: " + hawkuX);
            Console.WriteLine("Y: " + hawkuY);
			Console.ReadKey();
		}
    }
}