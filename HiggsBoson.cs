using System;
using System.Collections.Generic;

namespace Universe
{
  class HiggsBoson : Particle
  {
    public override double DecayChance { get { return 0.000433; } }

    protected override IEnumerable<Particle> Decay(Random random)
    {
      var rand = random.NextDouble();
      if (rand < 0.648)
      {
        yield return new BottomQuark();
        yield return new BottomAntiquark();
      }
      else if (rand < 0.789)
      {
        yield return new WBoson();
        yield return new WBoson();
      }
      else if (rand < 0.8772)
      {
        yield return new Gluon();
        yield return new Gluon();
      }
      else if (rand < 0.9476)
      {
        yield return new TauLepton();
        yield return new AntitauLepton();
      }
      else if (rand < 0.9803)
      {
        yield return new CharmQuark();
        yield return new CharmAntiquark();
      }
      else if (rand < 0.9962)
      {
        yield return new ZBoson();
        yield return new ZBoson();
      }
      else if (rand < 0.99843)
      {
        yield return new Photon();
        yield return new Photon();
      }
      else if (rand < 0.99954)
      {
        yield return new ZBoson();
        yield return new Photon();
      }
      else if (rand < 0.999784)
      {
        yield return new Muon();
        yield return new Antimuon();
      }
      else
      {
        yield return new TopQuark();
        yield return new TopAntiquark();
      }
    }

    public override string ToString()
    {
      return "Higgs boson";
    }
  }
}
