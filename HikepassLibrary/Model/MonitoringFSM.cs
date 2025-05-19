using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public class MonitoringFSM
    {
        public enum State { Basecamp, Pos1, Pos2, Puncak, Turun, Selesai }
        public enum Trigger { MulaiPendakian, NaikPos, CapaiPuncak, TurunGunung, SelesaiPendakian }

        public State current = State.Basecamp;

        public class Transition
        {
            public State From;
            public State To;
            public Trigger Trigger;

            public Transition(State from, State to, Trigger trigger)
            {
                From = from;
                To = to;
                Trigger = trigger;
            }
        }
        private readonly Dictionary<(State, Trigger), State> transitions = new()
        {
            {(State.Basecamp, Trigger.NaikPos), State.Pos1},
            {(State.Pos1, Trigger.NaikPos), State.Pos2},
            {(State.Pos2, Trigger.CapaiPuncak), State.Puncak},
            {(State.Puncak, Trigger.TurunGunung), State.Turun},
            {(State.Turun, Trigger.SelesaiPendakian), State.Selesai},
        };

        public State GetNext(State from, Trigger trigger)
        {
            return transitions.TryGetValue((from, trigger), out var to) ? to : from;
        }

        private void TriggerAction(Trigger trigger)
        {
            var before = current;
            current = GetNext(current, trigger);
            Console.WriteLine($"FSM: {before} → {current}");
        }

        // Metode-metik pemicu transisi
        public void NaikPos() => TriggerAction(Trigger.NaikPos);
        public void CapaiPuncak() => TriggerAction(Trigger.CapaiPuncak);
        public void TurunGunung() => TriggerAction(Trigger.TurunGunung);
        public void SelesaiPendakian() => TriggerAction(Trigger.SelesaiPendakian);
    }
}

