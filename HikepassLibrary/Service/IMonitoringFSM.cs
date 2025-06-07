using System.Collections.Generic;
using static HikepassLibrary.Model.MonitoringFSM;

namespace HikepassLibrary.Model
{
    public interface IMonitoringFSM
    {
        void NaikPos();
        void CapaiPuncak();
        void TurunGunung();
        void SelesaiPendakian();
        List<Trigger> GetAvailableTriggers(State from);
        State GetNext(State from, Trigger trigger);
    }
}
