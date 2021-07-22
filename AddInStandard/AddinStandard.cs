using AddinContract;
using static System.Console;

namespace AddInStandard
{
    public class AddinStandard : IAddinContract
    {
        public string AddinTitle => "アドイン .NET Standard";
        public void DoWork() => WriteLine("これは、アドイン .NET Standard 2.0 が実行しています。");
    }
}
