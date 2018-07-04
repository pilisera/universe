using System;
using System.Collections.Generic;

namespace Universe
{
  class CharmAntiquark : Particle
  {
    public override double DecayChance { get { return 0.0; } }

    protected override IEnumerable<Particle> Decay(Random random)
    {
      var rand = random.NextDouble();
      return null;
    }

    public override string ToString()
    {
      return "charm antiquark";
    }
  }
}
