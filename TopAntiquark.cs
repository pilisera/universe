using System;
using System.Collections.Generic;

namespace Universe
{
  class TopAntiquark : Particle
  {
    public override double DecayChance { get { return 0.1295; } }

    protected override IEnumerable<Particle> Decay(Random random)
    {
      var options = new Func<Particle>[] { MakeDownAntiquark, MakeStrangeAntiquark, MakeBottomAntiquark };
      var index = random.Next(options.Length);
      var selected = options[index];
      yield return new WBoson();
      yield return selected();
    }

    Particle MakeDownAntiquark()
    {
      return new DownAntiquark();
    }

    Particle MakeStrangeAntiquark()
    {
      return new StrangeAntiquark();
    }

    Particle MakeBottomAntiquark()
    {
      return new BottomAntiquark();
    }

    public override string ToString()
    {
      return "top antiquark";
    }
  }
}
