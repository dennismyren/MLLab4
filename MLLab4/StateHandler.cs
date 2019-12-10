using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MLLab4
{
    public class StateHandler
    {
        State[] states;
        public StateHandler(string[] pathStrings)
        {
            Path[] paths = ConvertStringPaths(pathStrings);
            char[] lc = getUniqueIds(paths);
            states = new State[lc.Count()];
            for (int i = 0; i < states.Count(); i++)
                states[i] = new State(lc[i]);

            for (int i = 0; i < states.Count(); i++)
                states[i].InitStates(paths, this);
        }

        private Path[] ConvertStringPaths(string[] pathStrings)
        {
            int pc = pathStrings.Count();
            Path[] paths = new Path[pc];
            for (int i = 0; i < pc; i++)
            {
                string[] sa = pathStrings[i].Split(' ');
                paths[i] = new Path(sa[0][0], sa[1][0], Convert.ToInt32(sa[2]));
            }
            return paths;
        }

        private char[] getUniqueIds(Path[] paths)
        {
            List<char> lc = new List<char>();
            foreach (var p in paths)
            {
                lc.Add(p.from);
                lc.Add(p.to);
            }

            return lc.Distinct().ToArray();
        }

        public State GetState(char c)
        {
            foreach (var s in states)
                if (s.Id == c)
                    return s;

            throw new Exception($"State \"{c}\" does not exist");
        }
    }
}
