using System;
using Course.Utility;

namespace Course.Observers
{
    public sealed class ObserverHandle : IDisposable
    {
        internal int Index;
        internal IObserverList List;

        public void Dispose()
        {
            if (List != null) {
                List.Remove(this);
                DebugOnly.Check(List == null, "Handle was not properly removed from the list.");
            }
        }
    }
}
