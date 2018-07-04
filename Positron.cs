using System;
using System.Collections.Generic;

namespace Universe
{
  class Positron : Particle
  {
    public override double DecayChance { get { return 0.0; } }

    protected override IEnumerable<Particle> Decay(Random random)
    {
      var rand = random.NextDouble();
      return null;
    }

    public override string ToString()
    {
      return "positron";
    }
  }
}
