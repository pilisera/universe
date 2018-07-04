using System;
using System.Collections.Generic;

namespace Universe
{
  class TopQuark : Particle
  {
    public override double DecayChance { get { return 0.1295; } }

    protected override IEnumerable<Particle> Decay(Random random)
    {
      var options = new Func<Particle>[] { MakeDownQuark, MakeStrangeQuark, MakeBottomQuark };
      var index = random.Next(options.Length);
      var selected = options[index];
      yield return new WBoson();
      yield return selected();
    }

    Particle MakeDownQuark()
    {
      return new DownQuark();
    }

    Particle MakeStrangeQuark()
    {
      return new StrangeQuark();
    }

    Particle MakeBottomQuark()
    {
      return new BottomQuark();
    }

    public override string ToString()
    {
      return "top quark";
    }
  }
}
