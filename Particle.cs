using System;
using System.Collections.Generic;

namespace Universe
{
  abstract class Particle
  {
    public abstract double DecayChance { get; }

    public IEnumerable<Particle> Step(Random random)
    {
      var rand = random.NextDouble();
      if (rand < DecayChance)
      {
        return Decay(random);
      }
      else
      {
        return new[] { this };
      }
    }

    protected abstract IEnumerable<Particle> Decay(Random random);

    public override int GetHashCode()
    {
      return ToString().GetHashCode();
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Particle);
    }

    public bool Equals(Particle particle)
    {
      return particle != null && particle.ToString() == this.ToString();
    }
  }
}
