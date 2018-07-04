using System;
using System.Collections.Generic;

namespace Universe
{
  class ZBoson : Particle
  {
    public override double DecayChance { get { return 0.5; } }

    protected override IEnumerable<Particle> Decay(Random random)
    {
      var rand = random.NextDouble();
      if (rand < 0.206)
      {
        yield return new Neutrino();
        yield return new Antineutrino();
      }
      else if (rand < 0.240)
      {
        yield return new Electron();
        yield return new Positron();
      }
      else if (rand < 0.274)
      {
        yield return new Muon();
        yield return new Antimuon();
      }
      else if (rand < 0.308)
      {
        yield return new TauLepton();
        yield return new AntitauLepton();
      }
      else if (rand < 0.46)
      {
        yield return new DownQuark();
        yield return new DownAntiquark();
      }
      else if (rand < 0.612)
      {
        yield return new StrangeQuark();
        yield return new StrangeAntiquark();
      }
      else if (rand < 0.764)
      {
        yield return new BottomQuark();
        yield return new BottomAntiquark();
      }
      else if (rand < 0.882)
      {
        yield return new UpQuark();
        yield return new UpAntiquark();
      }
      else
      {
        yield return new CharmQuark();
        yield return new CharmAntiquark();
      }
    }

    public override string ToString()
    {
      return "Z boson";
    }
  }
}
