using AddinContract;
using static System.Console;

namespace AddinA
{
    public class Addin4 : IAddinContract
    {
        public string AddinTitle => "アドイン 4";
        public void DoWork() => WriteLine("これは、アドイン .NET Framework 4 が実行しています。");
    }
}
