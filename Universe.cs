using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Universe
{
  class Universe
  {
    private Counter<Particle> Contents { get; set; }
    private Random Random { get; set; }
    private Colorizer<Particle> Colorizer { get; set; }

    public Universe() : this(1) {}

    public Universe(int n)
    {
      Random = new Random();
      
      Contents = new Counter<Particle>()
      {
        { new HiggsBoson(), n }
      };

      Colorizer = new Colorizer<Particle>();
    }

    public Universe(int n, Random random)
    {
      Random = random;

      Contents = new Counter<Particle>()
      {
        { new HiggsBoson(), n }
      };
    }

    public bool Step()
    {
      var newContents = new Counter<Particle>();
      foreach (var pair in Contents)
      {
        var particle = pair.Key;
        var count = pair.Value;
        
        for (var i = 0; i < count; i++)
        {
          newContents.AddRange(particle.Step(Random));
        }
      }

      Contents = newContents;

      foreach (var particle in Contents.Keys)
      {
        if (particle.DecayChance > 0)
        {
          return true;
        }
      }

      return false;
    }

    public bool Step(out bool hasChanged)
    {
      var oldContents = Contents;
      var done = Step();
      var newContents = Contents;

      hasChanged = DiffContents(oldContents, newContents);

      return done;
    }

    bool DiffContents<T>(Counter<T> a, Counter<T> b)
    {
      foreach (var particle in a.Keys.Union(b.Keys))
      {
        if (a[particle] != b[particle])
        {
          return true;
        }
      }

      return false;
    }

    public IList<Tuple<string, Color>> ListContents()
    {
      var list = new List<Tuple<string, Color>>();
      
      foreach (var pair in Contents)
      {
        var particle = pair.Key;
        var count = pair.Value;

        var str = count + " " + particle + (count == 1 ? "" : "s");
        var color = GetColor(particle);

        list.Add(Tuple.Create(str, color));
      }

      return list;
    }

    Color GetColor(Particle particle)
    {
      return Colorizer.GetColor(particle);
    }
  }
}
