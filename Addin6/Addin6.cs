using AddinContract;
using static System.Console;

namespace Addin6
{
    public class Addin6 : IAddinContract
    {
        public string AddinTitle => "アドイン 6";
        public void DoWork() => WriteLine("これは、.NET 6 ターゲットの DLL 内に書かれた処理です。");
    }
}
