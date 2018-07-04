using System;
using System.Collections.Generic;

namespace Universe
{
  abstract class Particle
  {
    public virtual double DecayChance
    {
      get
      {
        return 0;
      }
    }

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

    protected virtual IEnumerable<Particle> Decay(Random random)
    {
      throw new NotImplementedException();
    }

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
