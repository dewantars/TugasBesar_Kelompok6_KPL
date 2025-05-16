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
        // Daftar transisi
        private Transition[] transitions =
        {
            new Transition(State.Basecamp, State.Pos1, Trigger.NaikPos),
            new Transition(State.Pos1, State.Pos2, Trigger.NaikPos),
            new Transition(State.Pos2, State.Puncak, Trigger.CapaiPuncak),
            new Transition(State.Puncak, State.Turun, Trigger.TurunGunung),
            new Transition(State.Turun, State.Selesai, Trigger.SelesaiPendakian),
        };

        public State GetNext(State from, Trigger trigger)
        {
            foreach (var t in transitions)
            {
                if (t.From == from && t.Trigger == trigger)
                    return t.To;
            }
            return from; // Tidak berubah jika tidak cocok
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

