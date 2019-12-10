using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MLLab4
{
    public struct Path
    {
        public char from, to;
        public int dist;

        public Path(char from, char to, int dist)
        {
            this.from = from;
            this.to = to;
            this.dist = dist;
        }
    }

    public class State
    {
        List<Tuple<State, int>> actions;
        public char Id { get; private set; }
        public int Value { get; set; }

        public State(char id)
        {
            this.Id = id;
            this.Value = 0;
        }

        public void InitStates(Path[] paths, StateHandler sh)
        {
            actions = new List<Tuple<State,int>>();

            foreach (Path path in paths)
            {
                if (IsRelevant(path))
                {
                    char target = GetTargetLocation(path);
                    if (!Exists(target))
                    {
                        actions.Add(new Tuple<State, int>(sh.GetState(target), path.dist));
                    }
                }

            }
        }

        public void CalcValue()
        {
            int[] res = actions.Select(x => x.Item1.Value - x.Item2).ToArray();
            Value = res.Max();
        }

        public char NextState()
        {
            int maxValue = actions.Max(x => x.Item1.Value - x.Item2);
            return actions.Where(x => x.Item1.Value-x.Item2 == maxValue).ToArray()[0].Item1.Id;
        }
        private bool IsRelevant(Path path) => Id == path.from || Id == path.to;

        private bool Exists(char target)
        {
            foreach (var action in actions)
                if (action.Item1.Id == target)
                    return true;

            return false;
        }

        //Assumes that exactly one of to/from is ourself
        private char GetTargetLocation(Path path) => Id == path.from ? path.to : path.from;

    }


}
