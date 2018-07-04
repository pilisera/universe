using System;
using System.Collections.Generic;
using System.Drawing;

using Console = Colorful.Console;

namespace Universe
{
    class Program
    {
        static void Main(string[] args)
        {
          var n = 0;
          if (args.Length > 0)
          {
            int.TryParse(args[0], out n);
          }
          
          if (n <= 0)
          {
            n = 1;
          }

          var universe = new Universe(n);

          var step = 0;
          WriteContents(step, universe.ListContents());

          bool hasChanged;
          while(universe.Step(out hasChanged))
          {
            step += 1;
            if (hasChanged)
            {
              WriteContents(step, universe.ListContents());
            }
          }

          step += 1;
          WriteContents(step, universe.ListContents());
        }

        static void WriteContents(int step, IList<Tuple<string, Color>> contents)
        {
          Console.Write(step + ": ");

          for (var i = 0; i < contents.Count - 1; i++)
          {
            var pair = contents[i];
            var str = pair.Item1;
            var color = pair.Item2;
            Console.Write(str, color);
            Console.Write(", ");
          }
          
          var lastPair = contents[contents.Count - 1];
          var lastStr = lastPair.Item1;
          var lastColor = lastPair.Item2;
          Console.Write(lastStr, lastColor);
          Console.Write("\n");
        }
    }
}
