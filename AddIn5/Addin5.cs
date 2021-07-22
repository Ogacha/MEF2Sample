using AddinContract;
using static System.Console;

namespace AddIn5
{
    public class Addin5 : IAddinContract
    {
        public string AddinTitle => "アドイン 5";
        public void DoWork() => WriteLine("これは、アドイン .NET 5 が実行しています。");
    }
}
