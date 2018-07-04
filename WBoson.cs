using System;
using System.Collections.Generic;

namespace Universe
{
  class WBoson : Particle
  {
    public override double DecayChance { get { return 0.5; } }

    protected override IEnumerable<Particle> Decay(Random random)
    {
      var options = new Func<Particle>[] { MakePositron, MakeAntimuon, MakeAntitauLepton };
      var index = random.Next(options.Length);
      var selected = options[index];
      yield return selected();
      yield return new Neutrino();
    }

    Particle MakePositron()
    {
      return new Positron();
    }

    Particle MakeAntimuon()
    {
      return new Antimuon();
    }

    Particle MakeAntitauLepton()
    {
      return new AntitauLepton();
    }

    public override string ToString()
    {
      return "W boson";
    }
  }
}
