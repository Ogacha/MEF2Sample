using System.Collections.Generic;

namespace AddinContract
{
    public interface IAddinContract
    {
        string AddinTitle { get; }
        void DoWork();
    }
}

