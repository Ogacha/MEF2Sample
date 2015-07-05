using AddinContract;


namespace AddinA
{
    public class AddinSampleA : IAddinContract
    {
        public string AddinTitle { get { return "Addin - A"; } }
        public void DoWork() { return; }
    }
}
