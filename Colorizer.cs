using System;
using System.Collections.Generic;
using System.Drawing;

namespace Universe
{
  class Colorizer<T>
  {
    private List<Color> Colors { get; set; }
    private Dictionary<T, Color> ColorMap { get; set; }
    private int NextIndex { get; set; }

    public Colorizer()
    {
      Colors = new List<Color>()
      {
        Color.Red,
        Color.Orange,
        Color.Yellow,
        Color.Green,
        Color.Blue,
        Color.Purple,
      };

      ColorMap = new Dictionary<T, Color>();

      NextIndex = 0;
    }

    public Color GetColor(T item)
    {
      if (ColorMap.ContainsKey(item))
      {
        return ColorMap[item];
      }
      else
      {
        var color = Colors[NextIndex];
        NextIndex = (NextIndex + 1) % Colors.Count;
        ColorMap[item] = color;
        return color;
      }
    }
  }
}
