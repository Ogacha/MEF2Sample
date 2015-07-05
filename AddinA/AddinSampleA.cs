using AddinContract;


namespace AddinA
{
    [System.Composition.Export(typeof(IAddinContract))]
    public class AddinSampleA : IAddinContract
    {
        public string AddinTitle { get { return "Addin - A"; } }
        public void DoWork() { return; }
    }
}
